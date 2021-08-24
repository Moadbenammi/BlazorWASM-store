using blazor_store.Models;
using Microsoft.AspNetCore.Components;

namespace blazor_store.Pages
{
    public partial class ProductPresentation
    {
        [Parameter]
        public Product product { get; set; }
    }
}