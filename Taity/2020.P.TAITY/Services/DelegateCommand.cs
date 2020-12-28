using System;
using System.Diagnostics;
using System.Windows.Input;

namespace _2020.P.TAITY.Service
{
    /// <summary>
    /// Делегирование команд для выполнения во внешней среде
    /// </summary>
    public class DelegateCommand : ICommand
    {


        #region Fields

        public Action<object> execute; //Передаваемое событие
        public Predicate<object> can_execute; //Возможность выполнения этого события

        #endregion

        #region Constructors

        /// <summary>
        /// Передача параметров во внутреннюю среду
        /// </summary>
        /// <param name="_execute">Событие</param>
        /// <param name="_can_Execute">Логическое значение выполнения события</param>
        public DelegateCommand(Action<object> _execute, Predicate<object> _can_Execute)
        {
            execute = _execute;
            can_execute = _can_Execute;
        }

        /// <summary>
        /// Расширение предаваемых в среду параметров
        /// </summary>
        /// <param name="_execute"></param>
        public DelegateCommand(Action<object> _execute) : this(_execute, null) { }

        #endregion


        #region ICommand Implementation

        /// <summary>
        /// Событие добавления или удаления метода из общего реестра команд при делегировании
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Метод возможности выполнения команды
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter)
        {
            return can_execute == null ? true : can_execute.Invoke(parameter);
        }

        /// <summary>
        /// Выполнение команды
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            execute.Invoke(parameter);
        }
        #endregion
    }
}