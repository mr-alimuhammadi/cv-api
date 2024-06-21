using System.Text.Json;
using cv_api.Models;

namespace cv_api.Db;

public class JsonContext
{
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "Db/database.json");

    public JsonContext()
    {
        Db = new Database();
        Load();
        if (IsDbEmpty())
        {
            SeedData();
            Save();
        }
    }

    public Database Db { get; }


    public void Save()
    {
        var jsonData = JsonSerializer.Serialize(Db, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(_filePath, jsonData);
    }

    public void Load()
    {
        if (!File.Exists(_filePath)) throw new Exception($"database.json not found! at {_filePath}");

        var jsonData = File.ReadAllText(_filePath);
        var context = JsonSerializer.Deserialize<Database>(jsonData);
        if (context == null) return;

        Db.Users = context.Users;
        Db.SocialMedias = context.SocialMedias;
        Db.Professions = context.Professions;
        Db.Testimonials = context.Testimonials;
        Db.Clients = context.Clients;
        Db.Educations = context.Educations;
        Db.Experiences = context.Experiences;
        Db.Certificates = context.Certificates;
        Db.Projects = context.Projects;
    }

    private void SeedData()
    {
        Db.Users = new List<User>
        {
            new(1, "John Doe", "Software Developer", "profile1.jpg", "To build amazing software", "123-456-7890",
                "john@example.com", "123 Main St", 10, 1000, 5, 100, "default.png")
            {
                SocialMediasIds = [1],
                CertificatesIds = [1],
                ClientsIds = [1],
                EducationsIds = [1],
                ExperiencesIds = [1],
                ProfessionsIds = [1],
                ProjectsIds = [1],
                TestimonialsIds = [1]
            },
            new(2, "Jane Smith", "Data Scientist", "profile2.jpg", "To analyze and interpret data", "987-654-3210",
                "jane@example.com", "456 Elm St", 15, 2000, 10, 200, "default.png")
            {
                SocialMediasIds = [2],
                CertificatesIds = [2],
                ClientsIds = [2],
                EducationsIds = [2],
                ExperiencesIds = [2],
                ProfessionsIds = [2],
                ProjectsIds = [2],
                TestimonialsIds = [2]
            }
        };

        Db.SocialMedias = new List<SocialMedia>
        {
            new(1, 1, "LinkedIn", "https://linkedin.com/johndoe", "linkedin-icon.png"),
            new(2, 2, "Twitter", "https://twitter.com/janesmith", "twitter-icon.png")
        };

        Db.Professions = new List<Profession>
        {
            new(1, 1, "Developer", "Developing amazing applications", "developer-icon.png"),
            new(2, 2, "Scientist", "Analyzing data", "scientist-icon.png")
        };

        Db.Testimonials = new List<Testimonial>
        {
            new(1, 1, "Client A", "Manager", "clientA.jpg", "Great job!"),
            new(2, 2, "Client B", "CEO", "clientB.jpg", "Excellent work!")
        };

        Db.Clients = new List<Client>
        {
            new(1, 1, "Client A", "clientA.jpg"),
            new(2, 2, "Client B", "clientB.jpg")
        };

        Db.Educations = new List<Education>
        {
            new(1, 1, 2010, "Computer Science", "University A", "Details about University A"),
            new(2, 2, 2012, "Data Science", "University B", "Details about University B")
        };

        Db.Experiences = new List<Experience>
        {
            new(1, 1, 2015, 2020, "Developer", "Company A", "Developed applications"),
            new(2, 2, 2013, 2018, "Scientist", "Company B", "Analyzed data")
        };

        Db.Certificates = new List<Certificate>
        {
            new(1, 1, "Course A", "Code A", DateTime.Parse("2020-01-01"), "certificateA.jpg"),
            new(2, 2, "Course B", "Code B", DateTime.Parse("2021-01-01"), "certificateB.jpg")
        };

        Db.Projects = new List<Project>
        {
            new(1, 1, "Project A", 2019, 2020, "Details about Project A", "projectA.jpg", "https://linktoA.com"),
            new(2, 2, "Project B", 2020, 2021, "Details about Project B", "projectB.jpg", "https://linktoB.com")
        };
    }

    public bool IsDbEmpty()
    {
        return !Db.Users.Any() && !Db.SocialMedias.Any() && !Db.Professions.Any() && !Db.Testimonials.Any() &&
               !Db.Clients.Any() && !Db.Educations.Any() && !Db.Experiences.Any() && !Db.Certificates.Any() &&
               !Db.Projects.Any();
    }
}

public class Database
{
    public List<User> Users { get; set; } = new();
    public List<SocialMedia> SocialMedias { get; set; } = new();
    public List<Profession> Professions { get; set; } = new();
    public List<Testimonial> Testimonials { get; set; } = new();
    public List<Client> Clients { get; set; } = new();
    public List<Education> Educations { get; set; } = new();
    public List<Experience> Experiences { get; set; } = new();
    public List<Certificate> Certificates { get; set; } = new();
    public List<Project> Projects { get; set; } = new();
}