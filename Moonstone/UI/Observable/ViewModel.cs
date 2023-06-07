using System.Windows;
using System.Windows.Threading;

namespace Moonstone.UI.Observable;

public class ViewModel : Bindable
{
    protected Dispatcher Dispatcher => Application.Current.Dispatcher;
}
