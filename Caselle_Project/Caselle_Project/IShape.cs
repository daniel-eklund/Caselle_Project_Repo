using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caselle_Project
{
    interface IShape
    {
        double Area();     // Area of shape 
        double[] Angles(); // List of angles in the body
        string Type();     // Type of shape; i.e. Right Triangle, Square, etc
        string Valid(); // Returns validity string based on type
    }
}
