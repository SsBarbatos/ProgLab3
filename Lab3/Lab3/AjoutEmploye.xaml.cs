using Google.Protobuf.WellKnownTypes;
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
    public sealed partial class AjoutEmploye : Page
    {
        bool erreur = false;

        public AjoutEmploye()
        {
            this.InitializeComponent();
        }

        private void btAjoutEmploye_Click(object sender, RoutedEventArgs e)
        {
            // ERREUR CHAMPS VIDE
            if (TbMatricule.Text == "" || TbNom.Text == "" || TbPrenom.Text == "")
            {
                erreurTot.Visibility = Visibility.Visible;
                erreurTot.Text = "Vous devez remplir tous les champs";

                erreur = true;
            }
            else
            {
                // ERRUER MATRICULE
                if (TbMatricule.Text.Length > 7)
                {
                    erreur = true;

                    erreurMat.Visibility = Visibility.Visible;
                    erreurMat.Text = "Le matricule ne peut pas dépasser 7 chiffres";
                }
                else
                {
                    erreurMat.Visibility = Visibility.Collapsed;

                    erreur = false;
                }

                erreurTot.Visibility = Visibility.Collapsed;
            }


            if (erreur == false)
            {
                GestionBD.getInstance().AjouterEmploye(new Employe(Convert.ToInt32(TbMatricule.Text), TbNom.Text, TbPrenom.Text));

                this.Frame.Navigate(typeof(Afficher));
            }
        }
    }
}
