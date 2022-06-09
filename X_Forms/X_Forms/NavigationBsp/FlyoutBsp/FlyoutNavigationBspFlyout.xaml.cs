﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.NavigationBsp.FlyoutBsp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutNavigationBspFlyout : ContentPage
    {
        public ListView ListView;

        public FlyoutNavigationBspFlyout()
        {
            InitializeComponent();

            BindingContext = new FlyoutNavigationBspFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class FlyoutNavigationBspFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<FlyoutNavigationBspFlyoutMenuItem> MenuItems { get; set; }

            public FlyoutNavigationBspFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<FlyoutNavigationBspFlyoutMenuItem>(new[]
                {
                    new FlyoutNavigationBspFlyoutMenuItem { Id = 0, Title = "Hauptseite", TargetType=typeof(Hauptseite) },
                    new FlyoutNavigationBspFlyoutMenuItem { Id = 1, Title = "Tabbed", TargetType=typeof(NavigationBsp.TabbedPageBsp) },
                    new FlyoutNavigationBspFlyoutMenuItem { Id = 2, Title = "RelativeLayoutBsp", TargetType=typeof(Layouts.RelativeLayoutBsp) },
                    new FlyoutNavigationBspFlyoutMenuItem { Id = 3, Title = "PersonenDb", TargetType=typeof(PersonenDb.Nav.FlyoutMenue) },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}