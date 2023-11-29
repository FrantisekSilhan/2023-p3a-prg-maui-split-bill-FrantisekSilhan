using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SplitBill1.ViewModels
{
    internal class BillViewModel : INotifyPropertyChanged
    {
        private int _billAmount;
        private int _tipValue;
        private int _people;
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
                OnPropertyChanged("BillAmountShare");
                OnPropertyChanged("BillAmountTipShare");
                OnPropertyChanged("TipAmount");
            }
        }
        public int TipValue
        {
            get
            {
                return _tipValue;
            }
            set
            {
                _tipValue = value;
                OnPropertyChanged();
                OnPropertyChanged("TipAmount");
                OnPropertyChanged("BillAmountTipShare");
                OnPropertyChanged("BillAmountShare");
                OnPropertyChanged("BillAmountTip");

            }
        }

        public int People
        {
            get
            {
                return _people;
            }
            set
            {
                _people = value;
                OnPropertyChanged();
                OnPropertyChanged("BillAmountShare");
                OnPropertyChanged("BillAmountTipShare");
            }
        }

        public int BillAmountShare
        {
            get
            {
                return BillAmount / People;
            }
        }

        public int TipAmount
        {
            get
            {
                return BillAmount * TipValue / 100;
            }
        }

        public int BillAmountTip
        {
            get
            {
                return BillAmount + TipAmount;
            }
        }

        public int BillAmountTipShare
        {
            get
            {
                return BillAmountTip / People;
            }
        }

        public Command AddPerson { get; set; }
        public Command RemovePerson { get; set; }

        public BillViewModel()
        {
            People = 1;
            AddPerson = new Command(
                () =>
                {
                    People++;
                }
            );

            RemovePerson = new Command(
                () =>
                {
                    if (People > 1)
                    {
                        People--;
                    }
                }
            );
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
