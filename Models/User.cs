namespace cv_api.Models;

public class User
{
    public User(int id, string fullName, string profession, string profile, string careerObjectives, string phoneNumber,
        string email, string address, int happyClients,
        int workingHours,
        int awardsWon,
        int coffeeConsumed)
    {
        Id = id;
        FullName = fullName;
        Profession = profession;
        Profile = profile;
        CareerObjectives = careerObjectives;
        Contacts = new Contacts(phoneNumber, email, address);
        Facts = new Facts(happyClients, workingHours, awardsWon, coffeeConsumed);
    }

    public int Id { get; set; }

    // public string Password { get; set; }
    public string FullName { get; set; }
    public string Profession { get; set; }
    public string Profile { get; set; }
    public string CareerObjectives { get; set; }
    public Contacts Contacts { get; set; }
    public Facts Facts { get; set; }

    public List<SocialMedia> SocialMedias { get; set; } = [];
    public List<Profession> Professions { get; set; } = [];
    public List<Testimonial> Testimonials { get; set; } = [];
    public List<Client> Clients { get; set; } = [];
    public List<Education> Educations { get; set; } = [];
    public List<Experience> Experiences { get; set; } = [];
    public List<Certificate> Certificates { get; set; } = [];
    public List<Project> Projects { get; set; } = [];
}

public class Contacts(string phoneNumber, string email, string address)
{
    public string PhoneNumber { get; set; } = phoneNumber;
    public string Email { get; set; } = email;
    public string Address { get; set; } = address;
}

public class Facts(
    int happyClients,
    int workingHours,
    int awardsWon,
    int coffeeConsumed
)
{
    public int HappyClients { get; set; } = happyClients;
    public int WorkingHours { get; set; } = workingHours;
    public int AwardsWon { get; set; } = awardsWon;
    public int CoffeeConsumed { get; set; } = coffeeConsumed;
}