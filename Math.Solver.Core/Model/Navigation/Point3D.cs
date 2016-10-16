namespace Math.Solver.Core.Model.Navigation
{
    public class Point3D : Point
    {
        public Point3D(int x, int y, int z) : base(x, y) 
        {
            
        }
        public int Z { get; set; }
    }
}
