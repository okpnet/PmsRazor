using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Options.Core;
using QualRazorCore.Options.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Fields
{
    public partial class IconContent:OptionParameterRazorCore
    {
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        /// <summary>
        /// パラメーターのキーが割り当てられないときに、デフォルトの型のキーを使用してViewOptionを取得する
        /// </summary>
        protected override IOptionKey DefaultViewOptionKey => OptionKeyFactory.CreateDefaultKey<IconContent>();

        protected Dictionary<string, object> MergeAtribute => HtmlAttributeHelper.MergeAttributes(
            AdditionalAttributes,
            new()
            {
                ["class"]="icon"
            });
    }
}
