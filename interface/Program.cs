// Задача на интерфейсы.
// Два интерфейса - IMovable - Move(double dx, double dy),
// IRotatable - Rotate(double angle) - сдвиг на(dx, dy)
// и поворот относительно начала координат.
// И четыре класса - точка, треугольник, прямоугольник и окружность.
// Необходимые поля и свойства определите сами.
// Надо чтобы каждый их них реализовывал оба интерфейса.

void Main()
{
    var ABC = new Triangle(new Point(5, 5), new Point(-5, 5), new Point(0, 0));
    var ABCD = new Rectangle(new Point(5, 5), new Point(-5, 5), new Point(-5, -5), new Point(5, -5));
    var BCircle = new Circle(new Point(-5, 5), 4);

    ABC.Move(1, 1);
    ABCD.Move(1, 1);
    BCircle.Move(1, 1);

    Console.WriteLine(ABC);
    Console.WriteLine(ABCD);
    Console.WriteLine(BCircle);

    ABC.Rotate(Math.PI);
    ABCD.Rotate(Math.PI);
    BCircle.Rotate(Math.PI);

    Console.WriteLine(ABC);
    Console.WriteLine(ABCD);
    Console.WriteLine(BCircle);
}
Main();

public interface IMovable
{
    void Move(double dx, double dy);
}

public interface IRotatable
{
    void Rotate(double angle);
}


public interface IPoint : IMovable, IRotatable
{
    double X { get; set; }
    double Y { get; set; }
}

public class Point : IPoint
{
    public double X { get; set; }
    public double Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    void IMovable.Move(double dx, double dy)
    {
        X = X + dx;
        Y = Y + dy;
    }

    void IRotatable.Rotate(double angle)
    {
        double oldX = X;
        X = X * Math.Cos(angle) - Y * Math.Sin(angle);
        Y = oldX * Math.Sin(angle) + Y * Math.Cos(angle);
    }

    public override string ToString()
    {
        return $"({Math.Round(X, 10)}, {Math.Round(Y, 10)})";
    }
}

public class Triangle
{
    private IPoint A { get; set; }
    private IPoint B { get; set; }
    private IPoint C { get; set; }

    public Triangle(IPoint a, IPoint b, IPoint c)
    {
        A = a;
        B = b;
        C = c;
    }

    public void Move(double dx, double dy)
    {
        A.Move(dx, dy);
        B.Move(dx, dy);
        C.Move(dx, dy);
    }

    public void Rotate(double angle)
    {
        A.Rotate(angle);
        B.Rotate(angle);
        C.Rotate(angle);
    }

    public override string ToString()
    {
        return $"Треугольник: {A} {B} {C}";
    }
}

public class Rectangle
{
    private IPoint A { get; set; }
    private IPoint B { get; set; }
    private IPoint C { get; set; }
    private IPoint D { get; set; }

    public Rectangle(IPoint a, IPoint b, IPoint c, IPoint d)
    {
        A = a;
        B = b;
        C = c;
        D = d;
    }

    public void Move(double dx, double dy)
    {
        A.Move(dx, dy);
        B.Move(dx, dy);
        C.Move(dx, dy);
        D.Move(dx, dy);
    }

    public void Rotate(double angle)
    {
        A.Rotate(angle);
        B.Rotate(angle);
        C.Rotate(angle);
        D.Rotate(angle);
    }

    public override string ToString()
    {
        return $"Прямоугольник: {A} {B} {C} {D}";
    }
}

public class Circle
{
    public IPoint CenterPoint { get; set; }
    public double Radius { get; set; }

    public Circle(IPoint centerPoint, double radius)
    {
        CenterPoint = centerPoint;
        Radius = radius;
    }

    public void Move(double dx, double dy) => CenterPoint.Move(dx, dy);
    public void Rotate(double angle) => CenterPoint.Rotate(angle);

    public override string ToString()
    {
        return $"Центр окружности: {CenterPoint} Его радиус: {Radius}";
    }
}