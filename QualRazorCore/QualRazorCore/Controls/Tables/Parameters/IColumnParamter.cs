using Microsoft.AspNetCore.Components;

namespace QualRazorCore.Controls.Tables.Parameters
{
    public interface IColumnParamter
    {
        string PropertyName { get; }

        RenderFragment? HeaderContent { get; }
    }
}
