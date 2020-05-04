using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba5_6_WEB.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Time { get; set; }
        public int Price { get; set; }

        public int HeroId { get; set; }
        public int AreaId { get; set; }
        public int AtractionId { get; set; }
    }
}
