using StudentLifeSimulation;
using Lab3CSharp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Lab#10");
        Console.WriteLine("         Task 1 ");
        try
        {
            Trapeze[] trapezes = new Trapeze[]
            {
                        new Trapeze(3,3,3,0),
                        new Trapeze(5,7,2,1),
                        new Trapeze(8,2,6,2),
                        new Trapeze(7,9,2,3),
                        new Trapeze()
            };

            foreach (var trapez in trapezes)
            {
                trapez.DisplayLengths();
                Console.WriteLine("Color: " + trapez.C);
                Console.WriteLine("Perimeter: " + trapez.CalculatePerimeter());
                Console.WriteLine("Area: " + trapez.CalculateArea());
                Console.WriteLine("Square: " + trapez.IsSquare());
                Console.WriteLine();
            }

            Console.WriteLine("Try get and set");

            Trapeze trapeze = new Trapeze(1, 1, 1, 1);

            Console.WriteLine("Trapeze before changes");
            trapeze.DisplayLengths();
            Console.WriteLine("Color: " + trapeze.C);
            Console.WriteLine();

            Console.Write("Input base a: ");
            int a = Convert.ToInt32(Console.ReadLine());
            trapeze.A = a;

            Console.Write("Input base b: ");
            int b = Convert.ToInt32(Console.ReadLine());
            trapeze.B = b;

            Console.Write("Input height h: ");
            int h = Convert.ToInt32(Console.ReadLine());
            trapeze.H = h;
            Console.WriteLine();

            Console.WriteLine("Trapeze after changes");
            trapeze.DisplayLengths();
            Console.WriteLine("Color: " + trapeze.C);
            Console.WriteLine("Perimeter: " + trapeze.CalculatePerimeter());
            Console.WriteLine("Area: " + trapeze.CalculateArea());
            Console.WriteLine("Square: " + trapeze.IsSquare());
            Console.WriteLine();
        }
        catch (ArrayTypeMismatchException e)
        {
            Console.WriteLine($"Array type mismatch error: {e.Message}");
        }
        catch (DivideByZeroException e)
        {
            Console.WriteLine($"Division by zero error: {e.Message}");
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine($"Index out of range error: {e.Message}");
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine($"Invalid cast error: {e.Message}");
        }
        catch (OutOfMemoryException e)
        {
            Console.WriteLine($"Out of memory error: {e.Message}");
        }
        catch (OverflowException e)
        {
            Console.WriteLine($"Overflow error: {e.Message}");
        }
        catch (StackOverflowException e)
        {
            Console.WriteLine($"Stack overflow error: {e.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine($"General error: {e.Message}");
        }

        Console.WriteLine("         Task 2 ");
        Console.WriteLine("Привіт, студенте!");
        StudentLife studentLife = new StudentLife("Іван", 10, 30);
        studentLife.SimulateStudentLife();
    }
}