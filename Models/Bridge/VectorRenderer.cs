namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

/// Векторный рендерер — рисует гладкие векторные фигуры (SVG).
public class VectorRenderer : IRenderer
{
    public string Name => "Векторный (Vector)";

    private const string FillColor = "#4a90d9";
    private const string StrokeColor = "#1e3a5f";
    private const double StrokeWidth = 2;

    public string RenderCircle(double cx, double cy, double r) =>
        $"<circle cx=\"{cx}\" cy=\"{cy}\" r=\"{r}\" fill=\"{FillColor}\" stroke=\"{StrokeColor}\" stroke-width=\"{StrokeWidth}\"/>";

    public string RenderRectangle(double x, double y, double width, double height) =>
        $"<rect x=\"{x}\" y=\"{y}\" width=\"{width}\" height=\"{height}\" fill=\"{FillColor}\" stroke=\"{StrokeColor}\" stroke-width=\"{StrokeWidth}\"/>";

    public string RenderLine(double x1, double y1, double x2, double y2) =>
        $"<line x1=\"{x1}\" y1=\"{y1}\" x2=\"{x2}\" y2=\"{y2}\" stroke=\"{FillColor}\" stroke-width=\"{StrokeWidth}\"/>";

    public string RenderTriangle(double x1, double y1, double x2, double y2, double x3, double y3) =>
        $"<polygon points=\"{x1},{y1} {x2},{y2} {x3},{y3}\" fill=\"{FillColor}\" stroke=\"{StrokeColor}\" stroke-width=\"{StrokeWidth}\"/>";
}
