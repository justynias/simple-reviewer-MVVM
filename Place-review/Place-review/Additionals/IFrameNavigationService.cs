using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Place_review.Additionals.NavigationService
{
    public interface IFrameNavigationService : INavigationService
    {
        object Parameter { get; }
    }

}