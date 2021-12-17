using System.Windows;
using System.Windows.Input;
using Kiryanov.WPF.MVVM.Core.ViewModel;

namespace rpks1.ViewModel
{
    internal sealed class MainWindowViewModel : ViewModelBase
    {
        private ICommand _curCommand;
        private bool _canExecute = true;

        public bool CanExecute
        {
            get =>
                _canExecute;

            private set
            {
                _canExecute = value;
                RaisePropertyChanged(nameof(CanExecute));
            }
        }
        
        private void Message()
        {
            MessageBox.Show("Welcome to the WPF club buddy!");
        }

        public ICommand DummyCommand =>
            _curCommand ??= new RelayCommand(_ => Message(), _ => CanExecute);
    }
}
