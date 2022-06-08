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
            this.Resources["BtnString"] = "Ich bin eine neue Resource";
            InitializeComponent();

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
    }
}
