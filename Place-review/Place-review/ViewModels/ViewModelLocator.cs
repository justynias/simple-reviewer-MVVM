/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Place_review"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using System;
using Place_review.Additionals.NavigationService;


namespace Place_review.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

       

            var navigationService = new FrameNavigationService();
            navigationService.Configure("Main", new Uri("../MainWindow.xaml", UriKind.Relative));
            navigationService.Configure("ReviewList", new Uri("./Views/ReviewListView.xaml", UriKind.Relative));
            navigationService.Configure("Review", new Uri("./Views/ReviewView.xaml", UriKind.Relative));


            SimpleIoc.Default.Register<IFrameNavigationService>(() => navigationService);

            SimpleIoc.Default.Register<MainViewModel>(true);
            SimpleIoc.Default.Register<ReviewListViewModel>(true);
            SimpleIoc.Default.Register<ReviewViewModel>(true);


        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public ReviewListViewModel ReviewList
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReviewListViewModel>();
            }
        }

        public ReviewViewModel Review
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ReviewViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}