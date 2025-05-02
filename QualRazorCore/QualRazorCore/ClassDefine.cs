using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QualRazorCore
{
    public static class ClassDefine
    {
        public const string SIZE_MINI = "is-small";
        public const string SIZE_NORMAL = "is-normal";
        public const string SIZE_MEDIUM = "is-medium";
        public const string PRIMARY = "is-primary";
        public const string LINK = "is-link";
        public const string SHOW_ACTIVE = "is-active";
        public const string INFO_SUCCESS = "is-success";
        public const string INFO_WARNING = "is-warning";
        public const string INFO_DANGER = "is-danger";
        public const string STYLE_FLEX = "is-flex";
        public const string STYLE_FLEX_DESKTOP = "is-flex-deskto";
        public const string STYLE_JUSTFY_CONTENT_SPACE_BETWEEN = $"is-justify-content-space-between";
        public const string STYLE_FLEX_WWRAP = "is-flex-wrap-wrap";
        public const string STYLE_ITEM_CENTER = "is-align-items-center";
        public const string STYLE_FULLWIDTH = "is-fullwidth";
        public const string STYLE_TO_HIDDEN_MOBILE = "is-hidden-touch";
        public const string STYLE_TO_HIDDEN_DESKTOP = "is-hidden-desktop";
        public const string STYLE_FLEX_ALIGNITEMSEND = "is-align-items-flex-end";
        public const string STYLE_FLEX_DIRECTION_COLUMN_TOUCH="is-flex-direction-column-touch";
        public const string MARGIN_ALL = "m-2";

        public const string TEXT_GREY = "has-text-grey";
        public const string TEXT_LEFT = "has-text-left";
        public const string TEXT_RIGHT = "has-text-right";
        public const string TEXT_CENTER = "has-text-center";

        public const string BUTTON = "button";
        public const string BUTTONS = "buttons";
        public const string TEXT_BUTTON = "is-text";
        public const string OUTLINE_BUTTON = "is-outlined";

        public const string TABLE="table";
        public const string TABLE_ROW_HOVER = "is-hoverable";

        public const string TYPE_ICON = "icon";
        public static class Text
        {
            public static string LEFT =>TEXT_LEFT;
            public static string RIGHT =>TEXT_RIGHT;
            public static string CENTER => TEXT_CENTER;
        }

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
            public static string SECONDARY => $"{ClassDefine.PRIMARY} {OUTLINE_BUTTON}";

            public static string TERTIARY=> TEXT_BUTTON;

            public static string MOBILE => $"{STYLE_FULLWIDTH} {STYLE_TO_HIDDEN_DESKTOP}";
            public static string DESCTOP => $"{STYLE_TO_HIDDEN_MOBILE}";

            public static string STYLE => BUTTON;
        }

        public static class Message
        {
            public static string MESSAGE_SUCCESS => INFO_SUCCESS;

            public static string MESSAGE_WARNING => INFO_WARNING;

            public static string MESSAGE_DANGER => INFO_DANGER;
        }

        public static class Table
        {
            public static string STYLE => $"{TABLE} {STYLE_FULLWIDTH} {TABLE_ROW_HOVER}";

            public static string SORT_COLUMN => $"{STYLE_FLEX} {STYLE_ITEM_CENTER}";

            public static string INFORMATION => $"{STYLE_FLEX_DESKTOP} {STYLE_JUSTFY_CONTENT_SPACE_BETWEEN} {STYLE_ITEM_CENTER} {STYLE_FLEX_WWRAP}";

            public static string PAGE_BUTTON_GROUP => $"{BUTTONS} {STYLE_FLEX} {STYLE_FLEX_ALIGNITEMSEND} {STYLE_FLEX_DIRECTION_COLUMN_TOUCH}";

            public static string PAGE_BUTTON => $"{BUTTON} {SIZE_MINI}";

            public static string PAGE_CURRENT_BUTTON => $"{BUTTON} {SIZE_MINI} {LINK}";
        }
    }
}
