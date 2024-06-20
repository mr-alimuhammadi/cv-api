using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class SocialMediaMapper
{
    public static SocialMedia ToSocialMedia(this SocialMediaPostDto socialMediaPostDto, int id)
    {
        return new SocialMedia
        (
            id,
            socialMediaPostDto.UserId,
            socialMediaPostDto.Platform,
            socialMediaPostDto.Link,
            socialMediaPostDto.Icon
        );
    }
}