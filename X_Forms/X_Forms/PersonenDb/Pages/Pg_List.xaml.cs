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
    public partial class Pg_List : ContentPage
    {
        public ObservableCollection<Model.Person> Personenliste 
        {
            get { return Model.StaticObjects.Personenliste; }
            set { Model.StaticObjects.Personenliste= value; }
        }

        public Pg_List()
        {
            InitializeComponent();

            //this.BindingContext = this;
        }

        private async void CaMenu_Delete_Clicked(object sender, EventArgs e)
        {
            Model.Person person = (sender as MenuItem).CommandParameter as Model.Person;

            bool result = await DisplayAlert("Person löschen", $"Soll {person.Vorname} {person.Nachname} wirklich gelöscht werden?", "Ja", "Nein");

            if (result)
            { 
                Personenliste.Remove(person);

                Model.StaticObjects.Datenbank.DeletePerson(person);

                Services.ToastController.ShowToast($"{person.Vorname} wurde gelöscht");
            }
        }
    }
}