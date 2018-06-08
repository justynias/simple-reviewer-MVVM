using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Place_review.Models
{
    public class Review
    {
        //GUID? depends on validation with unique names
        public string Name { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        [JsonIgnore]
        public double Mean { get; set; }

        public Review()
        {
            Categories = new ObservableCollection<Category>();
            Categories.Add(new Category("Food"));
            Categories.Add(new Category("Localization"));
            Categories.Add(new Category("Prices"));
            Categories.Add(new Category("Music"));
            Categories.Add(new Category("Atmosphere"));

        }
    }
}
