namespace cv_api.Models;

public class Certificate
{
    public Certificate(int id, int userId, string course, string code, DateTime date, string image)
    {
        Id = id;
        UserId = userId;
        Course = course;
        Code = code;
        Date = date;
        Image = image;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public string Course { get; set; }
    public string Code { get; set; }
    public DateTime Date { get; set; }
    public string Image { get; set; }
}