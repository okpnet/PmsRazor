using QualRazorLib.Core;

namespace QualRazorLib.Controls.Tables.Rows.Dtos
{
    public interface IRowDataHolder
    {
        object BaseData { get; }
    }

    public interface IRowDataHolder<TModel>:IRowDataHolder,IDataHolder<TModel>
    {
        public RowStatus Status { get; }
        public int RowIndex { get; }
    }
}
