Degree degree = Degree.A;
Console.WriteLine((int)degree);
Console.WriteLine((int)Degree.B);
Console.WriteLine(degree);
Console.WriteLine();
string[] names = Enum.GetNames<Degree>();

Degree[] degrees = Enum.GetValues<Degree>();

Array.Sort(degrees, (a,b) => -a.CompareTo(b));

Console.WriteLine("Wpisz jedna z ocen");

foreach (var item in degrees)
{
    Console.WriteLine(item);
}

string degreeString = Console.ReadLine();

try
{
    Degree studentDegree = Enum.Parse<Degree>(degreeString);
    Console.WriteLine($"Wpisales ocene {studentDegree}");
    Console.WriteLine(Convert(studentDegree));
}
catch (ArgumentException e)
{

    Console.WriteLine("Wpisales nieznana ocene");
}


static double Convert(Degree degree)
{
    return degree switch
    {
        Degree.A => 1.01,
        Degree.B => 2.0,
        Degree.C => 3.0,
        Degree.D => 4.0,
        Degree.E => 5.0,
        Degree.F => 6.0
    };
}

static string MessageFromDegree(Degree degree)
{
    return degree switch
    {
        Degree.F or Degree.E or Degree.D or Degree.C => "zdane",
        _ => "ujebane"
    };
}

public enum Degree
{
    A = 1,
    B,
    C,
    D,
    E,
    F
}











