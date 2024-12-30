using DesignPatterns.Template.Models;
using System;
using System.Text;

namespace DesignPatterns.Template.UserCards
{
    public abstract class UserCardTemplate
    {
        protected AppUser AppUser { get; set; }

        public void SetUser(AppUser appUser)
        {
            AppUser = appUser;
        }

        public string Build()
        {
            if (AppUser == null) throw new ArgumentNullException(nameof(AppUser));

            var template = $@"
                <div class='card' style='width: 18rem;'>
                    {SetPicture()}
                    <div class='card-body'>
                            <h5 class='card-title'>{AppUser.UserName}</h5>
                            <p class='card-text'>{AppUser.Description}</p>
                            {SetFooter()}
                    </div>
                </div>";

            return template;
        }


        protected abstract string SetFooter();
        protected abstract string SetPicture();
    }
}
