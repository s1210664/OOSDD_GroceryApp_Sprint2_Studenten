using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grocery.App.Views;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;
using System.Collections.ObjectModel;
using Grocery.Core.Data.Repositories;

namespace Grocery.App.ViewModels
{
    [QueryProperty(nameof(GroceryList), nameof(GroceryList))]
    public partial class GroceryListItemsViewModel : BaseViewModel
    {
        private readonly IGroceryListItemsService _groceryListItemsService;
        private readonly IProductService _productService;
        public ObservableCollection<GroceryListItem> MyGroceryListItems { get; set; } = [];
        public ObservableCollection<Product> AvailableProducts { get; set; } = [];

        [ObservableProperty]
        GroceryList groceryList = new(0, "None", DateOnly.MinValue, "", 0);

        public GroceryListItemsViewModel(IGroceryListItemsService groceryListItemsService, IProductService productService)
        {
            _groceryListItemsService = groceryListItemsService;
            _productService = productService;
            Load(groceryList.Id);
        }

        private void Load(int id)
        {
            MyGroceryListItems.Clear();
            foreach (var item in _groceryListItemsService.GetAllOnGroceryListId(id)) MyGroceryListItems.Add(item);
            GetAvailableProducts(id);
        }

        private void GetAvailableProducts(int id)
        {
            AvailableProducts.Clear();
            List<Product> products = _productService.GetAll(); 
            List<GroceryListItem> groceryProducts = _groceryListItemsService.GetAllOnGroceryListId(id);
            foreach (Product product in products)
            {
                Console.WriteLine(product.Name);
                bool aanwezig = false;
                foreach (GroceryListItem groceryProduct in groceryProducts)
                {
                    if (groceryProduct.ProductId == product.Id)
                    {
                        aanwezig = true;
                    }

                }

                if (!aanwezig && product.Stock > 0)
                {
                    AvailableProducts.Add(product);
                }

                
            }
        }

        partial void OnGroceryListChanged(GroceryList value)
        {
            Load(value.Id);
        }

        [RelayCommand]
        public async Task ChangeColor()
        {
            Dictionary<string, object> paramater = new() { { nameof(GroceryList), GroceryList } };
            await Shell.Current.GoToAsync($"{nameof(ChangeColorView)}?Name={GroceryList.Name}", true, paramater);
        }
        [RelayCommand]
        public void AddProduct(Product product)
        {
            if (_productService.GetAll().Contains(product) && product.Id > 0)
            {
                GroceryListItem item = new GroceryListItem(0, GroceryList.Id, product.Id, 1);
                item.Product = product;
                product.Stock--;
                _productService.Update(product);
                MyGroceryListItems.Add(item);
                _groceryListItemsService.Add(item);
                
                GetAvailableProducts(GroceryList.Id);
                OnGroceryListChanged(GroceryList);
            }
        }
    }
}
