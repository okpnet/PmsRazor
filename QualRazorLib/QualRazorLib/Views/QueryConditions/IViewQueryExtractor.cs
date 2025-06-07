namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// Viewの状態から、Facadeへ渡す条件（例：DTOなど）を抽出する責務
    /// </summary>
    /// <typeparam name="TQuery">Facadeが受け取るクエリ条件型</typeparam>
    public interface IViewQueryExtractor<out TQuery>
    {
        /// <summary>
        /// View側の状態からFacade向けの条件を生成する
        /// </summary>
        TQuery Extract();
    }
}
