﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Helpers
{
    public static class CssClasses
    {
        public static string HIDDEN => "is-hidden";
        public static string SIZE_MINI => "is-small";
        public static string SIZE_NORMAL => "is-normal";
        public static string SIZE_MEDIUM => "is-medium";
        public static string PRIMARY => "is-primary";
        public static string LINK => "is-link";
        public static string SHOW_ACTIVE => "is-active";
        public static string INFO_SUCCESS => "is-success";
        public static string INFO_WARNING => "is-warning";
        public static string INFO_DANGER => "is-danger";
        public static string STYLE_FLEX => "is-flex";
        public static string STYLE_FLEX_DESKTOP => "is-flex-deskto";
        public static string STYLE_JUSTFY_CONTENT_SPACE_BETWEEN => $"is-justify-content-space-between";
        public static string STYLE_FLEX_WWRAP => "is-flex-wrap-wrap";
        public static string STYLE_ITEM_CENTER => "is-align-items-center";
        public static string STYLE_FULLWIDTH => "is-fullwidth";
        public static string STYLE_TO_HIDDEN_MOBILE => "is-hidden-touch";
        public static string STYLE_TO_HIDDEN_DESKTOP => "is-hidden-desktop";
        public static string STYLE_FLEX_ALIGNITEMSEND => "is-align-items-flex-end";
        public static string STYLE_FLEX_DIRECTION_COLUMN_TOUCH => "is-flex-direction-column-touch";
        public static string MARGIN_ALL => "m-2";

        public static string TEXT_GREY => "has-text-grey";
        public static string TEXT_LEFT => "has-text-left";
        public static string TEXT_RIGHT => "has-text-right";
        public static string TEXT_CENTER => "has-text-center";

        public static string BUTTON => "button";
        public static string BUTTONS => "buttons";
        public static string TEXT_BUTTON => "is-text";
        public static string OUTLINE_BUTTON => "is-outlined";

        public static string TABLE => "table";
        public static string TABLE_ROW_HOVER => "is-hoverable";

        public static string TYPE_ICON => "icon";
        public static class Text
        {
            public static string LEFT => TEXT_LEFT;
            public static string RIGHT => TEXT_RIGHT;
            public static string CENTER => TEXT_CENTER;
        }

        public static class Modal
        {
            public static string SHOW_ACTIVE => CssClasses.SHOW_ACTIVE;
        }
        public static class Button
        {
            public static string SIZE_MINI => CssClasses.SIZE_MINI;
            public static string SIZE_NORMAL => CssClasses.SIZE_NORMAL;
            public static string SIZE_MEDIUM => CssClasses.SIZE_MEDIUM;
            public static string PRIMARY => CssClasses.PRIMARY;
            public static string SECONDARY => $"{CssClasses.PRIMARY} {OUTLINE_BUTTON}";

            public static string TERTIARY => TEXT_BUTTON;

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
            public static string TABLE_CONTENT => $"{TABLE} {TABLE_ROW_HOVER} {STYLE_FULLWIDTH}";

            public static string SORT_COLUMN => $"{STYLE_FLEX} {STYLE_ITEM_CENTER}";

            public static string INFORMATION => $"{STYLE_FLEX_DESKTOP} {STYLE_JUSTFY_CONTENT_SPACE_BETWEEN} {STYLE_ITEM_CENTER} {STYLE_FLEX_WWRAP}";

            public static string PAGE_BUTTON_GROUP => $"{BUTTONS} {STYLE_FLEX} {STYLE_FLEX_ALIGNITEMSEND} {STYLE_FLEX_DIRECTION_COLUMN_TOUCH}";

            public static string PAGE_BUTTON => $"{BUTTON} {SIZE_MINI}";

            public static string PAGE_CURRENT_BUTTON => $"{BUTTON} {SIZE_MINI} {LINK}";
        }
    }
}
