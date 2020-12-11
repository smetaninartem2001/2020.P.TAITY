using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace _2020.P.TAITY.ViewModel
{
    /// <summary>
    /// Базовая модель, наследуемая от класса фиксации изменений свойств объектов
    /// </summary>
    class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения свойств объектов фокна
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Событие искусственного вызова события изменения свойств объектов окна или самого окна
        /// </summary>
        /// <param name="prop"></param>
        protected void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}