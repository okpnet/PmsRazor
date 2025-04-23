using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore
{
    public static class ClassDefine
    {
        public const string SIZE_MINI = "is-small";
        public const string SIZE_NORMAL = "is-normal";
        public const string SIZE_MEDIUM = "is-medium";
        public const string PRIMARY = "is-primary";
        public const string SHOW_ACTIVE = "is-active";

        public static class Modal
        {
            public static string SHOW_ACTIVE => ClassDefine.SHOW_ACTIVE;
        }
        public static class Button
        {
            public static string SIZE_MINI => ClassDefine.SIZE_MINI;
            public static string SIZE_NORMAL => ClassDefine.SIZE_NORMAL;
            public static string SIZE_MEDIUM => ClassDefine.SIZE_MEDIUM;
            public static string PRIMARY=>ClassDefine.PRIMARY;
            public static string SECONDARY => $"{ClassDefine.PRIMARY} is-outlined";

            public static string TERTIARY=> $"is-text";

        }
    }
}
