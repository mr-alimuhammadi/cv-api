namespace cv_api.DTOs;

public class SocialMediaPostDto
{
    public int UserId { get; set; }
    public string Platform { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}

public class SocialMediaPutDto
{
    public string Platform { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
}