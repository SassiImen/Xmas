namespace Xmas.DAL.Models
{
    using System;
    using System.Collections.Generic;
    using Xmas.DAL.Interface;

    public partial class Membre : IEntity<int>
    {
      
    
        private int _idMembre;
        private string _nom;
        private string _prenom;
        private string _surnom;
        private string _courriel;
        private string _motDePasse;
    

    

        public int IdMembre
        {
            get
            {
                return _idMembre;
            }

            set
            {
                _idMembre = value;
            }
        }

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Surnom
        {
            get
            {
                return _surnom;
            }

            set
            {
                _surnom = value;
            }
        }

        public string Courriel
        {
            get
            {
                return _courriel;
            }

            set
            {
                _courriel = value;
            }
        }

        public string MotDePasse
        {
            get
            {
                return _motDePasse;
            }

            set
            {
                _motDePasse = value;
            }
        }
        public IEnumerable<Cadeau> Cadeau { get; set; }

        public IEnumerable<Lettre> Lettre { get; set; }

        public IEnumerable<Groupe> MembreGroupe { get; set; }
        public IEnumerable<Groupe> AdminGroupe { get; set; }

        public IEnumerable<Tirage> MesTirages { get; set; }

        public int Id
        {
            get
            {
                return _idMembre;
            }
        }

        public Membre()
        {
            this.Cadeau = new List<Cadeau>();
            this.Lettre = new List<Lettre>();
            this.MembreGroupe = new List<Groupe>();
            this.AdminGroupe = new List<Groupe>();
            this.MesTirages = new List<Tirage>();
        }
    }
}
