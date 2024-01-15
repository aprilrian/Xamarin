using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace PBP.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Dashboard";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://docs.google.com/document/d/1BgAWjCmvXvg5_RlZCZsOykAl81bf9Npn6f1nZL0cCI0/edit?usp=sharing"));
        }

        public ICommand OpenWebCommand { get; }
    }
}