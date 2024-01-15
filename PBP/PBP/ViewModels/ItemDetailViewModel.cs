using PBP.Models;
using PBP.Services;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PBP.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string itemId;
        private string text;
        private string description;

        public string Id { get; set; }

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

        public string ItemId
        {
            get => itemId;
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public Command UpdateItemCommand { get; }
        public Command DeleteItemCommand { get; }

        public ItemDetailViewModel()
        {
            UpdateItemCommand = new Command(async () => await ExecuteUpdateItemCommand());
            DeleteItemCommand = new Command(async () => await ExecuteDeleteItemCommand());
        }

        private async void LoadItemId(string itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.Id;
                Text = item.Text;
                Description = item.Description;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Load Item: {ex.Message}");
            }
        }

        private async Task ExecuteUpdateItemCommand()
        {
            try
            {
                var updatedItem = new Item { Id = Id, Text = Text, Description = Description };
                await DataStore.UpdateItemAsync(updatedItem);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Update Item: {ex.Message}");
            }
        }

        private async Task ExecuteDeleteItemCommand()
        {
            try
            {
                await DataStore.DeleteItemAsync(ItemId);
                // Optionally, navigate back to the previous page after deletion
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Failed to Delete Item: {ex.Message}");
            }
        }
    }
}
