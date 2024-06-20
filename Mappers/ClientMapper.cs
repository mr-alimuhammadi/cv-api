using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class ClientMapper
{
    public static Client ToClient(this ClientPostDto clientPostDto, int id)
    {
        return new Client
        (
            id,
            clientPostDto.UserId,
            clientPostDto.Name,
            clientPostDto.Avatar
        );
    }
}