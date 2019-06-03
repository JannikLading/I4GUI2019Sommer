using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using I4GUI2019Sommer.Data;
using I4GUI2019Sommer.Models;
using I4GUI2019Sommer.Utilities;
using I4GUI2019Sommer.ViewModels;
using I4GUI2019Sommer.Views;

namespace I4GUI2019Sommer.Viewmodels
{
    public class MainWindowViewModel : BindableBase
    {
        private ObservableCollection<Location> _locations;
        private ObservableCollection<Location> _filteredLocations; 
        private DispatcherTimer timer = new DispatcherTimer();
        private Location _currentLocation;
        private int _currentIndex = -1;
        private string _filter = "";
        private string _filePath = "";
        private string _filename = ""; 


        public MainWindowViewModel()
        {
            _locations = new ObservableCollection<Location>();

            var lok = new Location
            {
                Name = "Mindeparken",
                Street = "Carl Nielsens Vej",
                ZipCode = 8000,
                City = "Aarhus",
                Trees = new ObservableCollection<Tree>
                {
                    new Tree
                    {
                        Count = 2,
                        Type = "Eg"
                    },
                    new Tree
                    {
                        Count = 5,
                        Type = "Ahorn"
                    }
                }
            };
            var lok2 = new Location
            {
                Name = "Finlandsgade",
                Street = "Finlandsgade",
                ZipCode = 8200,
                City = "Aarhus N",
                Trees = new ObservableCollection<Tree>
                {
                    new Tree
                    {
                        Count = 2,
                        Type = "Eg"
                    },
                    new Tree
                    {
                        Count = 5,
                        Type = "Ahorn"
                    }
                }
            };
            
            _locations.Add(lok);
            _locations.Add(lok2);

            FilteredLocations = new ObservableCollection<Location>(Locations);

            CurrentLocation = lok;
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        public ObservableCollection<Location> Locations
        {
            get { return _locations; }
            set { SetProperty(ref _locations, value); }
        }

        public ObservableCollection<Location> FilteredLocations
        {
            get { return _filteredLocations; }
            set { SetProperty(ref _filteredLocations, value); }
        }

        public Location CurrentLocation
        {
            get { return _currentLocation; }
            set { SetProperty(ref _currentLocation, value); }
        }

        public string Filter
        {
            private get { return _filter; }
            set { SetProperty(ref _filter, value); }
        }
        
        public int CurrentIndex
        {
            get { return _currentIndex; }
            set { SetProperty(ref _currentIndex, value); }
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            clock.Update();
        }

        Clock clock = new Clock();

        public Clock Clock
        {
            get => clock;
            set => clock = value;
        }
        
        ICommand _addCommand;
        public ICommand AddLocationCommand
        {
            get
            {
                return _addCommand ?? (_addCommand = new DelegateCommand(() =>
                {
                    var newLocation = new Location();

                    var vm = new AddLocationViewModel(newLocation);

                    var view = new AddLocation()
                    {
                        DataContext = vm
                    };

                    if (view.ShowDialog() == true)
                    {
                        _locations.Add(newLocation);
                        if (Filter == "" || newLocation.Name == Filter)
                        {
                            FilteredLocations.Add(newLocation);
                        }
                        CurrentLocation = newLocation;
                    }

                }));
            }
        }

        ICommand _filterCommand;
        public ICommand FilterLocationsCommand
        {
            get
            {
                return _filterCommand ?? (_filterCommand = new DelegateCommand(() => FilterLocations()));
            }
        }

        private async void FilterLocations()
        {
            if (Filter != "")
            {
                var tempLocations = new ObservableCollection<Location>();

                await Task.Run(() =>
                {
                    foreach (var location in Locations)
                    {
                        if (location.Name == Filter)
                        {
                            tempLocations.Add(location);
                        }
                    }
                });
                FilteredLocations = new ObservableCollection<Location>(tempLocations);
            }
            else
            {
                FilteredLocations = new ObservableCollection<Location>(Locations);
            }
        }

        public string Filename
        {
            get { return _filename; }
            set
            {
                SetProperty(ref _filename, value);
                RaisePropertyChanged("Title");
            }
        }
        private void SaveFile()
        {
            try
            {
                Repository.SaveFile(_filePath, Locations);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        ICommand _SaveAsCommand;
        public ICommand SaveAsCommand
        {
            get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
        }

        private void SaveAsCommand_Execute(string argFilename)
        {
            var dialog = new SaveFileDialog
            {
                Filter = "Locations documents|*.ld|All Files|*.*",
                DefaultExt = "ld"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                _filePath = dialog.FileName;
                Filename = Path.GetFileName(_filePath);
                SaveFile();
            }
        }


        ICommand _OpenFileCommand;
        public ICommand OpenFileCommand
        {
            get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand<string>(OpenFileCommand_Execute)); }
        }

        private void OpenFileCommand_Execute(string argFilename)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Locations documents|*.ld|All Files|*.*",
                DefaultExt = "ld"
            };
            if (_filePath == "")
                dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            else
                dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

            if (dialog.ShowDialog(App.Current.MainWindow) == true)
            {
                _filePath = dialog.FileName;
                Filename = Path.GetFileName(_filePath);
                try
                {
                    Repository.ReadFile(_filePath, out ObservableCollection<Location> tempLocations);
                    Locations = tempLocations;
                    FilteredLocations = new ObservableCollection<Location>(Locations);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

