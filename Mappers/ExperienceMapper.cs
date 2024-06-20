using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class ExperienceMapper
{
    public static Experience ToExperience(this ExperiencePostDto experiencePostDto, int id)
    {
        return new Experience
        (
            id,
            experiencePostDto.UserId,
            experiencePostDto.FromYear,
            experiencePostDto.ToYear,
            experiencePostDto.Job,
            experiencePostDto.Company,
            experiencePostDto.Details
        );
    }
}