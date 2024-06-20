namespace cv_api.Models;

public class Project
{
    public Project(int id, int userId, string name, int fromYear, int toYear, string details, string image, string link)
    {
        Id = id;
        UserId = userId;
        Name = name;
        FromYear = fromYear;
        ToYear = toYear;
        Details = details;
        Image = image;
        Link = link;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public int FromYear { get; set; }
    public int ToYear { get; set; }
    public string Details { get; set; }
    public string Image { get; set; }
    public string Link { get; set; }
}