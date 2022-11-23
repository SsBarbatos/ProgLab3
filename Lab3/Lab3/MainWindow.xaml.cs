using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Lab3
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
        }

        private void NV_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
         {
             var item = (NavigationViewItem)args.SelectedItem;

             switch (item.Name)
             {
                 case "Afficher":
                     main.Navigate(typeof(Afficher));
                     break;
                 case "AjoutEmploye":
                     main.Navigate(typeof(AjoutEmploye));
                     break;
                 case "AjoutProjet":
                     main.Navigate(typeof(AjoutProjet));
                     break;
                 default:
                     break;
             }
         }

        private void NV_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if(main.CanGoBack)
                main.GoBack();
        }

        private void SearchBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            ContentDialog dialog = new ContentDialog();

            dialog.Content = SearchBox.Text;
            dialog.ShowAsync();
        }
    }
}

