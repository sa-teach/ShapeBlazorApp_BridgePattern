namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

/// <summary>
/// Интерфейс реализации (Implementation) в паттерне Bridge.
/// Определяет КАК рисовать примитивы — абстракция не знает деталей.
/// Новый рендерер (например, OpenGLRenderer) добавляется без изменения фигур.
/// </summary>
public interface IRenderer
{
    /// <summary>Рисует круг с центром (cx, cy) и радиусом r.</summary>
    string RenderCircle(double cx, double cy, double r);

    /// <summary>Рисует прямоугольник с левым верхним углом (x, y) и размерами width x height.</summary>
    string RenderRectangle(double x, double y, double width, double height);

    /// <summary>Рисует линию от (x1, y1) до (x2, y2).</summary>
    string RenderLine(double x1, double y1, double x2, double y2);

    /// <summary>Рисует треугольник по трём вершинам.</summary>
    string RenderTriangle(double x1, double y1, double x2, double y2, double x3, double y3);

    /// <summary>Человекочитаемое имя рендерера для UI.</summary>
    string Name { get; }
}
