using System;
using Laboratories.Components.Game;
using JCMG.EntitasRedux;

namespace Laboratories
{
    public static class ContextsIdExtensions
    {
        public static void SubscribeId(this Contexts contexts)
        {
            foreach (var context in contexts.AllContexts)
            {
                if (Array.FindIndex(context.ContextInfo.componentTypes, x => x == typeof(IdComponent)) >= 0)
                    context.OnEntityCreated += AddId;
            }
        }

        private static void AddId(IContext context, IEntity entity)
        {
            var guid = Guid.NewGuid();
            (entity as GameEntity).ReplaceId(guid.ToString());
        }
    }
}