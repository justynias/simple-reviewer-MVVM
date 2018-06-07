using GalaSoft.MvvmLight;
using Place_review.Additionals.NavigationService;


namespace Place_review.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>


        IFrameNavigationService navigationService;

        public MainViewModel(IFrameNavigationService navigationService)
        {

            this.navigationService = navigationService;

        }
    }
}


  
    
