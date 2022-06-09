using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace X_Forms.Layouts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RelativeLayoutBsp : ContentPage
    {
        public RelativeLayoutBsp()
        {
            InitializeComponent();
        }

        private void Btn_Box_Clicked(object sender, EventArgs e)
        {
            //Bei Neuzuweisung der Constraints muss durch die Constraint-Klasse eine neue Berechnungslogik für den Wert übergeben werden.
            //Hier: X-Position ergbit sich zukünftig aus 10% der Breite des Parents (des umgebenden RelativLayouts)
            RelativeLayout.SetXConstraint(Bxv_Gruen, Constraint.RelativeToParent(parent => parent.Width * 0.1));
        }
    }
}