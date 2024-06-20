using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class CertificateMapper
{
    public static Certificate ToCertificate(this CertificatePostDto certificatePostDto, int id)
    {
        return new Certificate
        (
            id,
            certificatePostDto.UserId,
            certificatePostDto.Course,
            certificatePostDto.Code,
            certificatePostDto.Date,
            certificatePostDto.Image
        );
    }
}