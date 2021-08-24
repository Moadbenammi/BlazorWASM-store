using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using blazor_store.Models;
using blazor_store.Services;

namespace blazor_store.Pages
{
    public partial class ProductsOverview
    {
        public IEnumerable<Product> Products { get; set; }

        [Inject]
        public IProductService ProductService { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Products = (await ProductService.GetProducts()).ToList();
        }
    }
}