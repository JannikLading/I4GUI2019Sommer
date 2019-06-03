using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace I4GUI2019Sommer.Models
{
    public class Tree : BindableBase
    {
        private int _count;
        private string _type;

        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }

        public string Type
        {
            get { return _type; }
            set { SetProperty(ref _type, value); }
        }
    }
}
