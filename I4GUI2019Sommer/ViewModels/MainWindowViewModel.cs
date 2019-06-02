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
//using I4GUI2019Sommer.Data;
//using I4GUI2019Sommer.Models;
using I4GUI2019Sommer.Utilities;
//using I4GUI2019Sommer.Views;

namespace I4GUI2019Sommer.Viewmodels
{
    public class MainWindowViewModel : BindableBase
    {
        //private ObservableCollection<VarroaCount> _varroaCounts;
        //private ObservableCollection<VarroaCount> _filteredVarroaCounts; 
        private DispatcherTimer timer = new DispatcherTimer();
        //private VarroaCount _currentVarroaCount;
        private int _currentIndex = -1;
        private string _filter = "";
        private string _filePath = "";
        private string _filename = ""; 


        public MainWindowViewModel()
        {
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();
        }

        //public ObservableCollection<VarroaCount> VarroaCounts
        //{
        //    get { return _varroaCounts; }
        //    set { SetProperty(ref _varroaCounts, value); }
        //}

        //public ObservableCollection<VarroaCount> FilteredVarroaCounts
        //{
        //    get { return _filteredVarroaCounts; }
        //    set { SetProperty(ref _filteredVarroaCounts, value); }
        //}

        //public VarroaCount CurrentVarroaCount
        //{
        //    get { return _currentVarroaCount; }
        //    set { SetProperty(ref _currentVarroaCount, value); }
        //}

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



        //ICommand _addCommand;
        //public ICommand AddVarroaCountCommand
        //{
        //    get
        //    {
        //        return _addCommand ?? (_addCommand = new DelegateCommand(() =>
        //        {
        //            var varroaCount = new VarroaCount();

        //            var vm = new AddVarroaCountViewModel( varroaCount);

        //            var view = new AddVarroaCount
        //            {
        //                DataContext = vm
        //            };

        //            if (view.ShowDialog() == true)
        //            {
        //                _varroaCounts.Add(varroaCount);
        //                if (Filter == "" || varroaCount.Beehive == Filter)
        //                {
        //                    FilteredVarroaCounts.Add(varroaCount);
        //                }
        //                CurrentVarroaCount = varroaCount;
        //            }

        //        }));
        //    }
        //}

        //ICommand _filterCommand;
        //public ICommand FilterVarroaCountCommand
        //{
        //    get
        //    {
        //        return _filterCommand ?? (_filterCommand = new DelegateCommand( () => FilterVarroaCounts()));
        //    }
        //}

        //private async void FilterVarroaCounts()
        //{
        //    if (Filter != "")
        //    {
        //        var tempVarroaCounts = new ObservableCollection<VarroaCount>();

        //        await Task.Run(() =>
        //        {
        //            foreach (var varroaCount in VarroaCounts)
        //            {
        //                if (varroaCount.Beehive == Filter)
        //                {
        //                    tempVarroaCounts.Add(varroaCount);
        //                }
        //            }
        //        });
        //        FilteredVarroaCounts = new ObservableCollection<VarroaCount>(tempVarroaCounts);

        //    }
        //    else
        //    {
        //        FilteredVarroaCounts = new ObservableCollection<VarroaCount>(VarroaCounts);
        //    }
        //}

        //public string Filename
        //{
        //    get { return _filename; }
        //    set
        //    {
        //        SetProperty(ref _filename, value);
        //        RaisePropertyChanged("Title");
        //    }
        //}
        //private void SaveFile()
        //{
        //    try
        //    {
        //        Repository.SaveFile(_filePath, VarroaCounts);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Unable to save file", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}

        //ICommand _SaveAsCommand;
        //public ICommand SaveAsCommand
        //{
        //    get { return _SaveAsCommand ?? (_SaveAsCommand = new DelegateCommand<string>(SaveAsCommand_Execute)); }
        //}

        //private void SaveAsCommand_Execute(string argFilename)
        //{
        //    var dialog = new SaveFileDialog
        //    {
        //        Filter = "Varroa Count documents|*.vcd|All Files|*.*",
        //        DefaultExt = "vcd"
        //    };
        //    if (_filePath == "")
        //        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    else
        //        dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

        //    if (dialog.ShowDialog(App.Current.MainWindow) == true)
        //    {
        //        _filePath = dialog.FileName;
        //        Filename = Path.GetFileName(_filePath);
        //        SaveFile();
        //    }
        //}


        //ICommand _OpenFileCommand;
        //public ICommand OpenFileCommand
        //{
        //    get { return _OpenFileCommand ?? (_OpenFileCommand = new DelegateCommand<string>(OpenFileCommand_Execute)); }
        //}

        //private void OpenFileCommand_Execute(string argFilename)
        //{
        //    var dialog = new OpenFileDialog
        //    {
        //        Filter = "Varroa Count documents|*.vcd|All Files|*.*",
        //        DefaultExt = "vcd"
        //    };
        //    if (_filePath == "")
        //        dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    else
        //        dialog.InitialDirectory = Path.GetDirectoryName(_filePath);

        //    if (dialog.ShowDialog(App.Current.MainWindow) == true)
        //    {
        //        _filePath = dialog.FileName;
        //        Filename = Path.GetFileName(_filePath);
        //        try
        //        {
        //            Repository.ReadFile(_filePath, out ObservableCollection<VarroaCount> tempVarroaCounts);
        //            VarroaCounts = tempVarroaCounts;
        //            FilteredVarroaCounts = new ObservableCollection<VarroaCount>(tempVarroaCounts);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Unable to open file", MessageBoxButton.OK, MessageBoxImage.Error);
        //        }
        //    }
        //}
    }
}

