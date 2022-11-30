using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    internal class Projet
    {
        string numero;
        string debut;
        int budget;
        string description;
        int employe;


        public Projet()
        {
            numero = "";
            debut = "";
            budget = 0;
            description = "";
            employe = 0;
        }

        public Projet(string _numero, string _debut, int _budget, string _description, int _employe)
        {
            numero = _numero;
            debut = _debut;
            budget = _budget;
            description = _description;
            employe = _employe;
        }

        public string Numero { get { return numero; } set { numero = value; } }
        public string Debut { get { return debut; } set { debut = value; } }
        public int Budget { get { return budget; } set { budget = value; } }
        public string Description { get { return description; } set { description = value; } }
        public int Employe { get { return employe; } set { employe = value; } }

        public override string ToString()
        {
            return numero + debut.ToString() + budget.ToString() + description + employe.ToString();
        }
    }
}
