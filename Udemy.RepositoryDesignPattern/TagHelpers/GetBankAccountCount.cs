using Microsoft.AspNetCore.Razor.TagHelpers;
using Udemy.RepositoryDesignPattern.Data.Context;

namespace Udemy.RepositoryDesignPattern.TagHelpers
{
    [HtmlTargetElement("getaccountcount")]
    public class GetBankAccountCount : TagHelper
    {
        private readonly BankContext _context;

        public int AppUserId { get; set; }
        public GetBankAccountCount(BankContext context)
        {
            _context = context;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var accountCount = _context.Accounts.Count(x=>x.AppUserId == AppUserId);
            var html = $"<span class='badge bg-warning'>{accountCount}</span>";
            output.Content.SetHtmlContent(html);
        }
    }
}
