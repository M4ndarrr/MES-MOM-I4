using System.Collections.Generic;

namespace WPF.Helpers
{
    public class Entitypokus
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public RelayCommand Command { get; set; }


        private List<Entitypokus> items;
        public List<Entitypokus> Items
        {
            get
            {
                return this.items;
            }
            private set
            {
                this.items = value;
            }
        }

        public Entitypokus(string name)
        {
            this.Name = name;
            this.Items = new List<Entitypokus>();
        }
    }
}