using System.Collections.ObjectModel;

namespace QualRazorLib.Providers.Fields
{
    [Flags]
    public enum FieldDataType : byte
    {
        None = 0,
        Text = 1 << 0,
        Number = 1 << 1,
        Check = 1 << 2,
        Date = 1 << 3,
        TiemSpan = 1 << 4,
        Select = 1 << 5,
    }

    public static class FieldDataTypeHelper
    {
        private static Dictionary<Type, FieldDataType> _types = new()
        {
            [typeof(byte)] = FieldDataType.Number,
            [typeof(short)] = FieldDataType.Number,
            [typeof(int)] = FieldDataType.Number,
            [typeof(float)] = FieldDataType.Number,
            [typeof(double)] = FieldDataType.Number,
            [typeof(decimal)] = FieldDataType.Number,
            [typeof(bool)] = FieldDataType.Check,
            [typeof(DateTime)] = FieldDataType.Date,
            [typeof(TimeSpan)] = FieldDataType.TiemSpan,
            [typeof(string)] = FieldDataType.Text,
        };

        public static FieldDataType? GetFieldType(Type type)
        {
            Type underlying = Nullable.GetUnderlyingType(type) ?? type;
            if (_types.TryGetValue(underlying, out FieldDataType result))
            {
                return result;
            }
            return FieldDataType.None;
        }
    }
}
