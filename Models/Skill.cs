namespace cv_api.Models;

public class Skill
{
    public Skill(int id, string name, int value)
    {
        Id = id;
        Name = name;
        Value = value;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public int Value { get; set; }
}