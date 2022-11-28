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
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AjoutProjet : Page
    {
        string date = "";
        bool erreur = false;

        public AjoutProjet()
        {
            this.InitializeComponent();
        }

        private void date_DateChanged(CalendarDatePicker sender, CalendarDatePickerDateChangedEventArgs args)
        {
            date = calendar.Date.Value.ToString("dddd dd MMMM");
        }

        private void btAjoutProjet_Click(object sender, RoutedEventArgs e)
        {
            // ERREUR CHAMPS VIDE
            if (TbBudget.Text == "" || TbDescription.Text == "" || TbEmploye.Text == "" || TbNumero.Text == "")
            {
                erreurTot.Visibility = Visibility.Visible;
                erreurTot.Text = "Vous devez remplir tous les champs";

                erreur = true;
            }
            else
            {
                // ERRUER BUDGET
                if (TbBudget. == typeof(int))
                {
                    erreur = false;

                    erreurBud.Visibility = Visibility.Collapsed;

                    if (Convert.ToInt32(TbBudget.Text) < 10000 || Convert.ToInt32(TbBudget.Text) > 100000)
                    {
                        erreurBud.Visibility = Visibility.Visible;
                        erreurBud.Text = "Le budget doit être entre 10 000$ et 100 000$";

                        erreur = true;
                    }
                    else
                    {
                        erreurBud.Visibility = Visibility.Collapsed;

                        erreur = false;
                    }
                }
                else
                {
                    erreurBud.Visibility = Visibility.Visible;
                    erreurBud.Text = "Seulement les chiffres sont acceptés";

                    erreur = true;
                }


                // ERREUR NUMERO
                if (TbNumero.Text.Length > 14)
                {
                    erreurNum.Visibility = Visibility.Visible;
                    erreurNum.Text = "Le numéro doit contenir 14 caractères maximum";

                    erreur = true;
                }
                else
                {
                    erreurNum.Visibility = Visibility.Collapsed;

                    erreur = false;
                }

                erreurTot.Visibility = Visibility.Collapsed;

                erreur = false;
            }

            if(erreur = false)
            {
                GestionBD.getInstance().AjouterProjet(new Projet(TbNumero.Text, date, Convert.ToInt32(TbBudget.Text), TbDescription.Text, Convert.ToInt32(TbEmploye.Text)));

                this.Frame.Navigate(typeof(Afficher));
            }

        }
    }
}
