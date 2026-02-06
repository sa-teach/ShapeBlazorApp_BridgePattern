namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

public class Circle : Shape
{
    public double CenterX { get; }
    public double CenterY { get; }
    public double Radius { get; }

    public Circle(IRenderer renderer, double cx, double cy, double radius)
        : base(renderer)
    {
        CenterX = cx;
        CenterY = cy;
        Radius = radius;
    }

    public override string Draw() => Renderer.RenderCircle(CenterX, CenterY, Radius);
    public override string Name => "Круг";
}
