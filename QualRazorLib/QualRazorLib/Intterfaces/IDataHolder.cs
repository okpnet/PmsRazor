using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Intterfaces
{
    /// <summary>
    /// サービスから取得したデータやユーザー入力を保持する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataHolder<T>
    {
        T Data { get; }
    }
}
