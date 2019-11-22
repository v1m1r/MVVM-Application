using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SizeDB2.Model;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace SizeDB2.ViewModel
{
    public class EditSizeOrderViewModel : INotifyPropertyChanged
    {
        SizeModel _sizeModel;
        public People People { get; set; }
        public ObservableCollection<PeopleViewModel> CitiesLimitss { get; set; }
        public List<Cities> City { get; set; }
      public List<CitiesLimit> LimitsC { get; set; }

        public Cities Citys
        {
            get { return City.FirstOrDefault(x => x.Id == People.CityId); }

        }

       
        public CitiesLimit CitysLimits
        {
            get { return LimitsC.FirstOrDefault(x => x.CityId == Citys.Id); }
        }




        //public int Limitz
        //{ get { return CitysLimits.Limit; } }

        //public static ObservableCollection<CitiesLimit> Limitzz
        //{
        //    get
        //    {
        //        ApplicationContext context = new ApplicationContext();
        //        return new ObservableCollection<CitiesLimit>(context.CitiesLimits.Select(s => s).ToList());

        //    }
        //}
        public EditSizeOrderViewModel(People people)
        {
           
            _sizeModel = SizeModel.getInstance();
            People = people.GetCopy();
            City = _sizeModel.GetCitites();
            LimitsC = _sizeModel.GetCitiestLimit();
          GetCityLimitsTable();
            OnPropertyChanged("Peoples");
            OnPropertyChanged("City");
            //OnPropertyChanged("CitiesLimitss");
          // OnPropertyChanged("Limitzz");

        }
        public ICommand EditSaveSizeOrderCommand => new Command(obj => Edit(obj));

        void Edit(object obj)
        {
            if (_sizeModel.Edit(People))
                Close(obj, true);
        }

      public void GetCityLimitsTable()
        {
            var _cityLimits = _sizeModel.GetCitiestLimit();
            var _cities = _sizeModel.GetCitites();
            CitiesLimitss = new ObservableCollection<PeopleViewModel>(_cityLimits.Select(x => new PeopleViewModel { CitiesLimit = x, City = _cities.FirstOrDefault(y => y.Id == x.CityId && y.CityName==Citys.CityName)}));

            // CitiesLimitss = new ObservableCollection<PeopleViewModel>(_cityLimits.Select(x => new PeopleViewModel { CitiesLimit = x, City = _cities.FirstOrDefault(y => y.Id == x.CityId) }));
        }


        //public void Teta()
        //{
        //    var a;
        //    var db = new ApplicationContext();
        //    IQueryable<CitiesLimit> lim = db.CitiesLimits.Where(limit => limit.Limit > 1);
        //    foreach (CitiesLimit item in lim)
        //    {
        //        a = item.Limit;

        //    }
        //   return a;
        //}

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
