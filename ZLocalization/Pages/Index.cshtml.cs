using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Localization;

namespace ZLocalization.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IStringLocalizer<SharedResource> _localizer;

        public int IndexId{get;set;}

        public IndexModel(IStringLocalizer<SharedResource> localizer)
        {
            _localizer = localizer;
            // this.IndexId=localizer.GetType()
        }

        public string? Welcome { get; set; }

        public void OnGet()
        {
            var culture = CultureInfo.CurrentUICulture.Name;
            Console.WriteLine($"Current UI Culture: {culture}");

            Welcome = _localizer["Welcome"];
            Console.WriteLine($"Welcome from localizer: {Welcome}");
            var text= _localizer["Welcome"];
            Console.WriteLine(text.Value);
            Console.WriteLine(text.ResourceNotFound);

        }
    }
}
