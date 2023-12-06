using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    public class Product
    {
        public int id { get; private set; }
        private string name { get; set; }
        private string desc { get; set; }
        private string price { get; set; }
        
        public string imagePath { get; private set; }

        public Product(int id, string name, string desc, string price, string imagePath)
        {
            this.id = id;
            this.name = name;
            this.desc = desc;
            this.price = price;
            
            this.imagePath = imagePath;
            
        }

        public string GetDescription()
        {
            string description = $"Имя: {this.name}\n" +
                $"Цена: {this.price}\n" +
                $"Описание: {this.desc}";
            return description;
        }


    }
}
