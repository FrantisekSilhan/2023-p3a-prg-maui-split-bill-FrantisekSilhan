using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SplitBill1.ViewModels
{
    internal class BillViewModel : INotifyPropertyChanged
    {
        private int _billAmount;
        private int _tipAmount;

        public int BillAmount
        {
            get
            {
                return _billAmount;
            }
            set
            {
                _billAmount = value;
                OnPropertyChanged();
            }
        }
        public int TipAmount
        {
            get
            {
                return _tipAmount;
            }
            set
            {
                _tipAmount = value;
                OnPropertyChanged();
            }
        }

        #region MVVM
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion //MVVM
    }
}
