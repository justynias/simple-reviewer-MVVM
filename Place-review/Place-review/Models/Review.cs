using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Newtonsoft.Json;

namespace Place_review.Models
{
    class Review
    {
        //GUID? depends on validation with unique names
        string Name { get; set; }
        public ObservableCollection<Category> Categories { get; set; }

        [JsonIgnore]
        public double Mean { get; set; }
    }
}
