namespace cv_api.DTOs;

public class ClientPostDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}

public class ClientPutDto
{
    public string Name { get; set; } = string.Empty;
    public string Avatar { get; set; } = string.Empty;
}