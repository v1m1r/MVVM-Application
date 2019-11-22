
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using SizeDB2.Model;

namespace SizeDB2.ViewModel
{
    public class AddOrderSizeViewModel : INotifyPropertyChanged
    {
        SizeModel _sizemodel;
        public People People { get; set; }
        public List<Cities> Citys { get; set; }
        public AddOrderSizeViewModel()
        {
            _sizemodel = SizeModel.getInstance();
            People = new People();
            Citys = _sizemodel.GetCitites();
            OnPropertyChanged("People");
            OnPropertyChanged("Citys");

        }

        public ICommand AddSizeOrderCommand => new Command(obj => Add(obj));
        void Add(object obj)
        {
            _sizemodel.Add(People);
            Close(obj, true);
        }
        public ICommand CancelCommand => new Command(obj => Close(obj, false));

        void Close(object obj, bool dialogResult)
        {
            var w = ((System.Windows.Window)obj);
            w.DialogResult = dialogResult;
            w.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
