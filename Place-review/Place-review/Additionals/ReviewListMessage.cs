using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Place_review.Models;
using System.Collections.ObjectModel;

namespace Place_review.Additionals
{
    public class ReviewListMessage
    {
        public ObservableCollection<Review> ReviewList { get; set; }
    }
}
