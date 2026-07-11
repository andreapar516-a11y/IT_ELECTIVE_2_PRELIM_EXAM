namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 3 & 4: Constructors - Default and Parameterized
// The Category class has stub constructors. Your task:
// - EXERCISE 3: Fix the default constructor to initialize Name to "" and Description to ""
// - EXERCISE 4: Fix the parameterized constructor to assign name and description to the properties

public class Category
{
    public string Name { get; set; }
    public string Description { get; set; }

    public Category()
    {
        Name = "";
        Description = "";
    }

    public Category(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public override string ToString()
    {
        return $"Category: {Name} – {Description}";
    }
}
