using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CocoriCore;

namespace CocoriCore.LeBonCoin
{
    public class HandlerFinder
    {
        private Dictionary<Type, Type> messageHandlerTypes;

        public HandlerFinder(params Assembly[] assemblies)
        {
            //var assemblies = new Assembly[]{this.GetType().Assembly} ;
            if (assemblies.Count() == 0)
            {
                throw new ConfigurationException("You must pass at least one assembly.");
            }
            this.messageHandlerTypes = assemblies
                .SelectMany(a => a.GetTypes())
                .Where(t => typeof(IHandler).IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                .ToDictionary(t =>
                {
                    var messageType = t.GetGenericArguments(typeof(IHandler<>))[0];
                    if (messageType.IsGenericParameter)
                        messageType = messageType.BaseType.GetGenericTypeDefinition();
                    if (messageType.IsGenericType)
                        messageType = messageType.GetGenericTypeDefinition();
                    return messageType;
                }, t => t);
        }

        public Type GetHandlerType(IMessage message)
        {
            return messageHandlerTypes[message.GetType()];
        }

        public Dictionary<Type, Type> GetHandlersByType()
        {
            return messageHandlerTypes;
        }
    }
}