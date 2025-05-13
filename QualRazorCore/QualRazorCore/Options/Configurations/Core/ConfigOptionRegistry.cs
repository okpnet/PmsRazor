using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Configurations.Core
{
    public class ConfigOptionRegistry : RegistryCore<IOptionKey, IConfigOption>, IConfigOptionRegistry, IRegistry<IOptionKey, IConfigOption>
    {
    }
}
