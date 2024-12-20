using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Shapes
{
    using System;
    using System.Collections;
    [Serializable()]

    public abstract class Shape
    {
        public Shape(double Slenth)
        {
            lenth = Slenth;
        }
        public string Name { get; set; }

        //public List<Square> Squares { get; set; }

        //public List<Sphere> Spheres { get; set; }
        public double lenth { get; set; }


        public abstract double Area { get; }


        public abstract override string ToString();




    }
    [Serializable]
    public abstract class TwoDim : Shape
    {

        public TwoDim(double a) : base(a)
        {

        }
        public override abstract double Area { get; }
        public override string ToString()
        {
            return string.Format("is a Two Dim Shape");

        }
    }
    [Serializable]
    public abstract class ThreeDim : Shape
    {
        public ThreeDim(double a) : base(a)
        {

        }
        public override abstract double Area { get; }
        public abstract double Volume { get; }


        public override string ToString()
        {
            return string.Format("is a Three Dim Shape");
        }

    }
    [Serializable]
    public class Circle : TwoDim
    {
        public Circle(double a) : base(a) { }
        public override double Area
        {
            get { return Math.PI * base.lenth; }

        }
        public override string ToString()
        {
            return string.Format("{0}, Circle, Lenth: {1}, Area: {2:N}", Name, lenth, Area);
        }

    }
    [Serializable]
    public class Square : TwoDim
    {
        public Square(double a) : base(a)
        {

        }
        public override double Area
        {
            get { return lenth * lenth; }

        }
        public override string ToString()
        {
            return string.Format("{0}, Square, Lenth: {1}, Area: {2}", Name, lenth, Area);
        }

    }
    [Serializable]
    public class Sphere : ThreeDim
    {
        public Sphere(double a) : base(a) { }

        public override double Area
        {
            get { return Math.PI * 4 * (lenth * lenth); }

        }
        public override double Volume
        {
            get { return (4 * Math.PI * Math.Pow(base.lenth, 3)); }
        }

        public override string ToString()
        {
            return string.Format("{0}, Sphere, Lenth: {1}, Area: {2:N}, Volume: {3}", Name, lenth, Area, Volume);
        }
    }
    [Serializable]
    public class Cube : ThreeDim
    {
        public Cube(double a) : base(a) { }

        public override double Area
        {
            get { return 6 * (lenth * lenth); }

        }
        public override double Volume
        {
            get { return Math.Pow(base.lenth, 3); }
        }

        public override string ToString()
        {
            return string.Format("{0}, Cube, Lenth: {1}, Area: {2},Volume: {3} ", Name, lenth, Area, Volume);
        }

    }
    [Serializable]

    public class ShapeList
    {
        protected SortedList figures;

        public ShapeList()
        {
            figures = new SortedList();
        }
        public int NextIndex
        {
            get
            {
                return figures.Count;
            }
            
        }
        public Shape this[int index]
        {
            get
            {
                if (index >= figures.Count)
                    return (Shape)null;
                //SortedList internal method
                return (Shape)figures.GetByIndex(index);
            }
            set
            {
                if (index <= figures.Count)
                    figures[index] = value; //!!!		
            }
        }

        public void Remove(int element)
        {
            if (element >= 0 && element < figures.Count)
            {
                for (int i = element; i < figures.Count - 1; i++)
                    figures[i] = figures[i + 1];
                figures.RemoveAt(figures.Count - 1);
            }
        }


    }
}
