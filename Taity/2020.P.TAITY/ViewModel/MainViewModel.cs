using _2020.P.TAITY.View;
using System;
using System.Windows;
using System.Windows.Input;

namespace _2020.P.TAITY.ViewModel
{
    /// <summary>
    /// Класс, наследуемый от базовой модели
    /// Описывает окно загрузки программы
    /// </summary>
    class MainViewModel : BaseViewModel
    {
        /// <summary>
        /// Метод завершения работы программы
        /// </summary>
        public ICommand ShutdownCommand { get; set; }

        /// <summary>
        /// Конструктор класса наследуемого от базовой модели
        /// Описывает команды для интрфейса и дочерних объектов
        /// </summary>
        public MainViewModel()
        {
            
        }
    }
}