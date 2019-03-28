using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LagerSystem.Model;

namespace LagerSystem
{
    class Logik
    {

        ObservableCollection<Item> alleItems = new ObservableCollection<Item>();
        private static Logik instance;

        private Logik() { }

        public static Logik Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Logik();
                }
                return instance;
            }
        }

        internal ObservableCollection<Item> AlleItems { get => alleItems; set => alleItems = value; }

        internal void addItem(Item item)
        {
            AlleItems.Add(item);
        }
    }
}
