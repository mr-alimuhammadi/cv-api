namespace cv_api.Models;

public class Client
{
    public Client(int id, string name, string avatar)
    {
        Id = id;
        Name = name;
        Avatar = avatar;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}