using System;

class Calculator
{
    static double memory = 0;
    static double currentValue = 0;

    static void Main()
    {
        Console.WriteLine("������������ ����������� �� C#.");
        Console.WriteLine("��������: +, -, *, /, %, 1/x, x^2, sqrt, M+, M-, MR, exit");

        while (true)
        {
            Console.Write("������� ������ �����: ");
            if (!double.TryParse(Console.ReadLine(), out currentValue))
            {
                Console.WriteLine("������: ������� ������������ �����.");
                continue;
            }

            Console.Write("������� ��������: ");
            string op = Console.ReadLine();

            try
            {
                switch (op)
                {
                    case "+":
                    case "-":
                    case "*":
                    case "/":
                    case "%":
                        Console.Write("������� ������ �����: ");
                        if (!double.TryParse(Console.ReadLine(), out double num2))
                        {
                            Console.WriteLine("������: ������� ������������ �����.");
                            continue;
                        }
                        currentValue = Calculate(currentValue, num2, op);
                        Console.WriteLine("���������: " + currentValue);
                        break;
                    case "1/x":
                        if (currentValue == 0) throw new DivideByZeroException();
                        currentValue = 1 / currentValue;
                        Console.WriteLine("���������: " + currentValue);
                        break;
                    case "x^2":
                        currentValue = currentValue * currentValue;
                        Console.WriteLine("���������: " + currentValue);
                        break;
                    case "sqrt":
                        if (currentValue < 0) throw new ArgumentException("������ �� �������������� �����.");
                        currentValue = Math.Sqrt(currentValue);
                        Console.WriteLine("���������: " + currentValue);
                        break;
                    case "M+":
                        memory += currentValue;
                        Console.WriteLine("������: " + memory);
                        break;
                    case "M-":
                        memory -= currentValue;
                        Console.WriteLine("������: " + memory);
                        break;
                    case "MR":
                        Console.WriteLine("������: " + memory);
                        break;
                    case "exit":
                        return;
                    default:
                        Console.WriteLine("����������� ��������");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("������: " + ex.Message);
            }
        }
    }

    static double Calculate(double a, double b, string op)
    {
        return op switch
        {
            "+" => a + b,
            "-" => a - b,
            "*" => a * b,
            "/" => b == 0 ? throw new DivideByZeroException() : a / b,
            "%" => b == 0 ? throw new DivideByZeroException() : a % b,
            _ => throw new ArgumentException("����������� ��������"),
        };
    }
}
