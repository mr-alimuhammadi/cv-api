namespace cv_api.Models;

public class Project
{
    public Project(int id, string name, string link)
    {
        Id = id;
        Name = name;
        Link = link;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Link { get; set; }
}