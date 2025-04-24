using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Toasts.Options
{
    public class WarningToastOption : ToastOption
    {
        public override string CssInformationClasses => ClassDefine.Message.MESSAGE_WARNING;

        public override string CssGGIconClasses => CssGGIconDefine.Danger;
    }
}
