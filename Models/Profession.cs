namespace cv_api.Models;

public class Profession
{
    public Profession(int id, int userId, string title, string details, string icon)
    {
        Id = id;
        UserId = userId;
        Title = title;
        Details = details;
        Icon = icon;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Details { get; set; }
    public string Icon { get; set; }
}