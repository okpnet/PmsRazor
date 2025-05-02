using Microsoft.AspNetCore.Components;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Options
{
    public class TableCellOption:NotifyCore
    {
        protected Dictionary<string, object> _cellAdditionalAttributes = new();

        public Dictionary<string, object> CellAdditionalAttributes
        {
            get => _cellAdditionalAttributes;
            set
            {
                if (_cellAdditionalAttributes == value)
                {
                    return;
                }
                _cellAdditionalAttributes = value;
                OnPropertyChanged(nameof(CellAdditionalAttributes));
            }
        }

        public RenderFragment<string> CellContent{ get; }

        public TableCellOption()
        {
            CellContent = value => builder =>
            {
                builder.AddContent(1, (MarkupString)value);
            };
        }

        public TableCellOption(RenderFragment<string> renderFragment)
        {
            CellContent = renderFragment;
        }

        public TableCellOption(Func<string,RenderFragment> cellContentDelegate)
        {
            CellContent = value => cellContentDelegate(value);
        }
    }
}
