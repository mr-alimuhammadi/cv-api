namespace cv_api.Models;

public class Experience
{
    public Experience(int id, int fromYear, int toYear, string job, string company, string details)
    {
        Id = id;
        FromYear = fromYear;
        ToYear = toYear;
        Job = job;
        Company = company;
        Details = details;
    }

    public int Id { get; set; }
    public int FromYear { get; set; }
    public int ToYear { get; set; }
    public string Job { get; set; }
    public string Company { get; set; }
    public string Details { get; set; }
}