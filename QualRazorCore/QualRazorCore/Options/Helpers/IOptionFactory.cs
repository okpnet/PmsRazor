namespace QualRazorCore.Options.Helpers
{
    public interface IOptionFactory
    {
        /// <summary>
        /// 指定された型に応じた OptionBase インスタンスを生成します。
        /// サポートされていない型に対しては例外を投げるか null を返します。
        /// </summary>
        /// <param name="targetType">対象のプロパティ型</param>
        /// <returns>生成された OptionBase</returns>
        IOption? Create(Type targetType);

        IOption? Create<TOption>() where TOption:IOption,new(); 
    }
}
