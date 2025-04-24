using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace QualRazorCore.Services
{
    /// <summary>
    /// ページクラスと@page属性を取得して、URLを提供するサービス
    /// </summary>
    public class PageNamedService
    {
        /// <summary>
        /// ページ名
        /// Key=クラス名
        /// Value=PageAttribute
        /// </summary>
        public IReadOnlyDictionary<string, string> PageNamed { get; }
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PageNamedService()
        {
            PageNamed = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t =>
                    t.Namespace is not null &&
                    t.CustomAttributes.Select(x => x.AttributeType).Any(x => x == typeof(RouteAttribute))
                    )
                .ToDictionary(key => key.Name ?? "", value =>
                 {
                     if (value.CustomAttributes.Where(x => x.AttributeType == typeof(RouteAttribute)).SelectMany(x => x.ConstructorArguments).FirstOrDefault().Value is string path)
                     {
                         return path;
                     }
                     return string.Empty;
                 });
        }
    }
}
