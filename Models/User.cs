namespace cv_api.Models;

public class User
{
    public User(int id, string fullName, string profession, string profile, string careerObjectives, string phoneNumber,
        string email, string address, int happyClients,
        int workingHours,
        int awardsWon,
        int coffeeConsumed, string avatar)
    {
        Id = id;
        FullName = fullName;
        Profession = profession;
        Profile = profile;
        CareerObjectives = careerObjectives;
        PhoneNumber = phoneNumber;
        Email = email;
        Address = address;
        HappyClients = happyClients;
        WorkingHours = workingHours;
        AwardsWon = awardsWon;
        CoffeeConsumed = coffeeConsumed;
        Avatar = avatar;
    }

    public int Id { get; set; }

    // public string Password { get; set; }
    public string FullName { get; set; }
    public string Avatar { get; set; }
    public string Profession { get; set; }
    public string Profile { get; set; }
    public string CareerObjectives { get; set; }

    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    public int HappyClients { get; set; }
    public int WorkingHours { get; set; }
    public int AwardsWon { get; set; }
    public int CoffeeConsumed { get; set; }

    public List<int> SocialMediasIds { get; set; } = [];
    public List<int> ProfessionsIds { get; set; } = [];
    public List<int> TestimonialsIds { get; set; } = [];
    public List<int> ClientsIds { get; set; } = [];
    public List<int> EducationsIds { get; set; } = [];
    public List<int> ExperiencesIds { get; set; } = [];
    public List<int> CertificatesIds { get; set; } = [];
    public List<int> ProjectsIds { get; set; } = [];
}