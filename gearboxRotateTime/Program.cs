using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gearboxRotateTime
{
    class Program
    {
        public static double inputRPM = 60;
        public static int gears = -1;
        public static int numberOfGears = 40;
        public static int gearA = 100;
        public static int gearB = 10;
        public static double gearRatio;

        public static double outputRPM;

        public static double bilionYears;
        public static double years;
        public static double days;
        public static double hours;
        public static double minutes;
        public static double seconds;

        static void Main(string[] args)
        {
            Console.WriteLine("Input RPM:");
            inputRPM = Convert.ToDouble(ReadNumber());
            Console.Clear();

            Console.WriteLine("Gear A number of teeth:");
            gearA = Convert.ToInt32(ReadNumber());
            Console.Clear();

            Console.WriteLine("Gear B number of teeth:");
            gearB = Convert.ToInt32(ReadNumber());
            Console.Clear();

            Console.WriteLine("Number of gears:");
            numberOfGears = Convert.ToInt32(ReadNumber());
            Console.Clear();

            gearRatio = gearA / gearB;
            for (int j = 0; j < numberOfGears; j++)
            {
                gears++;
                outputRPM = inputRPM;
                for (int i = 0; i < gears; i++)
                {
                    outputRPM = outputRPM / gearRatio;
                }
                FromMinutes(1 / outputRPM);
                Console.WriteLine(gears + ". Gear:");
                Write("{=Red}" + bilionYears + "by " + "{/}" + " / " + "{=Green}" + years + "y " + days + "d " + hours + "h " + minutes + "m " + seconds + "s " + "{/}" + " / " + outputRPM + " RPM");
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        public static void FromMinutes(double totalMinutes)
        {
            seconds = Math.Round(totalMinutes * 60 % 60);
            minutes = Math.Round(totalMinutes % 60);
            hours = Math.Round(totalMinutes / 60 % 24);
            days = Math.Round(totalMinutes / 60 / 24 % 24);
            years = Math.Round(totalMinutes / 60 / 24 / 365);
            bilionYears = Math.Round(totalMinutes / 60 / 24 / 365 / 1000000000);
        }

        public static void Write(string msg)
        {
            string[] ss = msg.Split('{', '}');
            ConsoleColor c;
            foreach (var s in ss)
                if (s.StartsWith("/"))
                    Console.ResetColor();
                else if (s.StartsWith("=") && Enum.TryParse(s.Substring(1), out c))
                    Console.ForegroundColor = c;
                else
                    Console.Write(s);
        }

        public static string ReadNumber()
        {
            string number = Console.ReadLine();
            foreach (char c in number)
            {
                if (c < '0' || c > '9')
                {
                   number = null;
                }
            }
            if (number == null)
            {
                number = ReadNumber();
            }
            if (number.Length > 9)
            {
                Console.WriteLine("Number is too high");
                number = ReadNumber();
            }
            return number;
        }
    }
}
