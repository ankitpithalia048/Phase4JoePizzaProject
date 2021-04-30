using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4JoePizzaProject
{
    public class PizzaModel
    {
        [Key]
        public string ID { get; set; }
        public string Pizza_Name { get; set; }
        public string Img_Url { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }

       
    }
}
