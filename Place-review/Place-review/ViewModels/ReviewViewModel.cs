using GalaSoft.MvvmLight;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Place_review.Additionals.NavigationService;
using Place_review.Models;
using GalaSoft.MvvmLight.CommandWpf;
using Place_review.DataService;
using GalaSoft.MvvmLight.Messaging;
using Place_review.Additionals;
namespace Place_review.ViewModels
{
    public class ReviewViewModel : ViewModelBase//, IDataErrorInfo
    {
        private Review currentReview;
        private string name;
        private ObservableCollection<Category> categories;
        private DataProvider dataProvider;
        private ObservableCollection<Review> reviewList;


        private IFrameNavigationService _navigationService;
        public RelayCommand SaveReviewCommand { get; private set; }
        public RelayCommand ReturnToReviewListCommand { get; private set; }


        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string result = string.Empty;
        //        if (columnName == "Name")
        //        {
        //            if (CanSave())
        //                result = "Name can not be empty";
        //        }

        //        return result;
        //    }
        //}
        //public string Error
        //{
        //    get { return null; }
        //}

        //public bool CanSave()
        //{
        //    return !(String.IsNullOrEmpty(Name));
        //}


        public string Name 
        {
            get
            {
                return name;
            }

            set
            {
                Set(ref name, value);
            }
        }
        public Review CurrentReview
        {
            get
            {
                return currentReview;
            }

            set
            {

                Set(ref currentReview, value);
            }
        }
        public ObservableCollection<Category> Categories
        {
            get
            {
                return categories;
            }

            set
            {

                Set(ref categories, value);
            }
        }

     

        public ReviewViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            dataProvider = new DataProvider();

            CurrentReview = new Review();
            Categories = new ObservableCollection<Category>();
          
            Categories.Add(new Category("Food"));
            Categories.Add(new Category("Localization"));
            Categories.Add(new Category("Prices"));
            Categories.Add(new Category("Music"));

            SaveReviewCommand = new RelayCommand(SaveReview, CanSave);
            ReturnToReviewListCommand = new RelayCommand(ReturnToReviewList);
            // Messenger.Default.Register<CurrentReviewMessage>(this, this.HandleCurrentReviewMessage);

        }

        //private void HandleCurrentReviewMessage(CurrentReviewMessage message)
        //{
        //    this.CurrentReview = message.CurrentReview;
        //    this.Name = message.CurrentReview.Name;
        //    this.Categories = message.CurrentReview.Categories;
        //    Console.WriteLine(Categories.ElementAt(1).Rate);
            
        //}
        public void SaveReview()
        {
            CurrentReview = new Review() { Name = this.Name, Categories=this.Categories };

            dataProvider.AddNewReview(CurrentReview);
             _navigationService.NavigateTo("ReviewList");
           
            Name = null;
            //Categories = null; 

       }
        public void ReturnToReviewList()
        {
            CurrentReview = null;
            _navigationService.NavigateTo("ReviewList");
        }

        private bool CanSave()
        {
            return !(String.IsNullOrEmpty(Name) || String.IsNullOrWhiteSpace(Name));
        }
    }


}
