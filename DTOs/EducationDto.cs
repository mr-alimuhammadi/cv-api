namespace cv_api.DTOs;

public class EducationPostDto
{
    public int UserId { get; set; }
    public int EndYear { get; set; }
    public string Major { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}

public class EducationPutDto
{
    public int EndYear { get; set; }
    public string Major { get; set; } = string.Empty;
    public string School { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}