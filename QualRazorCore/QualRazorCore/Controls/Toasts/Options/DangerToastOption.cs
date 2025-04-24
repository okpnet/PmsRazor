using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Toasts.Options
{
    public class DangerToastOption : ToastOption
    {
        public override string CssInformationClasses => ClassDefine.Message.MESSAGE_DANGER;

        public override string CssGGIconClasses => CssGGIconDefine.CloseCircle;
    }
}
