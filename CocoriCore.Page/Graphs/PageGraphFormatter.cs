using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace CocoriCore.Page
{
    public class PageGraphFormatter
    {
        public string LinksAndForms(PageGraph graph)
        {
            var sb = new StringBuilder();
            sb.AppendLine("digraph G {");
            //sb.AppendLine("rankdir=LR;");
            //sb.AppendLine("layout=\"twopi\"");

            foreach (var n in graph.Nodes.OrderBy(x => x.ParameterizedUrl).ToArray())
                sb.AppendLine(StrNode(n));

            foreach (var e in graph.Edges)
                sb.AppendLine(StrEdge(e));

            sb.AppendLine("}");
            var dotContent = sb.ToString();
            var svgContent = CmdDot(dotContent);
            return svgContent;
        }
        /*
                public string LinksAndFormsWithClusters(PageGraph graph)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("digraph G {");

                    var clusters = graph.Nodes
                                    .Where(x => x.ParameterizedUrl != "/api")
                                    .GroupBy(x => x.ParameterizedUrl.Split("/", StringSplitOptions.RemoveEmptyEntries)[1])
                                    .ToArray();


                    foreach (var n in graph.Nodes.Where(x => x.ParameterizedUrl.StartsWith()))
                    {
                        var label = n.ParameterizedUrl.Replace("/api", "");
                        if (label == "")
                            label = "/";
                        sb.AppendLine($"{n.IndexedName}[label=\"{label}\"];");
                    }


                    foreach (var e in graph.Edges)
                    {
                        sb.Append($"{e.From.IndexedName} -> {e.To.IndexedName}");
                        var properties = new List<string>();
                        if (e.Visited)
                            properties.Add("color=\"#FF0000\"");
                        if (e.IsForm)
                        {
                            properties.Add("arrowhead=empty");
                            properties.Add($"label=\"{e.Name}\"");
                            if (!e.Visited)
                                properties.Add("color=\"#0000FF\"");
                        }
                        sb.Append("[" + string.Join(",", properties) + "]");
                        sb.AppendLine(";");
                    }

                    sb.AppendLine("}");
                    var dotContent = sb.ToString();
                    var svgContent = CmdDot(dotContent);
                    return svgContent;
                }
        */
        private string StrNode(PageNode n)
        {
            var label = n.ParameterizedUrl.Replace("/api", "");
            if (label == "")
                label = "/";
            return $"{n.IndexedName}[label=\"{label}\"];";
        }

        private string StrEdge(PageEdge e)
        {
            var sb = new StringBuilder();
            sb.Append($"{e.From.IndexedName} -> {e.To.IndexedName}");
            var properties = new List<string>();
            if (e.Visited)
                properties.Add("color=\"#FF0000\"");
            if (e.IsForm)
            {
                properties.Add("arrowhead=empty");
                properties.Add($"label=\"{e.Name}\"");
                if (!e.Visited)
                    properties.Add("color=\"#0000FF\"");
            }
            sb.Append("[" + string.Join(",", properties) + "]");
            sb.Append(";");
            return sb.ToString();
        }

        private string CmdDot(string content)
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