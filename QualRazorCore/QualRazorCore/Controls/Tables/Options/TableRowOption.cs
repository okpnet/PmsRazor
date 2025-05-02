using QualRazorCore.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Controls.Tables.Options
{
    public class TableRowOption:NotifyCore
    {
        protected Dictionary<string, object> _rowAdditionalAttributes = new();
        public Dictionary<string, object> RowAdditionalAttributes
        {
            get => _rowAdditionalAttributes;
            set
            {
                if (_rowAdditionalAttributes == value)
                {
                    return;
                }
                _rowAdditionalAttributes = value;
                OnPropertyChanged(nameof(RowAdditionalAttributes));
            }
        }
    }
}
