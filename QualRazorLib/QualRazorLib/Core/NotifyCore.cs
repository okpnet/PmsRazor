using System.ComponentModel;

namespace QualRazorLib.Core
{
    /// <summary>
    /// INotifyPropertyChanged を実装したクラスの基底クラスです。
    /// </summary>
    public abstract class NotifyCore : INotifyPropertyChanged
    {
        /// <summary>
        /// プロパティが変更されたときに発生します。
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// プロパティが変更されたことを通知します。
        /// </summary>
        /// <param name="propertyName"></param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{ex.Message}===>{propertyName}");
            }
        }
    }
}
