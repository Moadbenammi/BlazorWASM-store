using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using blazor_store.Models;
using blazor_store.Services;
using System;

namespace blazor_store.Pages
{
    public partial class ProductDetails
    {
        [Parameter]
        public string _Id { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public Product Product { get; set; } = new Product();

        protected async override Task OnInitializedAsync()
        {
            Product = await ProductService.GetProductDetails(_Id);
        }

        protected async Task DeleteItem()
        {
            if (!String.IsNullOrEmpty(_Id))
            {
                await ProductService.DeleteProduct(_Id);

                navigationManager.NavigateTo("/");
            }

        }
    }
}