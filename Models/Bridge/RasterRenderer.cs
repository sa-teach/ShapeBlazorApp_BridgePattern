using System.Text;

namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

/// Растровый рендерер — имитирует пиксельную графику.
/// Рисует фигуры как набор маленьких квадратов (пикселей).
public class RasterRenderer : IRenderer
{
    public string Name => "Растровый (Raster)";

    private const int PixelSize = 4;
    private const string FillColor = "#4a90d9";
    private const string StrokeColor = "#2d5a8a";

    public string RenderCircle(double cx, double cy, double r)
    {
        var sb = new StringBuilder();
        var steps = (int)(r * 2 / PixelSize) + 1;
        for (var px = cx - r; px <= cx + r; px += PixelSize)
        for (var py = cy - r; py <= cy + r; py += PixelSize)
        {
            var dx = px - cx;
            var dy = py - cy;
            if (dx * dx + dy * dy <= r * r)
            {
                sb.Append(
                    $"<rect x=\"{px}\" y=\"{py}\" width=\"{PixelSize}\" height=\"{PixelSize}\" fill=\"{FillColor}\" stroke=\"{StrokeColor}\" stroke-width=\"0.5\"/>");
            }
        }

        return sb.ToString();
    }

    public string RenderRectangle(double x, double y, double width, double height)
    {
        var sb = new StringBuilder();
        for (var px = x; px < x + width; px += PixelSize)
        for (var py = y; py < y + height; py += PixelSize)
        {
            sb.Append(
                $"<rect x=\"{px}\" y=\"{py}\" width=\"{PixelSize}\" height=\"{PixelSize}\" fill=\"{FillColor}\" stroke=\"{StrokeColor}\" stroke-width=\"0.5\"/>");
        }

        return sb.ToString();
    }

    public string RenderLine(double x1, double y1, double x2, double y2)
    {
        var sb = new StringBuilder();
        var len = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
        var steps = Math.Max(1, (int)(len / PixelSize));
        for (var i = 0; i <= steps; i++)
        {
            var t = (double)i / steps;
            var px = x1 + t * (x2 - x1);
            var py = y1 + t * (y2 - y1);
            sb.Append(
                $"<rect x=\"{px}\" y=\"{py}\" width=\"{PixelSize}\" height=\"{PixelSize}\" fill=\"{FillColor}\"/>");
        }

        return sb.ToString();
    }

    public string RenderTriangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        var sb = new StringBuilder();
        var minX = Math.Min(x1, Math.Min(x2, x3));
        var maxX = Math.Max(x1, Math.Max(x2, x3));
        var minY = Math.Min(y1, Math.Min(y2, y3));
        var maxY = Math.Max(y1, Math.Max(y2, y3));

        bool IsInside(double px, double py)
        {
            var d1 = Sign(px, py, x1, y1, x2, y2);
            var d2 = Sign(px, py, x2, y2, x3, y3);
            var d3 = Sign(px, py, x3, y3, x1, y1);
            return (d1 <= 0 && d2 <= 0 && d3 <= 0) || (d1 >= 0 && d2 >= 0 && d3 >= 0);
        }

        double Sign(double px, double py, double ax, double ay, double bx, double by) =>
            (px - bx) * (ay - by) - (ax - bx) * (py - by);

        for (var px = minX; px <= maxX; px += PixelSize)
        for (var py = minY; py <= maxY; py += PixelSize)
        {
            if (IsInside(px, py))
            {
                sb.Append(
                    $"<rect x=\"{px}\" y=\"{py}\" width=\"{PixelSize}\" height=\"{PixelSize}\" fill=\"{FillColor}\" stroke=\"{StrokeColor}\" stroke-width=\"0.5\"/>");
            }
        }

        return sb.ToString();
    }
}
