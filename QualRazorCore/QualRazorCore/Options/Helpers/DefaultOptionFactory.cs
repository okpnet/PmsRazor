
using QualRazorCore.Options.Defaults;

namespace QualRazorCore.Options.Helpers
{
    public class DefaultOptionFactory : IOptionFactory
    {
        public IOption? CreateFromProperty(Type targetType)
        {
            if (targetType == typeof(int))
            {
                return new NumberOption<int>(string.Empty, true, 0, null, null);
            }
            if (targetType == typeof(double))
            {
                return new NumberOption<double>(string.Empty,false,1,null,null);
            }
            if (targetType == typeof(decimal))
            {
                return new NumberOption<decimal>(string.Empty, true, 1, null, null);
            }
            if (targetType == typeof(bool))
            {
                return new BoolOption<bool>();
            }
            if (targetType == typeof(DateTime))
            {
                return new DateTimeOption(string.Empty,false,Microsoft.AspNetCore.Components.Forms.InputDateType.Date,null);
            }
            if (targetType == typeof(TimeSpan))
            {
                return new TimespanOption(string.Empty,false,0,null,BlazorCustomInput.Components.Unit.Hour);
            }
            if (targetType == typeof(string))
            {
                return new StringOption(string.Empty,false);
            }

            return null;
        }

        public IOption? CreateFromOption<TOption>() where TOption : IOption,new() => new TOption();

    }
}
