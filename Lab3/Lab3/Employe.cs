using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Employe
    {

        int matricule;
        string nom;
        string prenom;

        public Employe()
        {
            matricule = 0;
            nom = "";
            prenom = "";
        }

        public Employe(int _matricule, string _nom, string _prenom)
        {
            matricule = _matricule;
            nom = _nom;
            prenom = _prenom;
        }

        public int Matricule { get { return matricule; } set { matricule = value; } }
        public string Prenom { get { return nom; } set { nom = value; } }
        public string Nom { get { return prenom; } set { prenom = value; } }

        public override string ToString()
        {
            return matricule.ToString() + nom + prenom;
        }
    }
}
