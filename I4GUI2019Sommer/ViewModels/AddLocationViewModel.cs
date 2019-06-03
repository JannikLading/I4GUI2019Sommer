using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Diagnostics;
using System.Windows.Input;
using I4GUI2019Sommer.Models;
using I4GUI2019Sommer.Views;
using Prism.Commands;
using Prism.Mvvm;

namespace I4GUI2019Sommer.ViewModels
{
    public class AddLocationViewModel : BindableBase
    {
        private Location _newLocation;
        private string _treeType;
        private int _treeCount; 
        
        public AddLocationViewModel(Location location)
        {
            _newLocation = location;
        }

        public Location NewLocation
        {
            get { return _newLocation; }
            set { SetProperty(ref _newLocation, value); }
        }

        public string TreeType
        {
            get { return _treeType; }
            set { SetProperty(ref _treeType, value); }
        }

        public int TreeCount
        {
            get { return _treeCount; }
            set { SetProperty(ref _treeCount, value); }
        }


        ICommand _addTreeCommand;
        public ICommand AddTreeCommand
        {
            get { return _addTreeCommand ?? (_addTreeCommand = new DelegateCommand(() =>
            {
                var tree = new Tree
                {
                    Count = TreeCount,
                    Type = TreeType
                };
                NewLocation.Trees.Add(tree);
            })); }
        }
    }

}
