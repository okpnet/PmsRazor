using QualRazorCore.Controls.Tables.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Options
{
    public static class OptionFactory
    {
        public static IOption CreateTableOption<TModel>() where TModel : class
        {
            var result=new TableSchemaOption<TModel>();
            return result;
        }

    }
}
