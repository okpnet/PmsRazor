using QualRazorLib.Core;
using QualRazorLib.Providers.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
