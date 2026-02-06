namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

/// Абстракция (Abstraction) в паттерне Bridge.
/// Фигура знает ЧТО рисовать (геометрию), но не знает КАК (делегирует IRenderer).
/// Благодаря этому можно добавлять новые фигуры без изменения рендереров.
public abstract class Shape
{
    protected readonly IRenderer Renderer;

    protected Shape(IRenderer renderer)
    {
        Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
    }

    public abstract string Draw();

    public abstract string Name { get; }
}
