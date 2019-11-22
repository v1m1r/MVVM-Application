using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SizeDB2.Model;
using System.Windows.Input;
using System.ComponentModel;

namespace SizeDB2.ViewModel
{
    public class DeleteSizeOrderViewModel : INotifyPropertyChanged
    {
        SizeModel _sizeModel;
        public People People { get; set; }
        public DeleteSizeOrderViewModel(People people)
        {
            _sizeModel = SizeModel.getInstance();
            People = people;
            _sizeModel.Delete(people);


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
