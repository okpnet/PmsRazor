using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualRazorCore.Core
{
    public class AppConfig:NotifyCore
    {
        protected int _numberOfPagenationFromBetween=5;
        public int NumberOfPagenationFromBetween 
        {
            get => _numberOfPagenationFromBetween;
            set
            {
                if (_numberOfPagenationFromBetween == value)
                {
                    return;
                }
                _numberOfPagenationFromBetween = value;
                OnPropertyChanged(nameof(NumberOfPagenationFromBetween));
            }
        }

        protected int _numberOfRecordsThatCanRetrieved;
        public int NumberOfRecordsThatCanRetrieved
        {
            get => _numberOfRecordsThatCanRetrieved;
            set
            {
                if( _numberOfRecordsThatCanRetrieved == value)
                {
                    return;
                }
                _numberOfRecordsThatCanRetrieved = value;
                OnPropertyChanged(nameof(_numberOfRecordsThatCanRetrieved));
            }
        }
    }
}
