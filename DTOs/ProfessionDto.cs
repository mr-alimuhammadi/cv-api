namespace cv_api.DTOs;

public class ProfessionPostDto
{
    public int UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class ProfessionPutDto
{
    public string Title { get; set; } = string.Empty;
    public string Details { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}