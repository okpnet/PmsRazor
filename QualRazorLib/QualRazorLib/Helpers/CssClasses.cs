namespace QualRazorLib.Helpers
{
    public static class CssClasses
    {
        public static string BUTTON => "button";
        public static string BUTTONS => "buttons";
        public static string HIDDEN => "is-hidden";
        public static string INFO_DANGER => "is-danger";
        public static string INFO_SUCCESS => "is-success";
        public static string INFO_WARNING => "is-warning";
        public static string LABEL => "label";
        public static string LINK => "is-link";
        public static string MARGIN_ALL => "m-2";
        public static string MODAL__TITLE => "modal-card-title";
        public static string MODAL_BACKGROUND => "modal-background";
        public static string MODAL_BODY => "modal-card-body";
        public static string MODAL_CARD => "modal-card";
        public static string MODAL_DELETEBUTTON => "delete";
        public static string MODAL_FOOT => "modal-card-foot";
        public static string MODAL_HEAD => "modal-card-head";
        public static string OUTLINE_BUTTON => "is-outlined";
        public static string PRIMARY => "is-primary";
        public static string SHOW_ACTIVE => "is-active";
        public static string SIZE_MEDIUM => "is-medium";
        public static string SIZE_MINI => "is-small";
        public static string SIZE_NORMAL => "is-normal";
        public static string STYLE_FLEX => "is-flex";
        public static string STYLE_FLEX_ALIGNITEMSEND => "is-align-items-flex-end";
        public static string STYLE_FLEX_DESKTOP => "is-flex-desktop";
        public static string STYLE_FLEX_DIRECTION_COLUMN_TOUCH => "is-flex-direction-column-touch";
        public static string STYLE_FLEX_WWRAP => "is-flex-wrap-wrap";
        public static string STYLE_FULLWIDTH => "is-fullwidth";
        public static string STYLE_ITEM_CENTER => "is-align-items-center";
        public static string STYLE_JUSTFY_CONTENT_SPACE_BETWEEN => $"is-justify-content-space-between";
        public static string STYLE_MODAL => "modal";
        public static string STYLE_TO_HIDDEN_DESKTOP => "is-hidden-desktop";
        public static string STYLE_TO_HIDDEN_MOBILE => "is-hidden-touch";
        public static string TABLE => "table";
        public static string TABLE_ROW_HOVER => "is-hoverable";
        public static string TEXT_BUTTON => "is-text";
        public static string TEXT_CENTER => "has-text-center";
        public static string TEXT_GREY => "has-text-grey";
        public static string TEXT_LEFT => "has-text-left";
        public static string TEXT_RIGHT => "has-text-right";
        public static string TEXT_THIN_THICKNESS => "has-text-weight-light";
        public static string TEXT_SEMIBOLD_THICKNESS => "has-text-weight-semibold";
        public static string TEXT_BOLD_THICKNESS => "has-text-weight-bold";
        public static string TEXT_SIZE_1 => "is-size-1";
        public static string TEXT_SIZE_2 => "is-size-2";
        public static string TEXT_SIZE_3 => "is-size-3";
        public static string TEXT_SIZE_4 => "is-size-4";
        public static string TEXT_SIZE_5 => "is-size-5";
        public static string TEXT_SIZE_6 => "is-size-6";
        public static string TEXT_SIZE_7 => "is-size-7";


        public static string TYPE_ICON => "icon";
        public static string TYPE_SELECTED => "is-selected";
        public static string FIELD => "field";
        public static string CONTROL => "control";
        public static string FIELD_CHECKBOX => "checkbox";
        public static string FIELD_RADIO => "radio";

        public static string FIELD_IS_GROUPED => "is-grouped";
        public static string FIELD_IS_GROUPED_MULTILINE => "is-grouped-multiline";

        public static string COLUMNS => "columns";

        public static string COLUMN => "column";
        public static string COLUMN_HALF => "is-half";

        public static  string COLUMN_FULL => "is-full";
        public static string DESKTOP => "is-desktop";

        public static string MULTILINE => "is-multilien";

        public static string COLUMN_PER15 => "is-2";
        public static string COLUMN_PER35 => "is-4";
        public static string COLUMN_PER65 => "is-8";
        public static string COLUMN_PER80 => "is-10";

        public static string LAYOUT_SECTION => "section";

        public static class ColumnGroup
        {
            public static string DESKTOP_GROUP => $"{COLUMNS} {DESKTOP}";
            public static string HALF=>$"{COLUMN} {COLUMN_HALF}";
            public static string FULL => $"{COLUMN} {COLUMN_FULL}";

            public static string MULTILINE_DESKTOP_GROUP => $"{DESKTOP_GROUP} {MULTILINE}";
        }

        public static class Text
        {
            public static string CENTER => TEXT_CENTER;
            public static string LEFT => TEXT_LEFT;
            public static string RIGHT => TEXT_RIGHT;
        }

        public static class Modal
        {
            public static string SHOW_ACTIVE => $"{STYLE_MODAL} {CssClasses.SHOW_ACTIVE}";
        }
        public static class Button
        {
            public static string DESCTOP => $"{BUTTON} {STYLE_TO_HIDDEN_MOBILE}";
            public static string MOBILE => $"{BUTTON} {STYLE_FULLWIDTH} {STYLE_TO_HIDDEN_DESKTOP}";
            public static string PRIMARY => CssClasses.PRIMARY;
            public static string SECONDARY => "";//default style buttons
            public static string SIZE_MEDIUM => CssClasses.SIZE_MEDIUM;
            public static string SIZE_MINI => CssClasses.SIZE_MINI;
            public static string SIZE_NORMAL => CssClasses.SIZE_NORMAL;
            public static string STYLE => BUTTON;
            public static string TERTIARY => TEXT_BUTTON;
        }

        public static class Message
        {
            public static string MESSAGE_DANGER => INFO_DANGER;
            public static string MESSAGE_SUCCESS => INFO_SUCCESS;
            public static string MESSAGE_WARNING => INFO_WARNING;
        }

        public static class Table
        {
            public static string INFORMATION => $"{STYLE_FLEX_DESKTOP} {STYLE_JUSTFY_CONTENT_SPACE_BETWEEN} {STYLE_ITEM_CENTER} {STYLE_FLEX_WWRAP}";
            public static string PAGE_BUTTON => $"{BUTTON} {SIZE_MINI}";
            public static string PAGE_BUTTON_GROUP => $"{BUTTONS} {STYLE_FLEX} {STYLE_FLEX_ALIGNITEMSEND} {STYLE_FLEX_DIRECTION_COLUMN_TOUCH}";
            public static string PAGE_CURRENT_BUTTON => $"{BUTTON} {SIZE_MINI} {LINK}";
            public static string ROW_SELECTED => $"{TYPE_SELECTED}";
            public static string SORT_COLUMN => $"{STYLE_FLEX} {STYLE_ITEM_CENTER}";
            public static string TABLE_CONTENT => $"{TABLE} {TABLE_ROW_HOVER} {STYLE_FULLWIDTH}";
        }

        public static class Field
        {
            public static string CHECKBOX => FIELD_CHECKBOX;

            public static string RADIO_GROUP => $"{FIELD} {FIELD_IS_GROUPED} {FIELD_IS_GROUPED_MULTILINE}";

        }
    }
}
