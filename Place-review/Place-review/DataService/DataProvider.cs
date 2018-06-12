using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Place_review.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Place_review.DataService
{
    public class DataProvider
    {
        private string jsonFile = "data.json";
        private async void SaveToJson(ObservableCollection<Review> newReviewCollection)
        {

            try
            {
                string newJson = JsonConvert.SerializeObject(newReviewCollection);

                using (StreamWriter writer = File.CreateText(jsonFile))
                {
                    await writer.WriteAsync(newJson);
                }
            }
            catch (FileNotFoundException e) { throw new Exception(e.Message); }
            Console.WriteLine("koniec");
        }



        public ObservableCollection<Review> LoadData()
        {
            ObservableCollection<Review> reviewCollection = new ObservableCollection<Review>();
            try
            {
                using (System.IO.StreamReader r = new System.IO.StreamReader(jsonFile))
                {
                    string json = r.ReadToEnd();
                    reviewCollection = JsonConvert.DeserializeObject<ObservableCollection<Review>>(json);
                    Console.WriteLine("czytam");
                }
            }
            catch (System.IO.FileNotFoundException) { }
            catch (JsonReaderException) { }
            catch (System.IO.IOException) { Console.WriteLine("DUPA"); }
            if (reviewCollection == null) return new ObservableCollection<Review>();
            else return reviewCollection;
        }
    
        public void AddNewReview (Review newReview)
        {
            var reviewList = LoadData();
            reviewList.Add(newReview);
            SaveToJson(reviewList);

        }
        public void DeleteReview(Review reviewToDelete)
        {
        
            var reviewList = LoadData();
            reviewList.RemoveAt(reviewList.IndexOf(reviewList.First(r => r.Name == reviewToDelete.Name)));
            SaveToJson(reviewList);
        }
    }
}
