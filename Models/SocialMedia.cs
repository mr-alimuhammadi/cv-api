namespace cv_api.Models;

public class SocialMedia
{
    public SocialMedia(int id, int userId, string platform, string link, string icon)
    {
        Id = id;
        UserId = userId;
        Platform = platform;
        Link = link;
        Icon = icon;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string Platform { get; set; }
    public string Link { get; set; }
    public string Icon { get; set; }
}