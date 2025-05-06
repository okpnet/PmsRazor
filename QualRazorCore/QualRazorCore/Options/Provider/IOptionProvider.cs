using QualRazorCore.Controls.Tables.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options.Provider
{
    public interface IOptionProvider
    {
        IOption GetPropertyOption(PropertyInfo property);
        IOption GetPropertyOption<T>(string propertyName);

        TableSchemaOption<T> GetTableSchemaOption<T>() where T : class;


    }
}
