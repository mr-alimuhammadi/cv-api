using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class ProfessionMapper
{
    public static Profession ToProfession(this ProfessionPostDto professionPostDto, int id)
    {
        return new Profession
        (
            id,
            professionPostDto.UserId,
            professionPostDto.Title,
            professionPostDto.Details,
            professionPostDto.Icon
        );
    }
}