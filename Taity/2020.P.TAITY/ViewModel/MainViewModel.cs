using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using _2020.P.TAITY.Interfaces;
using _2020.P.TAITY.Service;
using _2020.P.TAITY.Services;

namespace _2020.P.TAITY.ViewModel
{
    /// <summary>
    /// Класс, наследуемый от базовой модели
    /// Описывает окно загрузки программы
    /// </summary>
    class MainViewModel : BaseViewModel
    {

        //---------------------------------------------------------------------------------
        //---ОБЛАСТЬ ПУБЛИЧНЫХ КОНСТАНТ----------------------------------------------------
        //---------------------------------------------------------------------------------
        #region Public Constants

        public static readonly string PageSettingsViewModelAlias = "PageSettingsVM";

        public static readonly string NotFoundPageViewModelAlias = "404VM";

        #endregion



        //---------------------------------------------------------------------------------
        //---ОБЛАСТЬ ПРИВАТНЫХ ПОЛЕЙ-------------------------------------------------------
        //---------------------------------------------------------------------------------
        #region Private Fields

        private readonly IViewModelsResolver _resolver;

        private ICommand _goToPageSettingsCommand;

        private readonly INotifyPropertyChanged _pSettingsViewModel;

        private WindowState _curWindowState;

        private object _pageContent;

        #endregion


        //---------------------------------------------------------------------------------
        //---ОБЛАСТЬ ОБЪЯВЛЕНИЯ КОМАНД-----------------------------------------------------
        //---------------------------------------------------------------------------------
        #region Properties


        /// <summary>
        /// Команда завершения работы программы
        /// </summary>
        public ICommand Shutdown { get; set; }

        /// <summary>
        /// Команда коллапсирования окна программы
        /// </summary>
        public ICommand Minimize { get; set; }

        /// <summary>
        /// Команда развертывания окна программы
        /// </summary>
        public ICommand Maximize { get; set; }

        /// <summary>
        /// Команда подгрузки страницы настроек
        /// </summary>
        public ICommand GoToPageSettingsCommand
        {
            get { return _goToPageSettingsCommand; }
            set
            {
                _goToPageSettingsCommand = value;
                OnPropertyChanged("GoToPageSettingsCommand");
            }
        }

        #endregion


        //---------------------------------------------------------------------------------
        //---ОБЛАСТЬ КОНТРУКТОРА СЛАССА И ДЕЛЕГИРОВАНИЯ------------------------------------
        //---------------------------------------------------------------------------------



        /// <summary>
        /// Конструктор класса наследуемого от базовой модели
        /// Описывает команды для интрфейса и дочерних объектов
        /// </summary>
        public MainViewModel(IViewModelsResolver resolver)
        {
            _resolver = resolver;

            Shutdown = new DelegateCommand(delegate
            {
                if(System.Windows.Forms.MessageBox.Show("Вы уверены, что хотите завершить работу приложения?", "Внимание", MessageBoxButtons.YesNo).Equals(DialogResult.Yes))
                    Environment.Exit(1);
            });

            Minimize = new DelegateCommand(delegate
            {
                CurWindowState = WindowState.Minimized;
            });

            Maximize = new DelegateCommand(delegate
            {
                if (!CurWindowState.Equals(WindowState.Maximized))
                    CurWindowState = WindowState.Maximized;
                else
                    CurWindowState = WindowState.Normal;
            });

            _pSettingsViewModel = _resolver.GetViewModelInstance(PageSettingsViewModelAlias);

            InitializeCommands();
        }


        private void InitializeCommands()
        {

            GoToPageSettingsCommand = new DelegateCommand(delegate {
                Navigation.Navigate(Navigation.PageSettingsAlias, PageSettingsViewModelAlias);
            });
        }


        //---------------------------------------------------------------------------------
        //---ОБЛАСТЬ РЕГИСТРАЦИИ ИЗМЕНЕНИЯ ДАННЫХ------------------------------------------
        //---------------------------------------------------------------------------------



        /// <summary>
        /// МЕТОД РЕГИСТРАЦИИ ИЗМЕНЕНИЯ СОСТОЯНИЯ ОКНА
        /// </summary>
        public WindowState CurWindowState
        {
            get { return _curWindowState; }
            set { _curWindowState = value; OnPropertyChanged("CurWindowState"); }
        }

        /// <summary>
        /// МЕТОД РЕГИСТРАЦИИ ИЗМЕНЕНИЯ СОСТОЯНИЯ ОКНА
        /// </summary>
        public object PageContent
        {
            get { return _pageContent; }
            set { _pageContent = value; OnPropertyChanged("PageContent"); }
        }
    }
}