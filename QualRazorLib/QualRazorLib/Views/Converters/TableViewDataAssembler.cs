using QualRazorLib.Providers.Sources;

namespace QualRazorLib.Views.Converters
{
    public abstract class TableViewDataAssembler<TModel,TInput> where TModel : class
    {
        private readonly IViewDataConverter<TInput, ITableDataProvider<TModel>> _converter;

        public TableViewDataAssembler(IViewDataConverter<TInput, ITableDataProvider<TModel>> converter)
        {
            _converter = converter;
        }

        public abstract ITableDataProvider<TModel> Assemble(TInput source);
    }
}
