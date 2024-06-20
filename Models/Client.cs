namespace cv_api.Models;

public class Client
{
    public Client(int id, int userId, string name, string avatar)
    {
        Id = id;
        UserId = userId;
        Name = name;
        Avatar = avatar;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Avatar { get; set; }
}