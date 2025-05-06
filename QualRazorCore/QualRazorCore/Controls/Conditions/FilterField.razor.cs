using Microsoft.AspNetCore.Components;
using QualRazorCore.Controls.Conditions.Core;
using QualRazorCore.Controls.Conditions.Options;
using QualRazorCore.Controls.Conditions.Options.Core;
using QualRazorCore.Controls.Tables.Options;
using QualRazorCore.Controls.Tables.Rows.Core;
using QualRazorCore.Core;
using QualRazorCore.Extenssions;
using QualRazorCore.Observers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Conditions
{
    public partial class FilterField:RazorCore
    {
        [Parameter]
        public FilterOptionBase Option { get; set; } = default!;

        protected Dictionary<string, object> MergePropertyLabelAttributes =>
            HtmlAttributeHelper.PurgeAttributes(
                Option.PropertyLabelAdditionalAttributes,
                new([
                    new("class","label")
                    ])
                );
        
        protected PropertyAccessCore PropertyAccess => Option.PropertyConditions.PropertyAccessCore;

        protected string Label { get; set; }=string.Empty;

        protected override void OnInitialized()
        {
            Label = Option.PropertyConditions.PropertyAccessCore.PropertyName;
            disposables.Add(
                PropertyChangedRelay<PropertyAccessCore, string>.Create
                (
                    PropertyAccess,
                    nameof(PropertyAccess.PropertyName),
                    src => PropertyAccess.PropertyName,
                    sources => Label = sources
                    )
                );
        }
    }
}
