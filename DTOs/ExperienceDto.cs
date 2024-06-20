namespace cv_api.DTOs;

public class ExperiencePostDto
{
    public int UserId { get; set; }
    public int FromYear { get; set; }
    public int ToYear { get; set; }
    public string Job { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}

public class ExperiencePutDto
{
    public int FromYear { get; set; }
    public int ToYear { get; set; }
    public string Job { get; set; } = string.Empty;
    public string Company { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
}