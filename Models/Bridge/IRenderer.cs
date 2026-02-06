namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

/// Интерфейс реализации (Implementation) в паттерне Bridge.
/// Определяет КАК рисовать примитивы — абстракция не знает деталей.
/// Новый рендерер (например, OpenGLRenderer) добавляется без изменения фигур.
public interface IRenderer
{
    string RenderCircle(double cx, double cy, double r);

    string RenderRectangle(double x, double y, double width, double height);

    string RenderLine(double x1, double y1, double x2, double y2);

    string RenderTriangle(double x1, double y1, double x2, double y2, double x3, double y3);

    string Name { get; }
}
