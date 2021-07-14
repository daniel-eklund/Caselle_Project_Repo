using System;

namespace Caselle_Project
{
    class Triangle : IShape
    {
        // We can define the whole triangle now, or one side at a time
        public Triangle(string s_1 = "", string s_2 = "", string s_3 = "") 
        {
            s1 = s_1;
            s2 = s_2;
            s3 = s_3;
        }

        public string s1 { get; set; }
        public string s2 { get; set; }
        public string s3 { get; set; }

        // Returns area of triangle using Heron's formula
        // s = (a+b+c)/2
        // a = sqrt[s(s-a)(s-b)(s-c)]
        public double Area()
        {
            double a = Convert.ToDouble(s1);
            double b = Convert.ToDouble(s2);
            double c = Convert.ToDouble(s3);
            
            double s = (a + b + c) / 2;

            return Math.Round(Math.Sqrt(s * ((s - a) * (s - b) * (s - c))), 2);
        }

        public double[] Angles()
        {
            double[] angles = new double[3] { 0, 0, 0 };
            // Calculate angles here
            // cos(X) = y^2 + z^2 − x^2 / 2yz
            double a = Convert.ToDouble(s1);
            double b = Convert.ToDouble(s2);
            double c = Convert.ToDouble(s3);
            double a_2 = Math.Pow(a, 2);
            double b_2 = Math.Pow(b, 2);
            double c_2 = Math.Pow(c, 2);

            angles[0] = Math.Round((180 / Math.PI) * Math.Acos((b_2 + c_2 - a_2) / (2 * (b * c))), 2);
            angles[1] = Math.Round((180 / Math.PI) * Math.Acos((a_2 + c_2 - b_2) / (2 * (a * c))), 2);
            angles[2] = 180 - angles[0] - angles[1];

            return angles; 
        }

        // Returns angle type
        private string angleType(double a, double b, double c)
        {
            if (a + b > c) return " acute";
            if (a + b < c) return " obtuse";
            if (a + b == c) return " right";

            return "";
        }

        // Returns side type
        private string sideType(double a, double b, double c)
        {
            if (a == b && b == c) return " equilateral";
            if (a == b || a == c || b == c) return " isosceles";
            if (a != b && b != c && a != c) return " scalene";
            return "";
        }

        // Returns the type in string form
        public string Type()
        {
            // Math to determine which kind of triangle goes here
            string angleType = "";
            string sideType = "";
            double[] sides = new double[] { Math.Pow(Convert.ToDouble(s1), 2), Math.Pow(Convert.ToDouble(s2), 2), Math.Pow(Convert.ToDouble(s3), 2) };
            string valid = this.Valid();
            if (valid == "a valid")
            {
                Array.Sort(sides);
                angleType = this.angleType(sides[0], sides[1], sides[2]);
                sideType = this.sideType(sides[0], sides[1], sides[2]);
            }

            return $"{valid}{sideType}{angleType}";
        }
        public string Valid()
        {
            double a = Convert.ToDouble(s1);
            double b = Convert.ToDouble(s2);
            double c = Convert.ToDouble(s3);
            if (a == 0 || b == 0 || c == 0) return "an invalid";
            if ((a + b > c) && (a + c > b) && (c + b > a)) return "a valid";
            return "an invalid";
        }
    }
}
