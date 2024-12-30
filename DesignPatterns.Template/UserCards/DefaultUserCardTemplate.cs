namespace DesignPatterns.Template.UserCards
{
    public class DefaultUserCardTemplate : UserCardTemplate
    {
        protected override string SetFooter()
        {
            return string.Empty;
        }

        protected override string SetPicture()
        {
            return $"<img src='/UserPictures/default-user.png' class='card-img-top'>";
        }
    }
}
