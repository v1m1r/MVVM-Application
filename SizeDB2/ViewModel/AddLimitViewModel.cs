using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SizeDB2.Model;

namespace SizeDB2.ViewModel
{
  public  class AddLimitViewModel : INotifyPropertyChanged
    {
        SizeModel _sizemodel;
      
        public CitiesLimit Limit { get; set; }
        public List<Cities> City { get; set; }
        public AddLimitViewModel()
        {
            _sizemodel = SizeModel.getInstance();
            Limit = new CitiesLimit { Date = DateTime.Now.Date };
            City = _sizemodel.GetCitites();
            OnPropertyChanged("City");
        }
        public ICommand AddCommand => new Command(obj => Add(obj));

        void Add(object obj)
        {
            _sizemodel = SizeModel.getInstance();
            if (_sizemodel.AddLimit(Limit.GetCopy()))
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
