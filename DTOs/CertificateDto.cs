namespace cv_api.DTOs;

public class CertificatePostDto
{
    public int UserId { get; set; }
    public string Course { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Image { get; set; } = string.Empty;
}

public class CertificatePutDto
{
    public string Course { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public string Image { get; set; } = string.Empty;
}