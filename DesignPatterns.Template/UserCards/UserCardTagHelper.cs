using DesignPatterns.Template.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DesignPatterns.Template.UserCards
{
    /// <summary>
    /// <user-card app-user=''></user-card>
    /// </summary>
    public class UserCardTagHelper : TagHelper
    {
        public AppUser AppUser { get; set; }
        private readonly IHttpContextAccessor _contextAccessor;

        public UserCardTagHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            UserCardTemplate userCardTemplate;
            if (_contextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                userCardTemplate = new PrimeUserCardTemplate();
            }
            else
            {
                userCardTemplate = new DefaultUserCardTemplate();
            }

            userCardTemplate.SetUser(AppUser);
            output.Content.SetHtmlContent(userCardTemplate.Build());
        }
    }
}
