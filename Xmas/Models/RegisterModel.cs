using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xmas.Models
{
    public class RegisterModel
    {
        private string _nom;
        private string _prenom;
        private string _surnom;
        private string _email;
        private string _motDePasse;
        private string _confirmMotDePasse;

        [Required(ErrorMessage = "Faut que tu me donne ton nom!!!!!!!")]
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
        [Required]
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

        [Required]
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

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email
        {
            get
            {
                return _email;
            }

            set
            {
                _email = value;
            }
        }

        [Required]
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


        [Compare("MotDePasse", ErrorMessage = "Les mots de passe ne correspondent pas")] 
        public string ConfirmMotDePasse
        {
            get
            {
                return _confirmMotDePasse;
            }

            set
            {
                _confirmMotDePasse = value;
            }
        }
    }
}
