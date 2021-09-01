using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamWebApiClient.ViewModels;

namespace XamWebApiClient.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetails : ContentPage
    {
        public BookDetails()
        {
            InitializeComponent();

            BindingContext = Startup.Resolve<BookDetailsViewModel>();
        }
    }
}