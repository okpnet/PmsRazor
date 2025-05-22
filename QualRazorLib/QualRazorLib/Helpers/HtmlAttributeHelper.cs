namespace QualRazorLib.Helpers
{
    /// <summary>
    /// HTML 属性に関するユーティリティ関数を提供します。
    /// 特に、Blazor コンポーネントで <c>@attributes</c> を使用する際の属性マージ処理を補助します。
    /// </summary>
    public static class HtmlAttributeHelper
    {
        /// <summary>
        /// 渡された属性に対して class 属性をマージします。
        /// class 属性がすでに存在する場合は、その先頭に defaultClassName を追加します。
        /// defaultClassName が null または空の場合、追加処理は行いません。
        /// </summary>
        public static Dictionary<string, object> MergeClass(Dictionary<string, object>? originalAttributes, string? defaultClassName = null)
        {
            var result = MergeAttribute(originalAttributes, "class", defaultClassName);
            return result;
        }
        public static Dictionary<string, object> MergeStyle(Dictionary<string, object>? originalAttributes, string? defaultClassName = null)
        {
            var result = MergeAttribute(originalAttributes, "style", defaultClassName);
            return result;
        }
        /// <summary>
        /// 複数の属性（キーと値）をまとめてマージします。
        /// 各属性について、既存の値がある場合は defaultValues 側の値を先頭に追加します（スペース区切り）。
        /// </summary>
        /// <param name="originalAttributes">元の属性辞書。null の場合は空の辞書として処理されます。</param>
        /// <param name="defaultValues">追加したい属性のキーと値。null や空文字列の値は無視されます。</param>
        /// <returns>複数属性をマージした新しい属性辞書。</returns>
        public static Dictionary<string, object> MergeAttributes(Dictionary<string, object>? originalAttributes, Dictionary<string, object>? defaultValues)
        {
            var result = new Dictionary<string, object>(originalAttributes ?? new());

            if (defaultValues is null)
            {
                return result;
            }

            foreach (var kvp in defaultValues)
            {
                var key = kvp.Key;
                var value = kvp.Value;

                if (string.IsNullOrWhiteSpace(key) || value is null)
                {
                    continue;
                }

                if (result.TryGetValue(key, out var existingObj)
                    && value is string newStr
                    && existingObj is string existingStr)
                {
                    result[key] = $"{newStr} {existingStr}".Trim();
                }
                else
                {
                    result[key] = value;
                }
            }

            return result;
        }

        public static Dictionary<string, object> MergeValuePairAttributes(Dictionary<string, object>? originalAttributes, params KeyValuePair<string, object>[] valuePairs)
        {
            var result = new Dictionary<string, object>(originalAttributes ?? new());

            if (valuePairs is null)
            {
                return result;
            }

            foreach (var kvp in valuePairs)
            {
                var key = kvp.Key;
                var value = kvp.Value;

                if (string.IsNullOrWhiteSpace(key) || value is null)
                {
                    continue;
                }

                if (result.TryGetValue(key, out var existingObj)
                    && value is string newStr
                    && existingObj is string existingStr)
                {
                    result[key] = $"{newStr} {existingStr}".Trim();
                }
                else
                {
                    result[key] = value;
                }
            }

            return result;
        }

        /// <summary>
        /// 複数の属性（キーと値）をオリジナルに存在するときパージします。
        /// 各属性について、既存の値がある場合は defaultValues 側の値を先頭に追加します（スペース区切り）。
        /// </summary>
        /// <param name="originalAttributes">元の属性辞書。null の場合は空の辞書として処理されます。</param>
        /// <param name="defaultValues">追加したい属性のキーと値。null や空文字列の値は無視されます。</param>
        /// <returns>標準属性をパージして合成した新しい属性辞書。</returns>
        public static Dictionary<string, object> PurgeAttributes(Dictionary<string, object>? originalAttributes, Dictionary<string, object>? defaultValues)
        {
            var result = new Dictionary<string, object>(originalAttributes ?? new());

            if (defaultValues is null)
            {
                return result;
            }

            foreach (var kvp in defaultValues)
            {
                var key = kvp.Key;
                var value = kvp.Value;

                if (string.IsNullOrWhiteSpace(key) || value is null)
                {
                    continue;
                }

                if (!result.ContainsKey(key))
                {
                    result[key] = value;
                }
            }

            return result;
        }
        /// <summary>
        /// 任意の属性キーに対して値をマージします。
        /// 既存の値がある場合は先頭に defaultValue を追加します（スペース区切り）。
        /// defaultValue が null または空の場合、何も変更せず返します。
        /// </summary>
        /// <param name="originalAttributes">元の属性辞書。null の場合は空の辞書として処理されます。</param>
        /// <param name="attributeKey">マージ対象の属性キー（例: "class", "style" など）。</param>
        /// <param name="defaultValue">先頭に追加したい属性値。</param>
        /// <returns>属性がマージされた新しい属性辞書。</returns>
        private static Dictionary<string, object> MergeAttribute(Dictionary<string, object>? originalAttributes, string attributeKey, string? defaultValue)
        {
            var result = new Dictionary<string, object>(originalAttributes ?? new());

            if (string.IsNullOrWhiteSpace(defaultValue) || string.IsNullOrWhiteSpace(attributeKey))
            {
                return result;
            }

            if (result.TryGetValue(attributeKey, out var existingObj)
                && existingObj is string existingStr)
            {
                result[attributeKey] = $"{defaultValue} {existingStr}".Trim();
            }
            else
            {
                result[attributeKey] = defaultValue;
            }

            return result;
        }
    }
}
