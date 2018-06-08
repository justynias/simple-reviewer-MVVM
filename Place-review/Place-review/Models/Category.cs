using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place_review.Models
{
    public class Category
    {
        public string Name { get; set; }
        public int Rate { get; set; }
        public double Weight { get; set; }

        public Category(string name)
        {
            this.Name = name;
        }
    }
}
