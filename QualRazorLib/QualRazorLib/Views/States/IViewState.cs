using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Views.States
{
    /// <summary>
    /// UIとユーザーが対話する状態の管理
    /// </summary>
    public interface IViewState
    {
        bool IsLoading { get; }
        bool HasError { get; }
        string ErrorMessage { get; }

        void SetLoading(bool isLoading);
        void SetError(string message);
        void ClearError();
    }
}
