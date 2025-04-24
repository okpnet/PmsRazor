using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Toasts.Options
{
    public class DownloadToastOption : ToastOption
    {
        public override string CssInformationClasses => ClassDefine.INFO_SUCCESS;

        public override string CssGGIconClasses => CssGGIconDefine.SoftwearDownLoad;
    }
}
