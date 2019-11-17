using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticAndInstanceMembers
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Circle
    {
        static float _pi;
        int _radius;

        static Circle()
        {
            _pi = 3.141f;
        }

        public Circle(int radius)
        {
            _radius = radius;
        }

        public static void Print()
        {
            
        }
        public float CalculateArea()
        {
            return  _pi * this._radius * this._radius;
        } 
    }
}

