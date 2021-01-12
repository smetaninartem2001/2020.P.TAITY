using _2020.P.TAITY.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace _2020.P.TAITY.ViewModel
{
    public class ViewModelsResolver : IViewModelsResolver
    {

        private readonly Dictionary<string, Func<INotifyPropertyChanged>> _vmResolvers = new Dictionary<string, Func<INotifyPropertyChanged>>();

        public ViewModelsResolver()
        {
            _vmResolvers.Add(MainViewModel.PageSettingsViewModelAlias, () => new PageSettingsViewModel());
            _vmResolvers.Add(MainViewModel.PageСalculatorViewModelAlias, () => new PageСalculatorViewModel());
            _vmResolvers.Add(MainViewModel.NotFoundPageViewModelAlias, () => new Page404ViewModel());
        }

        public INotifyPropertyChanged GetViewModelInstance(string alias)
        {
            if (_vmResolvers.ContainsKey(alias))
            {
                return _vmResolvers[alias]();
            }

            return _vmResolvers[MainViewModel.NotFoundPageViewModelAlias]();
        }
    }
}
