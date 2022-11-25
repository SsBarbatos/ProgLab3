﻿using Microsoft.UI.Xaml;
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
            GestionBD.getInstance().AjouterProjet(new Projet(TbNumero.Text, date, Convert.ToInt32(TbBudget.Text), TbDescription.Text, TbEmploye.Text));

            this.Frame.Navigate(typeof(Afficher));
        }
    }
}
