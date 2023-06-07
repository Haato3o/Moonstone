using Moonstone.UI.Observable;
using System;
using System.Windows.Controls;

namespace Moonstone.UI.Presentation;

public class View<T> : UserControl where T : ViewModel
{
    public T ViewModel = Activator.CreateInstance<T>();

    public View()
    {
        DataContext = ViewModel;
    }
}