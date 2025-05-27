using QualRazorLib.Providers.Trees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorLib.Controls.Argments
{
    /// <summary>
    /// RenderFlagmentの引数
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class TreeNodeArg<T>
    {
        public T NodeModel { get; } = default!;
        public bool IsSelected { get; } = false;
        public int Level { get; }

        public TreeNodeArg(T nodeModel, bool isSelected, int level)
        {
            NodeModel = nodeModel;
            IsSelected = isSelected;
            Level = level;
        }

    }
}
