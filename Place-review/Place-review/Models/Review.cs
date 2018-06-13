using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;
using System.IO;

namespace Place_review.Models
{
    public class Review
    {
        public string Name { get; set; } 
        public ObservableCollection<Category> Categories { get; set; }

        [JsonIgnore]
        public double Mean
        {
            get
            {
                return CountMean();
            }

        }
        public Review()
        {

        }

        private double CountMean()
        {
            double sum = 0, weights = 0;
        
            foreach(var c in Categories)
            {
                sum = sum + c.Weight * c.Rate;
                weights = weights + c.Weight;
            }
            if (weights != 0) return Math.Round(sum / weights, 2);
            else return 0.0;
        }
        
    }
}
