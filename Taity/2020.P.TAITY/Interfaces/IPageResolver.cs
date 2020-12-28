using System.Windows.Controls;

namespace _2020.P.TAITY.Interfaces
{
    public interface IPageResolver
    {
        Page GetPageInstance(string alias);
    }
}
