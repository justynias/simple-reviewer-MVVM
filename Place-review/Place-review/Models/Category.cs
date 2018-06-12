using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place_review.Models
{
    public class Category
    {
        public static int[] Rates { get; set; }
        public string CategoryName { get; set; }
        public int Rate { get; set; }
        public double Weight { get; set; }
       
        public Category(string name)
        {
            Rates = new[] {0,1,2,3,4,5};
            CategoryName = name;
            Weight = 1;

          
        }
    }
}
