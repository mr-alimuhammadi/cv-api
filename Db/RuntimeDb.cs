using cv_api.Models;

namespace cv_api.Db;

public static class RuntimeDb
{
    public static List<User> Users { get; set; } = [];
    public static List<SocialMedia> SocialMedias { get; set; } = [];
    public static List<Profession> Professions { get; set; } = [];
    public static List<Testimonial> Testimonials { get; set; } = [];
    public static List<Client> Clients { get; set; } = [];
    public static List<Education> Educations { get; set; } = [];
    public static List<Experience> Experiences { get; set; } = [];
    public static List<Certificate> Certificates { get; set; } = [];
    public static List<Project> Projects { get; set; } = [];


    public static void SeedUserData()
    {
        Users.AddRange([
            new User(
                0,
                "Muhammad Alimuhammadi",
                "FullStack Devoleper",
                "with over 5 years of experience in designing and developing web applications. Looking for challenging roles in web and mobile industry to enhance my skills and provide my services to add value to the products of the organization. Highly motivated self learner with a passion for learning and keeping informed of the latest in technology.",
                "Lorem ipsum dolor sit amet consectetur adipisicing elit. Optio possimus ut ex, voluptatum dolor perspiciatis, delectus soluta non odit molestiae reprehenderit illum! Repellat vero consequuntur rem, mollitia, quae quibusdam ducimus autem, assumenda eveniet asperiores iure quisquam suscipit molestiae voluptas fugit quidem labore sapiente ut? Officiis facilis ducimus animi porro at!",
                "+989375988488",
                "mr.alimuhammadi@gmail.com",
                "Iran, Mashhad, Mofateh Street",
                556, 4785, 15, 1286
            ),
            new User(
                1,
                "John Doe",
                "Software Engineer",
                "An experienced software engineer with expertise in .NET and web development.",
                "To leverage my expertise in software engineering to contribute to innovative projects.",
                "123-456-7890",
                "john.doe@example.com",
                "123 Main St, Anytown, USA",
                15,
                1200,
                5,
                200
            ),
            new User(
                2,
                "Jane Smith",
                "Graphic Designer",
                "Creative graphic designer with a passion for visual storytelling.",
                "To design visually compelling graphics that enhance brand identity.",
                "987-654-3210",
                "jane.smith@example.com",
                "456 Elm St, Anytown, USA",
                25,
                1500,
                8,
                300
            ),
            new User(
                3,
                "Michael Johnson",
                "Project Manager",
                "Seasoned project manager with a track record of successfully leading projects.",
                "To manage projects effectively and deliver results on time and within budget.",
                "555-123-4567",
                "michael.johnson@example.com",
                "789 Oak St, Anytown, USA",
                20,
                1400,
                6,
                250
            ),
            new User(
                4,
                "Emily Davis",
                "Data Scientist",
                "Data scientist with expertise in machine learning and data analytics.",
                "To utilize data-driven insights to solve complex business problems.",
                "321-654-9870",
                "emily.davis@example.com",
                "101 Pine St, Anytown, USA",
                30,
                1600,
                7,
                280
            ),
            new User(
                5,
                "David Wilson",
                "Digital Marketer",
                "Digital marketer with a focus on SEO and online advertising.",
                "To drive business growth through effective digital marketing strategies.",
                "654-321-0987",
                "david.wilson@example.com",
                "202 Maple St, Anytown, USA",
                18,
                1300,
                4,
                220
            )
        ]);
    }
}