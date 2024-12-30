namespace DesignPatterns.Template.UserCards
{
    public class PrimeUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            return $@"<a href='#' class='btn btn-primary'>Mesaj Gönder</a>
                      <a href='#' class='btn btn-primary'>Detaylı Profil</a>";
        }

        protected override string SetPicture()
        {
            return $"<img src='{AppUser.PictureUrl}' class='card-img-top'>";
        }
    }
}
