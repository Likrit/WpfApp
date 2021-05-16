using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.ViewModels.Base
{
    //Базовый класс модели представления
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}