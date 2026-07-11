namespace IT_ELECTIVE_2_PRELIM_EXAM.Models;

// EXERCISE 1: Encapsulation - Private Fields
// The fields below are public. Your task:
// - Make all fields PRIVATE
// - Create public Properties with getters and setters
// - The property names should match the field names (PascalCase)
//
// Currently, the properties below are STUBS that return wrong values.
// Fix them to properly wrap the private fields.

public class Meal
{
    private string _name;
    private string _category;
    private string _area;
    private string _instructions;
    private string _thumbnail;
    private string _tags;
    private int _prepTimeMinutes;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public string Category
    {
        get => _category;
        set => _category = value;
    }

    public string Area
    {
        get => _area;
        set => _area = value;
    }

    public string Instructions
    {
        get => _instructions;
        set => _instructions = value;
    }

    public string Thumbnail
    {
        get => _thumbnail;
        set => _thumbnail = value;
    }

    public string Tags
    {
        get => _tags;
        set => _tags = value;
    }
    public int PrepTimeMinutes
    {
        get => _prepTimeMinutes;
        set => _prepTimeMinutes = value;
    }

    public Meal()
    {
        _name = "";
        _category = "";
        _area = "";
        _instructions = "";
        _thumbnail = "";
        _tags = "";

        _prepTimeMinutes = 0;
    }

    public Meal(string name, string category, string area)
    {
        _name = name;
        _category = category;
        _area = area;
        _instructions = "";
        _thumbnail = "";
        _tags = "";
        _prepTimeMinutes = 0;
    }

    public override string ToString()
    {
        return $"Meal: {Name} | Category: {Category} | Area: {Area}";
    }
}