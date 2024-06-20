using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class EducationMapper
{
    public static Education ToEducation(this EducationPostDto educationPostDto, int id)
    {
        return new Education
        (
            id,
            educationPostDto.UserId,
            educationPostDto.EndYear,
            educationPostDto.Major,
            educationPostDto.School,
            educationPostDto.Details
        );
    }
}