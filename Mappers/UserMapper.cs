using cv_api.DTOs;
using cv_api.Models;

namespace cv_api.Mappers;

public static class UserMapper
{
    public static UserPostDto ToUserPostDto(this User user)
    {
        return new UserPostDto
        {
            FullName = user.FullName,
            Profession = user.Profession,
            Profile = user.Profile,
            CareerObjectives = user.CareerObjectives,
            Contacts =
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address
            },
            Facts =
            {
                HappyClients = user.HappyClients,
                WorkingHours = user.WorkingHours,
                AwardsWon = user.AwardsWon,
                CoffeeConsumed = user.CoffeeConsumed
            }
        };
    }

    public static UserPutDto ToUserPutDto(this User user)
    {
        return new UserPutDto
        {
            FullName = user.FullName,
            Profession = user.Profession,
            Profile = user.Profile,
            CareerObjectives = user.CareerObjectives,
            Contacts =
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address
            },
            Facts =
            {
                HappyClients = user.HappyClients,
                WorkingHours = user.WorkingHours,
                AwardsWon = user.AwardsWon,
                CoffeeConsumed = user.CoffeeConsumed
            }
        };
    }

    public static UserGetDto ToUserGetDto(this User user)
    {
        return new UserGetDto
        {
            Id = user.Id,
            FullName = user.FullName,
            Profession = user.Profession,
            Profile = user.Profile,
            CareerObjectives = user.CareerObjectives,
            Contacts =
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Address = user.Address
            },
            Facts =
            {
                HappyClients = user.HappyClients,
                WorkingHours = user.WorkingHours,
                AwardsWon = user.AwardsWon,
                CoffeeConsumed = user.CoffeeConsumed
            },
            SocialMediasIds = user.SocialMediasIds,
            CertificatesIds = user.CertificatesIds,
            ClientsIds = user.ClientsIds,
            EducationsIds = user.EducationsIds,
            ExperiencesIds = user.ExperiencesIds,
            ProfessionsIds = user.ProfessionsIds,
            TestimonialsIds = user.TestimonialsIds,
            ProjectsIds = user.ProjectsIds
        };
    }

    public static User ToUser(this UserPostDto userPostDto, int id)
    {
        return new User(
            id,
            userPostDto.FullName,
            userPostDto.Profession,
            userPostDto.Profile,
            userPostDto.CareerObjectives,
            userPostDto.Contacts.PhoneNumber,
            userPostDto.Contacts.Email,
            userPostDto.Contacts.Address,
            userPostDto.Facts.HappyClients,
            userPostDto.Facts.WorkingHours,
            userPostDto.Facts.AwardsWon,
            userPostDto.Facts.CoffeeConsumed
        );
    }
}