using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SizeDB2.Model;
using System.ComponentModel;

namespace SizeDB2.ViewModel
{
   public class DeleteCityViewModel
    {
        SizeModel _sizeModel;
        public Cities City { get; set; }
        public DeleteCityViewModel(Cities city)
        {
            _sizeModel = SizeModel.getInstance();
            City = city;
            _sizeModel.DeleteCity(city);

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
