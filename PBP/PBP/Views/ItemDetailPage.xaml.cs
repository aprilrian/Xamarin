using PBP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace PBP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}