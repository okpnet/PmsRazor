namespace QualRazorLib.Views.QueryConditions
{
    /// <summary>
    /// Facadeなどの外部から受け取ったクエリ条件（例: DTOなど）を
    /// View側の状態として復元する責務を担うインターフェイス
    /// </summary>
    public interface IViewQueryRestorer<TCondition>
    {
        /// <summary>
        /// 外部から渡された条件オブジェクトを使ってViewの状態を更新する
        /// FacadeからViewへ条件を復元する際に使用される。
        /// </summary>
        /// <param name="condition">Facadeの条件</param>
        void RestoreFrom(TCondition condition);
    }
}
