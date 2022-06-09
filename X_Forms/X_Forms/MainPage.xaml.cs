using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace X_Forms
{
    public partial class Hauptseite : ContentPage
    {
        //Konstruktor
        public Hauptseite()
        {
            //Initialisierung der UI (Xaml-Datei). Sollte immer erste Aktion des Konstruktors sein
            InitializeComponent();

            //Neuzuweisung einer Ressource (nur DynamicResource-Bindungen reagieren auf die Veränderung
            this.Resources["BtnString"] = "Ich bin eine neue Resource";
            
        }

        //EventHandler eines Button-Click-Events (reagiert auf Button-Klick oder -Tab)
        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            //Neuzuweisung einer UI-Property über die x:Name-Property des Steuerelements
            Lbl_Output.Text = "Button wurde geklickt";

            //Neuzuweisung einer Property des Eventauslösenden Steuerelements
            if (sender is Button)
                (sender as Button).BackgroundColor = Color.HotPink;

            //Zugriff auf Value (ausgewählten Wert) des Sliders
            Ent_Input.Text = Sdr_Wert.Value.ToString();
            //Zugriff auf in Picker ausgewählten Eintrag
            Lbl_Output.Text = Pkr_Namen.SelectedItem?.ToString();
        }

        //EventHandler eines Entry-Completed-Events (reagiert auf 'Haken' in Tastatur dieses Entries)
        private void Ent_Input_Completed(object sender, EventArgs e)
        {
            Lbl_Output.Text = Ent_Input.Text;
        }

        //EventHandler eines Slider-ValueChanged-Events (reagiert auf Wert-Veränderung in Slider.Value)
        private void Sdr_Wert_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Sdr_Wert.Value = Math.Round(Sdr_Wert.Value);
        }

        private void Btn_Show_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf Person-Objekt in BindingContext des StackLayouts
            Person person = Sly_DataBinding.BindingContext as Person;
            //Anzeigen eines DisplayAlerts (MessageBox-Äquivalent)
            DisplayAlert("Person", $"{person.Name} ({person.Alter})", "Ok");
        }

        private void Btn_Altern_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf Person-Objekt in BindingContext des StackLayouts
            Person person = Sly_DataBinding.BindingContext as Person;
            //Erhöhung des Alters (INotifyPropertyChanged informiert die GUI, vgl. Person.cs)
            person.Alter++;
        }

        private void Btn_Add_Clicked(object sender, EventArgs e)
        {
            //Zugriff auf Person-Objekt in BindingContext des StackLayouts
            Person person = Sly_DataBinding.BindingContext as Person;
            //Hinzufügen eines neuen Objekts zu der Liste (ObservableCollection informiert die GUI, vgl. Person.cs)
            person.WichtigeTage.Add(DateTime.Now);
        }

        private void Btn_Delete_Clicked(object sender, EventArgs e)
        {
            //Prüfung, ob in ListView ein Item ausgewählt wurde
            if (LstV_WichtigeTage.SelectedItem is DateTime)
            {
                //Löschen des ausgwählten Items
                Person person = Sly_DataBinding.BindingContext as Person;
                person.WichtigeTage.Remove((DateTime)LstV_WichtigeTage.SelectedItem);
            }
        }

        private void Btn_Delete_02_Clicked(object sender, EventArgs e)
        {
            //Erfragen des zu löschenden Items über den Event-Sender
            DateTime wichtigerTag = sender is Button ? (DateTime)(sender as Button).CommandParameter : (DateTime)(sender as MenuItem).CommandParameter;
             //Löschen des Items
            Person person = Sly_DataBinding.BindingContext as Person;
            person.WichtigeTage.Remove(wichtigerTag);
        }

        private void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            //löschen der kompletten Liste
            (Sly_DataBinding.BindingContext as Person).WichtigeTage.Clear();
        }

        //Navigationsbeispiele
        private void Btn_NavigateToGrid_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage 
            Navigation.PushAsync(new Übungen.U_GridLayout());
        }

        private void Btn_NavigateToRelativeL_Clicked(object sender, EventArgs e)
        {
            //Aufruf einer neuen Seite innerhalb der aktuellen NavigationPage, welche aber keine Navigationsleiste anzeigt
            Navigation.PushModalAsync(new Übungen.U_RelativeLayout());
        }

        private void Btn_NavigateToTabbed_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsp.TabbedPageBsp());
        }
        private void Btn_NavigateToCarousel_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NavigationBsp.CarouselPageBsp());
        }
    }
}
