using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using CocoriCore.Router;

namespace CocoriCore.Page
{
    public class PageGraphGenerator
    {
        private readonly RouterOptions routerOptions;

        public PageGraphGenerator(RouterOptions routerOptions)
        {
            this.routerOptions = routerOptions;
        }

        public string PlantUml(Assembly assembly)
        {
            var pages = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(IPage))).ToArray();

            pages.Select(p => new
            {
                PageType = p,
                ResponseType = p.GetType().GetGenericArguments(typeof(IMessage<>)),
                Route = routerOptions.AllRoutes.First(r => r.MessageType == p),
            }).OrderBy(x => x.Route.ParameterizedUrl);


            foreach (var p in pages)
            {

            }
            return @"@startwbs
* Business Process Modelling WBS
** Launch the project
*** Complete Stakeholder Research
*** Initial Implementation Plan
** Design phase
*** Model of AsIs Processes Completed
**** Model of AsIs Processes Completed1
**** Model of AsIs Processes Completed2
*** Measure AsIs performance metrics
*** Identify Quick Wins
** Complete innovate phase
@endwbs";
        }

        public string GraphViz(Assembly assembly)
        {
            var pages = assembly.GetTypes().Where(t => t.IsAssignableTo(typeof(IPage))).ToArray();
            /*
            var nodes = pages.Select(p => new
            {
                PageType = p,
                ResponseType = p.GetGenericArguments(typeof(IMessage<>))[0],
                Route = routerOptions.AllRoutes.First(r => r.MessageType == p).ParameterizedUrl,
            }).ToArray();
            */
            int index = 0;
            Func<int> GetIndex = () => index++;
            var nodes = routerOptions.AllRoutes.Where(r => r.MessageType.IsAssignableTo<IPage>())
            .Select(r => new
            {
                Route = r.ParameterizedUrl,
                PageType = r.MessageType,
                ResponseType = r.MessageType.GetGenericArguments(typeof(IMessage<>))[0],
                Index = GetIndex()
            }).ToArray();


            var sb = new StringBuilder();
            sb.AppendLine("digraph G {");

            foreach (var l in nodes)
            {
                sb.AppendLine($"n{l.Index}[label=\"{l.Route}\"];");
            }


            foreach (var l in nodes)
            {
                var fis = l.ResponseType.GetPropertiesAndFields();
                foreach (var fi in fis)
                {
                    if (fi.GetMemberType().IsAssignableTo(typeof(IPage)))
                    {
                        var target = nodes.First(n => n.PageType == fi.GetMemberType());
                        sb.AppendLine("n" + l.Index + " -> n" + target.Index + ";");
                    }

                    if (fi.DeclaringType.IsAssignableToGeneric(typeof(Form<,>)))
                    {
                        var formResponseType = fi.GetMemberType().GetGenericArguments(typeof(Form<,>))[1];
                        if (formResponseType.IsAssignableTo(typeof(IPage)))
                        {
                            var target = nodes.First(n => n.PageType == fi.GetMemberType());
                            sb.AppendLine("n" + l.Index + " -> n" + target.Index + ";");
                        }
                    }
                }

            }
            sb.AppendLine("}");
            return sb.ToString();
        }

        public string CmdDot(string content)
        {
            var tmp = System.IO.Path.GetTempFileName();
            File.WriteAllText(tmp, content);
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dot",
                    Arguments = "-Tsvg " + tmp,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();
            var output = process.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            if (error.Length > 0)
                throw new Exception(error);
            process.WaitForExit();

            return output;
        }
    }
}