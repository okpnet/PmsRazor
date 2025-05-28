namespace QualRazorLib.Helpers
{
    public static class TreeStructureHelper
    {

        /// <summary>
        /// ツリー構造のノード配列から、指定条件に一致するノードを再帰的に探索します。
        /// </summary>
        /// <typeparam name="T">ノードの型</typeparam>
        /// <param name="targetItem">探索対象のノード</param>
        /// <param name="rootNodes">探索の起点となるノードの列挙</param>
        /// <param name="getChildNodes">子ノードを取得する関数</param>
        /// <param name="matchCondition">ノード同士の一致条件を判定する関数</param>
        /// <returns>一致するノード、または見つからなければ null</returns>

        public static T? FilndNodeItem<T>(T targetItem, IEnumerable<T> rootNodes, Func<T,IEnumerable<T>> getChildNodes,Func<T,T, bool> matchCondition)
        {
            foreach (var item in rootNodes)
            {
                var result= FildNodeItem(targetItem,getChildNodes,matchCondition);
                if(result is not null)
                {
                    return result;
                }
            }
            return default!;
        }

        /// <summary>
        /// ツリー構造のノード配列から、指定条件に一致するノードを再帰的に探索します。
        /// </summary>
        /// <typeparam name="T">ノードの型</typeparam>
        /// <param name="targetItem">探索対象のノード</param>
        /// <param name="getChildNodes">子ノードを取得する関数</param>
        /// <param name="matchCondition">ノード同士の一致条件を判定する関数</param>
        /// <returns>一致するノード、または見つからなければ null</returns>

        public static T? FildNodeItem<T>(T targetItem, Func<T, IEnumerable<T>> getChildNodes, Func< T, T, bool> matchCondition)
        {
            var array = getChildNodes(targetItem);
            if(array.FirstOrDefault(t=>matchCondition(t,targetItem)) is T value)
            {
                return value;
            }
            foreach(var item in array)
            {
                var result = FildNodeItem(item, getChildNodes, matchCondition);
                if(result is not null)
                {
                    return result;
                }
            }
            return default;
        }
    }
}
