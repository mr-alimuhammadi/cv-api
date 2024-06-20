namespace cv_api.DTOs;

public class TestimonialPostDto
{
    public int UserId { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string ClientJob { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}

public class TestimonialPutDto
{
    public string ClientName { get; set; } = string.Empty;
    public string ClientJob { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public string Comment { get; set; } = string.Empty;
}