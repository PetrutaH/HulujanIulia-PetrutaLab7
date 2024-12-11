using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLiteNetExtensions.Attributes;
using HulujanIulia_PetrutaLab7.Models;
namespace HulujanIulia_PetrutaLab7;


public partial class ShopEntryPage : ContentPage
{
	public ShopEntryPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        listView.ItemsSource = await App.Database.GetShopsAsync();
    }
    async void OnShopAddedClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopPage
        {
            BindingContext = new Shop()
        });
    }
    async void OnListViewItemSelected(object sender,SelectedItemChangedEventArgs e)
    {
        if (e.SelectedItem != null)
        {
            await Navigation.PushAsync(new ShopPage
            {
                BindingContext = e.SelectedItem as Shop
            });
        }
    }
}