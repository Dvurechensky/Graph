namespace GraphCustomSearcher.Data;

/// <summary>
/// Шаблог ребра
/// </summary>
public class Edge
{
    /// <summary>
    /// Узел начала
    /// </summary>
    public Verticle VerticleStart { get; set; }
    /// <summary>
    /// Узел конца
    /// </summary>
    public Verticle VerticleStop { get; set; }

    public Edge(Verticle verticleStart, Verticle verticleStop)
    {
        VerticleStart = verticleStart;
        VerticleStop = verticleStop;
    }
}
