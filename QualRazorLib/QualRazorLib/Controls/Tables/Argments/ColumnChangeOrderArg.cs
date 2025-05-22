using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables.Argments
{
    public sealed class ColumnChangeOrderArg
    {
        public string PropertyName { get; }

        public SortType SortType { get; }

        public ColumnChangeOrderArg(string propertyName, SortType sortType)
        {
            PropertyName = propertyName;
            SortType = sortType;
        }
    }
}
