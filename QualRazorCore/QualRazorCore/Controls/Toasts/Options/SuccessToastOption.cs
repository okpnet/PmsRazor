using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Toasts.Options
{
    public class SuccessToastOption : ToastOption
    {
        public override string CssInformationClasses => ClassDefine.Message.MESSAGE_SUCCESS;

        public override string CssGGIconClasses => CssGGIconDefine.Check;
    }
}
