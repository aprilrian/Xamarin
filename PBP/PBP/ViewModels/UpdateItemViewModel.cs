using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using PBP.Models;

namespace PBP.ViewModels
{
    public class UpdateItemViewModel : BaseViewModel
    {
        private string text;
        private string description;

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public Command UpdateItemCommand { get; }

        public UpdateItemViewModel()
        {
            Title = "Update Item";
            UpdateItemCommand = new Command(async () => await ExecuteUpdateItemCommand());
        }

        private async Task ExecuteUpdateItemCommand()
        {
            try
            {
                // Call the update method from your data store service
                var updatedItem = new Item { Id = Id, Text = Text, Description = Description };
                await DataStore.UpdateItemAsync(updatedItem);

                // Optionally, navigate back to the previous page after updating
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Update Item: {ex.Message}");
            }
        }
    }
}

