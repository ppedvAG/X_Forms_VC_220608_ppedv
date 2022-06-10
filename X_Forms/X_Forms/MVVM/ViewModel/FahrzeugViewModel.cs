using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace X_Forms.MVVM.ViewModel
{
    public class FahrzeugViewModel : INotifyPropertyChanged
    {
        public Page ContextPage { get; set; }

        public FahrzeugViewModel()
        {
            NeuesFahrzeug = new Model.Fahrzeug();

            HinzufuegenCmd = new Command(FügeFahrzeugHinzu, CanFügeFahrzeugeHinzu);

            LoeschenCmd = new Command(LöscheFahrzeug);
        }

        public Model.Fahrzeug NeuesFahrzeug { get; set; }

        
        public string Fahrzeughersteller
        {
            get { return NeuesFahrzeug.Hersteller; }
            set { NeuesFahrzeug.Hersteller = value; HinzufuegenCmd.ChangeCanExecute(); }
        }

        public int FahrzeugMaxGeschwindigkeit
        {
            get { return NeuesFahrzeug.MaxGeschwindigkeit; }
            set { NeuesFahrzeug.MaxGeschwindigkeit = value; HinzufuegenCmd.ChangeCanExecute(); }
        }

        public ObservableCollection<Model.Fahrzeug> Fahrzeugliste
        {
            get { return Model.Fahrzeug.Fahrzeugliste; }
            set { Model.Fahrzeug.Fahrzeugliste = value; }
        }

        public Command HinzufuegenCmd { get; set; }

        public Command LoeschenCmd { get; set; }

        private void FügeFahrzeugHinzu(object parameter)
        {
            Fahrzeugliste.Add(NeuesFahrzeug);

            NeuesFahrzeug = new Model.Fahrzeug();

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Fahrzeughersteller)));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(FahrzeugMaxGeschwindigkeit)));
        }

        private bool CanFügeFahrzeugeHinzu(object parameter)
        {
            return !String.IsNullOrEmpty(NeuesFahrzeug.Hersteller) && NeuesFahrzeug.MaxGeschwindigkeit > 0;
        }

        private async void LöscheFahrzeug(object parameter)
        {
            if(await ContextPage.DisplayAlert("Löschen?", "Wirklich löschen?", "Ja", "Nein"))
                Fahrzeugliste.Remove(parameter as Model.Fahrzeug);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
