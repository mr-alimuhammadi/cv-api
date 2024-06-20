namespace cv_api.DTOs;

public class UserPostDto
{
    public string FullName { get; set; } = string.Empty;
    public string Profession { get; set; } = string.Empty;
    public string Profile { get; set; } = string.Empty;
    public string CareerObjectives { get; set; } = string.Empty;
    public Contacts Contacts { get; set; } = new();
    public Facts Facts { get; set; } = new();
}

public class UserPutDto
{
    public string FullName { get; set; } = string.Empty;
    public string Profession { get; set; } = string.Empty;
    public string Profile { get; set; } = string.Empty;
    public string CareerObjectives { get; set; } = string.Empty;
    public Contacts Contacts { get; set; } = new();
    public Facts Facts { get; set; } = new();
}

public class UserGetDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Profession { get; set; } = string.Empty;
    public string Profile { get; set; } = string.Empty;
    public string CareerObjectives { get; set; } = string.Empty;
    public Contacts Contacts { get; set; } = new();
    public Facts Facts { get; set; } = new();

    public List<int> SocialMediasIds { get; set; } = [];
    public List<int> ProfessionsIds { get; set; } = [];
    public List<int> TestimonialsIds { get; set; } = [];
    public List<int> ClientsIds { get; set; } = [];
    public List<int> EducationsIds { get; set; } = [];
    public List<int> ExperiencesIds { get; set; } = [];
    public List<int> CertificatesIds { get; set; } = [];
    public List<int> ProjectsIds { get; set; } = [];
}

public class Contacts
{
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
}

public class Facts
{
    public int HappyClients { get; set; }
    public int WorkingHours { get; set; }
    public int AwardsWon { get; set; }
    public int CoffeeConsumed { get; set; }
}