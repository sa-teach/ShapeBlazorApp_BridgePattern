namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

public class Square : Shape
{
    public double X { get; }
    public double Y { get; }
    public double Side { get; }

    public Square(IRenderer renderer, double x, double y, double side)
        : base(renderer)
    {
        X = x;
        Y = y;
        Side = side;
    }

    public override string Draw() => Renderer.RenderRectangle(X, Y, Side, Side);
    public override string Name => "Квадрат";
}
