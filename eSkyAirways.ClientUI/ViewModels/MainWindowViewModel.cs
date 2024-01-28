using System;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using eSkyAirways.ClientUI.Models;

namespace eSkyAirways.ClientUI.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    #region  Properties

    [ObservableProperty] 
    private ObservableCollection<PageModel> _pages = [];

    [ObservableProperty]
    private PageModel _selectedPage;

    [ObservableProperty] 
    private bool _paneOpen;

    [ObservableProperty] 
    private ViewModelBase _displayPage;
    
    #endregion
    #region Command

    partial void OnSelectedPageChanged(PageModel value)
    {
        if (Activator.CreateInstance(value.DataModelType) is ViewModelBase vm)
        {
            DisplayPage = vm;
        }
    }
    
    [RelayCommand]
    private void SwitchPane()
    {
        PaneOpen = !PaneOpen;
    }

    #endregion

    public MainWindowViewModel()
    {
        Pages =
        [
            new PageModel("Home", new HomeViewModel().GetType()),
        ];

        SelectedPage = Pages.First();
        PaneOpen = true;
    }

}
