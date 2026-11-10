using System.Dynamic;

class Program
{
    static void Main(string[] args)
    {
        List<Shape> shapes = new List<Shape>();
        Square s1 = new Square("Purple", 3);
        shapes.Add(s1);

        Rectangle s2 = new Rectangle("Green", 5, 6);
        shapes.Add(s2);

        Circle s3 = new Circle("Red", 8);
        shapes.Add(s3);

        foreach (Shape s in shapes)
        {
            string color = s.GetColor();
            double area = s.GetArea();
            Console.WriteLine($"The shape is {color} and has an area of {area}");
        }

    }
}
