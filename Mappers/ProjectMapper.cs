using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class ProjectMapper
{
    public static Project ToProject(this ProjectPostDto projectPostDto, int id)
    {
        return new Project
        (
            id,
            projectPostDto.UserId,
            projectPostDto.Name,
            projectPostDto.FromYear,
            projectPostDto.ToYear,
            projectPostDto.Details,
            projectPostDto.Image,
            projectPostDto.Link
        );
    }
}