﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Core
{
    /// <summary>
    /// サービスから取得したデータやユーザー入力を保持するマーカーインターフェイス
    /// </summary>
    public interface IDataHolder
    {
    }
    /// <summary>
    /// サービスから取得したデータやユーザー入力を保持する
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataHolder<T>: IDataHolder
    {
        T Data { get; }
    }
}
