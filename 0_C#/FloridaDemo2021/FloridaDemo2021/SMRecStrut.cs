namespace FloridaDemo2021
{
    public record struct CarCustomer(Guid Id, int carVin, string Name);

    public struct Point
    {
        public Point(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public int Z { get; set;}
    } 
}