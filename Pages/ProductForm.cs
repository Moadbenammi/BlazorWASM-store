using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using blazor_store.Models;
using blazor_store.Services;
using System;

namespace blazor_store.Pages
{
    public partial class ProductForm
    {
        //State Management :
        protected string Message = string.Empty;
        protected bool Saved;

        [Inject]
        public NavigationManager navigationManager { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        [Parameter]
        public string _Id { get; set; }

        public Product Product { get; set; } = new Product();

        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            if (!String.IsNullOrEmpty(_Id))
            {
                Product = await ProductService.GetProductDetails(_Id);
            }
        }

        protected async Task HandleValidRequest()
        {
            if (String.IsNullOrEmpty(_Id))
            {
                var res = await ProductService.AddProduct(Product);

                if (res != null)
                {
                    Saved = true;
                    Message = "Product has been added!";
                }
                else
                {
                    Message = "Something went wrong";
                }
            }
            else
            {
                await ProductService.UpdateProduct(Product);
                Saved = true;
                Message = "Item has been updated";
            }
        }

        protected void HandleInvalidRequest()
        {
            Message = "Failed to submit form";
        }

        protected void goToHome()
        {
            navigationManager.NavigateTo("/");
        }

    }
}