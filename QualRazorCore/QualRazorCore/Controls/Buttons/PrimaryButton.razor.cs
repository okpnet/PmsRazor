using QualRazorCore.Controls.Buttons.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Helper;

namespace QualRazorCore.Controls.Buttons
{
    public partial class PrimaryButton : ButtonCore
    {
        protected override IOptionKey DefaultConfigOptionKey => OptionKeyFactory.CreateDefaultKey<PrimaryButton>();

        protected Dictionary<string, object> PrimaryMobileMergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttribute,
            new()
            {
                ["class"] = string.Join(" ", [ClassDefine.Button.STYLE ,ClassDefine.Button.DESCTOP ,ClassDefine.Button.PRIMARY])
            }
            );
        protected Dictionary<string, object> PrimaryDesktopMergeAttribute => HtmlAttributeHelper.MergeAttributes(
            MergeAttribute,
            new()
            {
                ["class"] =string.Join(" ",[ClassDefine.Button.STYLE ,ClassDefine.Button.DESCTOP, ClassDefine.Button.PRIMARY])
            }
            );
    }
}
