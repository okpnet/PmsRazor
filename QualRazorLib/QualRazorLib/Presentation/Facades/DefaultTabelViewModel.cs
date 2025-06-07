using QualRazorLib.Models.Tables;
using QualRazorLib.Providers.Sources;
using QualRazorLib.Views.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Presentation.Facades
{
    public class DefaultTabelViewModel<T,TInput>:TableViewModelBase<T>, ITableViewModel<T>, ITableViewModel, ITableViewParameter where T : class where TInput : class
    {
        public IViewDataConverter<TInput, ITableDataProvider<T>> Converter { get; set; } = default!;

        public Func<TInput>
    }
}
