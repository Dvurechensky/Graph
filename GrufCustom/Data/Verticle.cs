namespace GraphCustomSearcher.Data;

/// <summary>
/// Узел
/// </summary>
public class Verticle
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Статус посещения узла
    /// </summary>
    public bool IsVisited { get; set; }

    public Verticle(string name)
    {
        Name = name;
    }
}
