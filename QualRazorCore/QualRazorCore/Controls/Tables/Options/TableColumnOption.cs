using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using QualRazorCore.Controls.Tables.Columns.Core;
using QualRazorCore.Core;

namespace QualRazorCore.Controls.Tables.Options
{
    public class TableColumnOption:NotifyCore
    {
        protected Dictionary<string, object> _columnAdditionalAttributes = new();
        public Dictionary<string, object> ColumnAdditionalAttributes
        {
            get => _columnAdditionalAttributes;
            set
            {
                if (_columnAdditionalAttributes == value)
                {
                    return;
                }
                _columnAdditionalAttributes = value;
                OnPropertyChanged(nameof(ColumnAdditionalAttributes));
            }
        }

        public EventCallback<ITableColumn> ColumnClick { get; set; }  

        public RenderFragment<ITableColumn> ColumnContent { get; }

        public TableColumnOption()
        {
            ColumnContent = column => builder =>//デフォルトの列昇順表示
            {
                switch (column.SortStatus)
                {
                    case Filters.SortType.None:
                        builder.AddContent(0, (MarkupString)column.GetColumnNameInvoke());
                        break;
                    case Filters.SortType.ASC:
                    case Filters.SortType.DESC:
                        builder.OpenElement(1, "div");
                        builder.AddAttribute(2, "class", ClassDefine.Table.SORT_COLUMN);
                        builder.OpenElement(3, "span");
                        builder.AddContent(4, (MarkupString)column.GetColumnNameInvoke());
                        builder.CloseElement();//span
                        builder.OpenElement(5, "span");
                        builder.AddAttribute(6, "class", ClassDefine.TYPE_ICON);
                        builder.OpenElement(7, "i");
                        if (column.SortStatus == Filters.SortType.ASC)
                        {
                            builder.AddAttribute(6, "class", CssGGIconDefine.AscArrow);
                        }
                        else
                        {
                            builder.AddAttribute(6, "class", CssGGIconDefine.DescArrow);
                        }
                        builder.CloseElement();//i
                        builder.CloseElement();//span
                        builder.CloseElement();//div
                        break;
                }

            };
        }

        public TableColumnOption(Func<ITableColumn,RenderFragment> columnRender)
        {
            ColumnContent = column => columnRender(column);
        }

        public TableColumnOption(RenderFragment<ITableColumn> columnRender)
        {
            ColumnContent = columnRender;
        }
    }
}
