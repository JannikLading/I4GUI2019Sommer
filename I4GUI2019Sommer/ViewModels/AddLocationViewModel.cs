using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using I4GUI2019Sommer.Models;
using Prism.Mvvm;

namespace I4GUI2019Sommer.ViewModels
{
    public class AddLocationViewModel : BindableBase
    {
        private Location _newLocation;

        public AddLocationViewModel(Location location)
        {
            _newLocation = location;
        }

        public Location NewLocation
        {
            get { return _newLocation; }
            set { SetProperty(ref _newLocation, value); }
        }
        
    }

}
