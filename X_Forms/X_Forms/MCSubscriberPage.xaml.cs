using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MCSubscriberPage : ContentPage
    {
        public MCSubscriberPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<Hauptseite, string>(this, "Nachricht", CallBack);
        }

        private void CallBack(Hauptseite sender, string inhalt)
        {
            Lbl_Main.Text = inhalt;
        }
    }
}