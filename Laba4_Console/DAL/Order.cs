using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DAL;


namespace DAL
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }

        public virtual OrderPrice OrderPrice { get; set; }

        public Hero Hero { get; set; }

        public virtual ICollection<Zone> Zones { get; set; }

    }
}
