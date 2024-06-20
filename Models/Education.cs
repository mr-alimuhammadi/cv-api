namespace cv_api.Models;

public class Education
{
    public Education(int id, int userId, int endYear, string major, string school, string details)
    {
        Id = id;
        UserId = userId;
        EndYear = endYear;
        Major = major;
        School = school;
        Details = details;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public int EndYear { get; set; }
    public string Major { get; set; }
    public string School { get; set; }
    public string Details { get; set; }
}