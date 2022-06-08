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
        public Hauptseite()
        {
            InitializeComponent();
            //this.Resources["BtnString"] = "Ich bin eine neue Resource";
            
        }

        private void Btn_KlickMich_Clicked(object sender, EventArgs e)
        {
            Lbl_Output.Text = "Button wurde geklickt";

            if (sender is Button)
                (sender as Button).BackgroundColor = Color.HotPink;

            Ent_Input.Text = Sdr_Wert.Value.ToString();

            Lbl_Output.Text = Pkr_Namen.SelectedItem?.ToString();
        }

        private void Ent_Input_Completed(object sender, EventArgs e)
        {
            Lbl_Output.Text = Ent_Input.Text;
        }

        private void Sdr_Wert_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Sdr_Wert.Value = Math.Round(Sdr_Wert.Value);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Lbl_Binding.Text = "0";
        }

        private void Btn_Show_Clicked(object sender, EventArgs e)
        {
            Person person = Sly_DataBinding.BindingContext as Person;
            DisplayAlert("Person", $"{person.Name} ({person.Alter})", "Ok");
        }

        private void Btn_Altern_Clicked(object sender, EventArgs e)
        {
            Person person = Sly_DataBinding.BindingContext as Person;
            person.Alter++;
        }

        private void Btn_Add_Clicked(object sender, EventArgs e)
        {
            Person person = Sly_DataBinding.BindingContext as Person;
            person.WichtigeTage.Add(DateTime.Now);
        }

        private void Btn_Delete_Clicked(object sender, EventArgs e)
        {
            if (LstV_WichtigeTage.SelectedItem is DateTime)
            {
                Person person = Sly_DataBinding.BindingContext as Person;
                person.WichtigeTage.Remove((DateTime)LstV_WichtigeTage.SelectedItem);
            }
        }

        private void Btn_Delete_02_Clicked(object sender, EventArgs e)
        {
            DateTime wichtigerTag = sender is Button ? (DateTime)(sender as Button).CommandParameter : (DateTime)(sender as MenuItem).CommandParameter;
            Person person = Sly_DataBinding.BindingContext as Person;

            person.WichtigeTage.Remove(wichtigerTag);
        }
    }
}
