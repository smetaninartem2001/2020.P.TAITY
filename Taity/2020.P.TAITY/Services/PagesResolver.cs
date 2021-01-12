using _2020.P.TAITY.Interfaces;
using _2020.P.TAITY.View.Pages;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace _2020.P.TAITY.Services
{
    public class PagesResolver : IPageResolver
    {

        private readonly Dictionary<string, Func<Page>> _pagesResolvers = new Dictionary<string, Func<Page>>();

        public PagesResolver()
        {
            _pagesResolvers.Add(Navigation.PageSettingsAlias, () => new Settings());
            _pagesResolvers.Add(Navigation.PageСalculatorAlias, () => new Calculator()); 
        }

        public Page GetPageInstance(string alias)
        {
            if (_pagesResolvers.ContainsKey(alias))
            {
                return _pagesResolvers[alias]();
            }

            return _pagesResolvers[Navigation.NotFoundPageAlias]();
        }
    }
}
