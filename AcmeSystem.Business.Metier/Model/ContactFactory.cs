using System;
using System.Collections.Generic;
using System.Text;

namespace AcmeSystem.Business.Metier.Model
{
    public class ContactFactory
    {
        public static Contact CreateContact(int id, string nom, string prenom, string rue, string num,
                                            string npa, string localite)
        {
            Adresse adresse = new Adresse()
            {
                Rue = rue,
                Numero = num,
                Npa = npa,
                Localite = localite,
            };

            return new Contact()
            {
                Id = id,
                Nom = nom,
                Prenom = prenom,
                Adresse = adresse
            };
        }

        public static ICollection<Contact> GetFakeContacts()
        {
            ICollection<Contact> contacts = new List<Contact>()
            {
                CreateContact(1, "Newton_Mock", "Isac", "Gravity street", "25", "1042", "London"),
                CreateContact(2, "Holmes_Mock", "Sherlock", "Baker street", "121b", "1000", "London"),
                CreateContact(3, "Babbage_Mock", "Charles", "Rue de la Science", "232", "1019", "Paris"),
                CreateContact(4, "Lovelace_Mock", "Ada", "Rue de la programmation", "43", "1236", "Paris"),
                CreateContact(5, "Pasteur_Mock", "Louis", "Rue du vaccin", "154", "1457", "Paris"),
                CreateContact(6, "Turing_Mock", "Alan", "Rue du vaccin", "12", "1201", "London"),
                CreateContact(7, "Maxwell_Mock", "James", "Magnetic Street", "47", "2589", "Edinbourg"),
                CreateContact(8, "Tesla_Mock", "Nikola", "Electric Street", "547", "6021", "New York"),
                CreateContact(9, "Edison_Mock", "Thomas", "Light Street", "584", "3010", "Boston"),
                CreateContact(10, "Curie_Mock", "Marie", "Rue du Radium", "11", "1912", "Paris"),
                CreateContact(11, "Faraday_Mock", "Michael", "Dynamo Street", "87", "1879", "London"),
            };

            return contacts;
        }
    }
}
