using System.ComponentModel;

namespace _2020.P.TAITY.Interfaces
{
    public interface IViewModelsResolver
    {
        INotifyPropertyChanged GetViewModelInstance(string alias);
    }
}
