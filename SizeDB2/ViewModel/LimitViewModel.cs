using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SizeDB2.Model;

namespace SizeDB2
{
    public class LimitViewModel : INotifyPropertyChanged
{
    public CitiesLimit Limit { get; set; }
    public Cities City { get; set; }

    public event PropertyChangedEventHandler PropertyChanged;

    public void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
 }
}

