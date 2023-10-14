namespace Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        ShapeManager sm = new ShapeManager();

        Square sq1 = new Square(10, 20, 30);
        Circle c1 = new Circle(10, 20, 30);
        TextArea t1 = new TextArea(10, 20, 30, 40);

        sm.Add(sq1);
        sm.Add(c1);
        sm.Add(t1);

        sm.ListAll();

        Console.ReadKey();
    }
}
