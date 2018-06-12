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
using Place_review.DataService;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using Place_review.Additionals;

namespace Place_review.ViewModels
{
    public class ReviewListViewModel : ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        private ObservableCollection<Review> reviewList;
        private ObservableCollection<Category> categories;
        private int weightFood=1;
        private int weightLocalization=1;
        private int weightPrices=1;
        private int weightMusic=1;
        private Review selectedReview;

        public int WeightFood
        {
            get
            {
                return weightFood;
            }
            set
            {
                Set(ref weightFood, value);
            }
        }
        public int WeightMusic
        {
            get
            {
                return weightMusic;
            }
            set
            {
                Set(ref weightMusic, value);
            }
        }
        public int WeightLocalization
        {
            get
            {
                return weightLocalization;
            }
            set
            {
                Set(ref weightLocalization, value);
            }
        }
        public int WeightPrices
        {
            get
            {
                return weightPrices;
            }
            set
            {
                Set(ref weightPrices, value);
            }
        }

        public ObservableCollection<Review> ReviewList
        {
            get
            {
                return reviewList;
                
            }

            set
            {
                Set( ref reviewList, value);
               
            }
        }

        public Review SelectedReview
        {
            get
            {
                return selectedReview;

            }

            set
            {
                Set(ref selectedReview, value);

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

        private DataProvider dataProvider;
        public ICommand AddReviewCommand { get; private set; }
        public ICommand LoadDataCommand { get; private set; }
        public ICommand DeleteReviewCommand { get; private set; }
        public ICommand EditReviewCommand { get; private set; }
        public ICommand FilterCommand{ get; private set; }


        public ReviewListViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            AddReviewCommand = new RelayCommand(AddReview);
            FilterCommand = new RelayCommand(Filter);
            LoadDataCommand = new RelayCommand(LoadData);
            DeleteReviewCommand = new RelayCommand(DeleteReview, ()=>SelectedReview!=null);
            EditReviewCommand = new RelayCommand(EditReview, () => SelectedReview != null);
            dataProvider = new DataProvider();
            ReviewList = new ObservableCollection<Review>();

        }
        public void LoadData()
        {
            ReviewList = dataProvider.LoadData();
            var sortableList = ReviewList.OrderByDescending(r => r.Mean).ToList();
            ReviewList.Clear();
            for (int i = 0; i < sortableList.Count; i++)
            {
                ReviewList.Add(sortableList.ElementAt(i));
            }

        }

        public void DeleteReview()
        {
            dataProvider.DeleteReview(SelectedReview);
            ReviewList.RemoveAt(reviewList.IndexOf(reviewList.First(r => r.Name == SelectedReview.Name))); 
            //updating viewmodel, bugs with loading json?
        }
        public void Filter()
        {
            foreach(var r in ReviewList)
            {
                r.Categories.First(c => c.CategoryName == "Food").Weight = WeightFood;
                r.Categories.First(c => c.CategoryName == "Localization").Weight = WeightLocalization;
                r.Categories.First(c => c.CategoryName == "Music").Weight = WeightMusic;
                r.Categories.First(c => c.CategoryName == "Prices").Weight = WeightPrices;

            }
            var sortableList = ReviewList.OrderByDescending(r => r.Mean).ToList();

            ReviewList.Clear();
            for (int i = 0; i < sortableList.Count; i++)
            {
                ReviewList.Add(sortableList.ElementAt(i));
            }
        
        }
        public void EditReview()
        {
        //    Messenger.Default.Send<CurrentReviewMessage>(new CurrentReviewMessage
        //    {
        //        CurrentReview = SelectedReview

        //    });
            _navigationService.NavigateTo("Review");

        }
        public void AddReview()
        {
            //Messenger.Default.Send<CurrentReviewMessage>(new CurrentReviewMessage
            //{
            //    CurrentReview = new Review()

            //});
            _navigationService.NavigateTo("Review");
        }

    }
}
