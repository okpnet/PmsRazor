using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Containers.Core
{
    public class Tables<TModel>:NotifyCore
    {
        HeadeColumnCollection<TModel> _columns = new();
        public HeadeColumnCollection<TModel> Columns => _columns;

        IEnumerable<TModel> _source = [];
        public IEnumerable<TModel> Source
        {
            get => _source;
            set
            {
                if(_source == value)
                {
                    return;
                }
                _source = value;
                OnPropertyChanged(nameof(Source));
            }
        }

        public static IHeaderColumn<TModel> AddColumns(this Tables<TModel> tables,Func<TModel,string> getValueString,Func<string> columnName,Type propertyType,uint index)
        {
            var column = new HeaderColumn<TModel>(getValueString, columnName, propertyType);
            tables.Columns.Add(column);
            return column;
        }
    }
}
