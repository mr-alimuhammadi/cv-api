namespace cv_api.Models;

public class Testimonial
{
    public Testimonial(int id, int userId, string clientName, string clientJob, string clientImage, string comment)
    {
        Id = id;
        UserId = userId;
        ClientName = clientName;
        ClientJob = clientJob;
        ClientImage = clientImage;
        Comment = comment;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string ClientName { get; set; }
    public string ClientJob { get; set; }
    public string ClientImage { get; set; }
    public string Comment { get; set; }
}