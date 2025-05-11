namespace QualRazorCore.Options.Core
{
    public interface IPropertyOption
    {
        public string PropertyName { get; }
    }
    public interface IPropertyOption<TModel, TResult>:IPropertyOption
    {
        public Action<TModel, TResult>? Setter { get; }

        public Func<TModel, TResult> Getter { get; }
    }
}
