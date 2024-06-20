namespace cv_api.DTOs;

public class ProjectPostDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int FromYear { get; set; }
    public int ToYear { get; set; }
    public string Details { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}

public class ProjectPutDto
{
    public string Name { get; set; } = string.Empty;
    public int FromYear { get; set; }
    public int ToYear { get; set; }
    public string Details { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}