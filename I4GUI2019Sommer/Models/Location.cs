using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Animation;
using Prism.Mvvm;

namespace I4GUI2019Sommer.Models
{
    public class Location : BindableBase
    {
        private int _locationId;
        private static int _nrOfInstances = 0; 

        private string _name; 
        private string _street;
        private string _streetnr;
        private int _zipCode;
        private string _city;
        private ObservableCollection<Tree> _trees;

        public Location()
        {
            _locationId = _nrOfInstances;
            _nrOfInstances++; 
            _trees = new ObservableCollection<Tree>();
        }

        public int LocationId
        {
            get { return _locationId; }
        }

        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value);  }
        }

        public string Street
        {
            get { return _street; }
            set { SetProperty(ref _street, value); }
        }

        public string Streetnr
        {
            get { return _streetnr; }
            set { SetProperty(ref _streetnr, value); }
        }

        public int ZipCode
        {
            get { return _zipCode; }
            set { SetProperty(ref _zipCode, value); }
        }

        public string City
        {
            get { return _city; }
            set { SetProperty(ref _city, value); }
        }

        public ObservableCollection<Tree> Trees
        {
            get { return _trees; }
            set { SetProperty(ref _trees, value); }
        }

    }
}
