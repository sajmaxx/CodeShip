
// See https://aka.ms/new-console-template for more information


using FloridaDemo2021;



Console.WriteLine("Hello, World!");
List<int> ConferenceIDlist = new List<int>();
ConferenceIDlist.Add(20);
ConferenceIDlist.Add(30);
ConferenceIDlist.Add(77);
ConferenceIDlist.Add(34);

Console.WriteLine(ConferenceIDlist.Count);

Point mahPoint = new Point(1,1,2);

//Point newPoint = mahPoint with Z = 3;


//BETTER LAMBDAS 2021
int myvalue  (Point mahPoint) => mahPoint.X + mahPoint.Y + mahPoint.Z;
//myvalue += 100;

