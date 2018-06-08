using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
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

namespace Place_review.ViewModels
{
    public class ReviewViewModel : ViewModelBase
    {
        private Review currentReview;
        private IFrameNavigationService _navigationService;

        public ICommand SaveReviewCommand { get; private set; }
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
        public ReviewViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
            CurrentReview = new Review();

            SaveReviewCommand = new RelayCommand(SaveReview);
        }
        public void SaveReview()
        {
            Console.WriteLine(CurrentReview.Name);
        }
    }


}
