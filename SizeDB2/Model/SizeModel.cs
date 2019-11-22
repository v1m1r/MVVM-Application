using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;

namespace SizeDB2.Model
{
    public class SizeModel
    {
        static SizeModel _instance;
        static ApplicationContext db;
        private SizeModel()
        {
            db = new ApplicationContext();
        }
        public static SizeModel getInstance()
        {
            if (_instance == null)
                _instance = new SizeModel();
            return _instance;
        }

        public List<People> GetPeoples()
        {
            db.Peoples.Load();
            var a = db.Peoples.Local.ToList();
            return a;
        }

        public List<Cities> GetCitites()
        {
            db.Cities.Load();
            var b = db.Cities.Local.ToList();
            return b;
        }

        public List<CitiesLimit> GetCitiestLimit()
        {
            db.CitiesLimits.Load();
            var c = db.CitiesLimits.Local.ToList();
            return c;

        }

        public void Add(People p)
        {
            p.Date = null;
            db.Peoples.Add(p);
            db.SaveChanges();
        }
        public bool Edit(People p)
        {
            if (!CheckPeople(p))
                return false;
            var findpeople = db.Peoples.FirstOrDefault(x => x.Id == p.Id);
            
            findpeople.Fio = p.Fio;
            findpeople.Phone = p.Phone;
            findpeople.Date = p.Date;
            findpeople.Address = p.Address;
            findpeople.CityId = p.CityId;
            db.Entry(findpeople).State = EntityState.Modified;
            db.SaveChanges();
           
            return true;

        }

        public bool AddCity(Cities c)
        {
            if (!CheckCity(c))
                return false;
            db.Cities.Add(c);
            db.SaveChanges();
            return true;


        }

        public bool AddLimit(CitiesLimit l)
        {
            if (!CheckLimit(l))
                return false;
            db.CitiesLimits.Add(l);
            db.SaveChanges();
                return true;


        }
        //public bool EditZamer(Cities z)
        //{
        //    if (!CheckCity(z))
        //       return false;
        //        var findcity = db.Cities.FirstOrDefault(x => x.Id == z.Id);
        //    findcity.Limit = z.Limit - 1;
        //    db.Entry(findcity).State = EntityState.Modified;
        //    db.SaveChanges();
        //    return true;
        //}
        public bool Delete(People p)
        {
            if (!CheckPeople(p))
                return false;
            var findpeople = db.Peoples.FirstOrDefault(x => x.Id == p.Id);
            db.Peoples.Remove(findpeople);
            db.SaveChanges();
            return true;
        }

        public bool DeleteCity(Cities n)
        {
            if (!CheckCity(n))
                return false;
            var findcity = db.Cities.FirstOrDefault(x => x.Id == n.Id);
            db.Cities.Remove(findcity);
            db.SaveChanges();
            return true;


        }
        bool CheckPeople (People c)
        {
            var error = "";
            if (c == null)
                error = "Null people";
            else
            {
                if (c.Fio == null || c.Fio.Length == 0 || string.IsNullOrWhiteSpace(c.Fio))
                    error = "Empty people name";
                if (!db.Cities.Any(x => x.Id == c.CityId))
                    error = "Empty people city id";
                else
                {
                    var limit = db.CitiesLimits.SingleOrDefault(x => x.Date == c.Date && x.CityId == c.CityId);
                    if (limit == null)
                        error = "Нет лимита для города" +" "+ c.CityId + " на выбранную дату " + c.Date;
                    else
                    {
                        var countOfPeoples = db.Peoples.Count(x => x.CityId == c.CityId && x.Date == limit.Date);
                        if (countOfPeoples >= limit.Limit)
                            
                            error = "Количество замеров на выбранную дату исчерпано ID города:  " + c.CityId + " выбранная дата " + c.Date;
                    }
                }
            }
            if (error.Length == 0)
                return true;
            System.Windows.MessageBox.Show(error, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            return false;
        }

        bool CheckCity(Cities z)
        {
            var error = "";
            if (z == null)
                error = "Null city";
            else
            {
                if (z.CityName == null || z.CityName.Length == 0 || string.IsNullOrWhiteSpace(z.CityName))
                    error = "Empty city name. ";
                else if (db.Cities.Any(x => x.CityName== z.CityName))
                    error = "Already have a city with the same name.";
            }
            if (error.Length == 0)
                return true;
            System.Windows.MessageBox.Show(error, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            return false;

        }

        bool CheckLimit(CitiesLimit l)
        {
            var error = "";
            if (l == null)
                error = "Null limit";
            else
            {
                if (!db.Cities.Any(x => x.Id == l.CityId))
                    error = "Empty limit city id";
                //else
                //{
                //    var cityLimits = db.CitiesLimits.Where(x => x.Id == l.CityId);
                //    if (cityLimits.Any
                //        (
                //            x => x.Date <= l.Date
                //            ||
                //            x.Date >= l.Date


                //        )
                //        )
                //        error = "Уже есть лимит для города"+"  " + l.CityId;
                //}
            }
            if (error.Length == 0)
                return true;
            System.Windows.MessageBox.Show(error, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
            return false;
        }

        //bool CheckCity(Cities z)
        //{
        //    var error = "";
        //    if (z == null)
        //        error = "Null City";
        //    else
        //    {
        //        if (z.CityName == null || z.CityName.Length == 0 || string.IsNullOrWhiteSpace(z.CityName))
        //            error = "Empty city name";
        //        if (!db.Peoples.Any(x => x.CityId == z.Id))
        //            error = "Empty people city id";

        //    }
        //    if (error.Length == 0)
        //        return true;
        //    System.Windows.MessageBox.Show(error, "Error", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Error);
        //    return false;
        //}

    }

    public static class Extensions
    {
        public static People GetCopy(this People from)
        {
            return new People
            {
                Id = from.Id,
                Fio = from.Fio,
                Phone = from.Phone,
                Date = from.Date,
                Address = from.Address,
                CityId = from.CityId
            };
        }

        public static CitiesLimit GetCopy(this CitiesLimit from)
        {
            return new CitiesLimit
            {
                Id=from.Id,
                Date=from.Date,
                Limit=from.Limit,
                CityId=from.CityId

            };

        }


    }


}
