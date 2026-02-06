namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

public class Triangle : Shape
{
    public double X1 { get; }
    public double Y1 { get; }
    public double X2 { get; }
    public double Y2 { get; }
    public double X3 { get; }
    public double Y3 { get; }

    /// <summary>Создаёт равносторонний треугольник с центром (cx, cy) и высотой height.</summary>
    public Triangle(IRenderer renderer, double cx, double cy, double height)
        : base(renderer)
    {
        var halfHeight = height / 2;
        var halfBase = height / (2 * Math.Sqrt(3)); // для равностороннего
        X1 = cx;
        Y1 = cy - halfHeight;           // вершина
        X2 = cx - halfBase;
        Y2 = cy + halfHeight;           // левый нижний
        X3 = cx + halfBase;
        Y3 = cy + halfHeight;           // правый нижний
    }

    public override string Draw() => Renderer.RenderTriangle(X1, Y1, X2, Y2, X3, Y3);
    public override string Name => "Треугольник";
}
