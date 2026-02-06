namespace ShapeBlazorApp_BridgePattern.Models.Bridge;

/// <summary>
/// Абстракция (Abstraction) в паттерне Bridge.
/// Фигура знает ЧТО рисовать (геометрию), но не знает КАК (делегирует IRenderer).
/// Благодаря этому можно добавлять новые фигуры без изменения рендереров.
/// </summary>
public abstract class Shape
{
    protected readonly IRenderer Renderer;

    protected Shape(IRenderer renderer)
    {
        Renderer = renderer ?? throw new ArgumentNullException(nameof(renderer));
    }

    /// <summary>Рисует фигуру, делегируя рендереру.</summary>
    public abstract string Draw();

    /// <summary>Человекочитаемое имя фигуры для UI.</summary>
    public abstract string Name { get; }
}
