using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace X_Forms
{
    internal class Person : INotifyPropertyChanged
    {
        
        public string Name { get; set; }


        private int alter;
        public int Alter 
        { 
            get => alter;
            set
            {
                alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public ObservableCollection<DateTime> WichtigeTage { get; set; } = new ObservableCollection<DateTime>()
        {
            new DateTime(2003, 12, 5),
            new DateTime(2004, 11, 4),
            new DateTime(2005, 10, 3),
            new DateTime(2006, 9, 2),
            new DateTime(2007, 8, 1),
        };

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
