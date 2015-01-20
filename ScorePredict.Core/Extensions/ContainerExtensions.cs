using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Core;

namespace ScorePredict.Core.Extensions
{
    public static class ContainerExtensions
    {
        public static void RegisterModules(this ContainerBuilder builder, params Module[] modules)
        {
            foreach (var module in modules)
            {
                builder.RegisterModule(module);
            }
        }
    }
}
