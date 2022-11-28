using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class GestionBD
    {
        MySqlConnection con;
        ObservableCollection<Employe> listeEmp;
        ObservableCollection<Projet> listePro;

        static GestionBD gestionBD = null;

        public GestionBD()
        {
            con = new MySqlConnection("Server=localhost;Database=bdlab3;Uid=root;Pwd=root");
            listeEmp = new ObservableCollection<Employe>();
            listePro = new ObservableCollection<Projet>();
        }

        public static GestionBD getInstance()
        {
            if(gestionBD == null)
                gestionBD = new GestionBD();
            
            return gestionBD;
        }

        public ObservableCollection<Employe> GetEmployes()
        {
            listeEmp.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT * FROM employe";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while(r.Read())
            {
                Employe employe = new Employe()
                {
                    Matricule = r.GetInt32("matricule"),
                    Nom = r.GetString("nom"),
                    Prenom = r.GetString("prenom")
                };

                listeEmp.Add(employe);
            }

            r.Close();
            con.Close();

            return listeEmp;
        }

        public void AjouterEmploye(Employe employe)
        {
            int matricule = employe.Matricule;
            string nom = employe.Nom;
            string prenom = employe.Prenom;

            try 
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "INSERT INTO employe VALUES(@matricule, @nom, @prenom)";

                commande.Parameters.AddWithValue("@matricule", matricule);
                commande.Parameters.AddWithValue("@nom", nom);
                commande.Parameters.AddWithValue("@prenom", prenom);

                con.Open();
                commande.Prepare();
                int i = commande.ExecuteNonQuery();

                con.Close();
            }
            catch(MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }

        public ObservableCollection<Projet> GetProjet()
        {
            listePro.Clear();

            MySqlCommand commande = new MySqlCommand();
            commande.Connection = con;
            commande.CommandText = "SELECT * FROM projet";

            con.Open();
            MySqlDataReader r = commande.ExecuteReader();

            while (r.Read())
            {
                Projet projet = new Projet()
                {
                    Numero = r.GetString("numero"),
                    Debut = r.GetString("debut"),
                    Budget = r.GetInt32("budget"),
                    Description = r.GetString("description"),
                    Employe = r.GetInt32("employe")
                };

                listePro.Add(projet);
            }

            r.Close();
            con.Close();

            return listePro;
        }

        public void AjouterProjet(Projet projet)
        {
            string numero = projet.Numero;
            string debut = projet.Debut;
            int budget = projet.Budget;
            string description = projet.Description;
            int employe = projet.Employe;

            try
            {
                MySqlCommand commande = new MySqlCommand();
                commande.Connection = con;
                commande.CommandText = "INSERT INTO projet VALUES(@numero, @debut, @budget, @description, @employe)";

                commande.Parameters.AddWithValue("@numero", numero);
                commande.Parameters.AddWithValue("@debut", debut);
                commande.Parameters.AddWithValue("@budget", budget);
                commande.Parameters.AddWithValue("@description", description);
                commande.Parameters.AddWithValue("@employe", employe);

                con.Open();
                    commande.Prepare();
                    int i = commande.ExecuteNonQuery();
                con.Close();
            }
            catch (MySqlException ex)
            {
                if (con.State == System.Data.ConnectionState.Open)
                    con.Close();
            }
        }
    }
}
