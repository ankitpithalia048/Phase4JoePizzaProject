using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Phase4JoePizzaProject
{
    public class OrderDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public string Oid { get; set; }
        [NotMapped]
        public PizzaModel Pizza { get; set; }
        public PizzaModel Pizza_Price { get; set; }

        public string Pid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public long Quantity { get; set; }
        public double Price { get; set; }



    }
}
