using QualRazorLib.Providers.Sources;

namespace QualRazorLib.Views.Converters
{
    /// <summary>
    /// DaataHolderのデータをViewのデータへ変換する
    /// </summary>
    /// <typeparam name="TInput"></typeparam>
    /// <typeparam name="TOutput"></typeparam>
    public interface IViewDataConverter<TInput, TOutput> where TOutput: IDataProvider
    {
        TOutput Convert(TInput source);
    }
}
