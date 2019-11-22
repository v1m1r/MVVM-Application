using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Collections.ObjectModel;
using SizeDB2.Model;
using SizeDB2.ViewModel;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using GalaSoft.MvvmLight;
using SizeDB2.View;

namespace SizeDB2.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        SizeModel _sizemodel;
        public ObservableCollection<PeopleViewModel> Peoples { get; set; }
        public ObservableCollection<Cities> Citys { get; set; }
        public PeopleViewModel SelectedPeoples { get; set; }
        public Cities SelectedCitys { get; set; }

        public ObservableCollection<LimitViewModel> Limits { get; set; }
        public LimitViewModel SelectedLimit { get; set; }

        public MainWindowViewModel()
        {
            _sizemodel = SizeModel.getInstance();
            Update();
        }
        public ICommand RefreshCommand => new Command(obj => Update());
        void Update()
        {
          var _peoples = _sizemodel.GetPeoples();
          var _cities = _sizemodel.GetCitites();
          var _limits = _sizemodel.GetCitiestLimit();

          Peoples = new ObservableCollection<PeopleViewModel>(_peoples.Select(x => new PeopleViewModel { People = x, City = _cities.FirstOrDefault(y => y.Id == x.CityId) }));
          SelectedPeoples = Peoples.FirstOrDefault();
          Citys = new ObservableCollection<Cities>(_cities);
          SelectedCitys = Citys.FirstOrDefault();
            Limits = new ObservableCollection<LimitViewModel>(_limits.Select(x => new LimitViewModel { Limit = x, City = _cities.FirstOrDefault(y => y.Id == x.CityId) }));
            OnPropertyChanged("Peoples");
            OnPropertyChanged("SelectedPeoples");
            OnPropertyChanged("Citys");
            OnPropertyChanged("Limits");
            OnPropertyChanged("SelectedLimit");
        }

        public ICommand NewAddOrderSizeCommand => new Command(obj => Add());


        public ICommand EditOrderSizeCommand => new Command(obj => Edit(), obj => { return SelectedPeoples != null; });

        public ICommand AddCityCommand => new Command(obj => AddCity());
        public ICommand DeleteOrderSizeCommand => new Command(obj => Delete(), obj => { return SelectedPeoples != null; });

        public ICommand DeleteCityCommand => new Command(obj => DeleteCitys(), obj => { return SelectedPeoples != null; });

        public ICommand AddLimitCommand => new Command (obj => AddLimit());
        void Add()
        {
            var dialogWindow = new AddOrderSize { DataContext = new AddOrderSizeViewModel() };
            if (dialogWindow.ShowDialog().GetValueOrDefault())
                Update();
        }

        void Edit()
        {
            var editSizeOrder = new EditSizeOrder { DataContext = new EditSizeOrderViewModel(SelectedPeoples.People) };
            if (editSizeOrder.ShowDialog().GetValueOrDefault())
                Update();
        }

        void AddCity()
        {
            var dialogWindow = new AddCitySize { DataContext = new AddCityViewModel() };
            if (dialogWindow.ShowDialog().GetValueOrDefault())
                Update();

        }
        void Delete()
        {
            var deleteSizeOrder = new DeleteSizeOrderViewModel(SelectedPeoples.People);
           
                Update();
        }

        void DeleteCitys()
        {
            var deleteCitys = new DeleteCityViewModel(SelectedPeoples.City);
            Update();

        }

        void AddLimit()
        {
            var addLimit = new AddLimit { DataContext = new AddLimitViewModel() };
            if (addLimit.ShowDialog().GetValueOrDefault())
                Update();


        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
