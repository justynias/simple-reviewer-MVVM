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
        //GUID? depends on validation with unique names
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
            //Categories = new ObservableCollection<Category>();
            //Categories.Add(new Category("Food"));
            //Categories.Add(new Category("Localization"));
            //Categories.Add(new Category("Prices"));
            //Categories.Add(new Category("Music"));

        }

        private double CountMean()
        {
            double sum = 0, weights = 0;
        
            foreach(var c in Categories)
            {
                sum = sum + c.Weight * c.Rate;
                weights = weights + c.Weight;
            }
            return Math.Round(sum / weights, 2);
        }
        
    }
}
