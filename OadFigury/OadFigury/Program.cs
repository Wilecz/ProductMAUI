using OadFigury;
var figury = new List<Figure> { new Circle(1), new Rectangle(2, 3), new Triangle(3, 4, 5) };
foreach (var f in figury)
{
    Console.WriteLine(f.Description());
}
var drawing = new Drawing();
foreach (var f in figury)
{
    drawing.Adder(f);
}
Console.WriteLine($"Highest Figure: {drawing.Highest()?.Description()}");
var list = new List<Animal> { new Dog(), new Animal() };
foreach (var z in list)
{
    Console.WriteLine(z.Sound());
}