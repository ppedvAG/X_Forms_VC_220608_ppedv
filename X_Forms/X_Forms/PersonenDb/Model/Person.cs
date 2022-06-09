using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace X_Forms.PersonenDb.Model
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public Guid Id { get; set; }

        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }

    public static class StaticObjects
    {
        public static Services.PersonenDbController Datenbank { get; set; } = new Services.PersonenDbController();

        public static ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Model.Person>(Datenbank.GetPeople());
    };
}

