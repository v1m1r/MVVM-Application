using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using SizeDB2.Model;

namespace SizeDB2.ViewModel
{
   public class PeopleViewModel : INotifyPropertyChanged
    {

        public People People { get; set; }
        public Cities City { get; set; }
        public CitiesLimit CitiesLimit { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
