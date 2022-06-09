using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.PersonenDb.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pg_Add : ContentPage
    {
        public Model.Person NeuePerson { get; set; }
        public ObservableCollection<Model.Person> Personenliste
        {
            get { return Model.StaticObjects.Personenliste; }
            set { Model.StaticObjects.Personenliste = value; }
        }

        public Pg_Add()
        {
            InitializeComponent();

            NeuePerson = new Model.Person();
        }

        private void Btn_AddPerson_Clicked(object sender, EventArgs e)
        {
            Model.StaticObjects.Personenliste.Add(NeuePerson);

            Model.StaticObjects.Datenbank.AddPerson(NeuePerson);

            Services.ToastController.ShowToast($"{NeuePerson.Vorname} wurde hinzugefügt");

            NeuePerson = new Model.Person();
        }
    }
}