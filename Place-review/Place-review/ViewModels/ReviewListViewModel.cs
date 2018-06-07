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
   public class ReviewListViewModel: ViewModelBase
    {
        private IFrameNavigationService _navigationService;
        public ReviewListViewModel(IFrameNavigationService navigationService)
        {
            _navigationService = navigationService;
           

        }
    }
}
