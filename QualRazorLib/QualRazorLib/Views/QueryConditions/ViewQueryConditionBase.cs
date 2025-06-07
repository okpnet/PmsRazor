using QualRazorLib.Presentation.Facades;

namespace QualRazorLib.Views.QueryConditions
{
    public abstract class ViewQueryConditionBase<T> : IViewQueryCondition<T> where T : class
    {
        public IReadOnlyList<IValueFilter> ValueFilters => throw new NotImplementedException();

        public abstract T Extract();

        public abstract void RestoreFrom(T condition);
    }
}
