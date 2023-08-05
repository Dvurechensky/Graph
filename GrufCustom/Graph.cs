using GraphCustomSearcher.Data;

namespace GraphCustomSearcher;

public class Graph
{
    public List<Verticle> Verticls;
    public List<Edge> Edges;
    public string Path { get; set; }
    public Verticle Target { get; set; }

    public Graph()
    {
        Verticls = new List<Verticle>();
        Edges = new List<Edge>();
    }

    /// <summary>
    /// Загрузка узлов
    /// </summary>
    /// <param name="verticles">узлы</param>
    public void AddVerticle(List<Verticle> verticles)
    {
        Verticls.AddRange(verticles);
    }

    /// <summary>
    /// Загрузка рёбер
    /// </summary>
    /// <param name="edges">рёбра</param>
    public void AddEdge(List<Edge> edges)
    {
        Edges.AddRange(edges);
    }

    public void RebuildEdge()
    {
        Path = string.Empty;
        foreach (var edge in Edges)
        {
            edge.VerticleStop.IsVisited = false;
            edge.VerticleStart.IsVisited = false;
        }
    }

    /// <summary>
    /// Перебор рёбер - поиск вершин в которые входит точка старта
    /// </summary>
    /// <param name="source"></param>
    /// <param name="target"></param>
    public void SearchPath(string source, string target)
    {
        Console.WriteLine($"Начало: {source} Конец: {target}");
        var sourceVerticle = new Verticle(source);
        var targetVerticle = new Verticle(target);
        foreach (var edge in Edges)
        {
            var state_1 = edge.VerticleStart.Name == sourceVerticle.Name && edge.VerticleStart.IsVisited == sourceVerticle.IsVisited;
            var state_2 = !edge.VerticleStart.IsVisited;
            var state_3 = !(!string.IsNullOrEmpty(Path) && Path.Contains(edge.VerticleStop.Name));
            if (state_1 && state_2 && state_3)
            {
                Path += edge.VerticleStart.Name + " ";
                Console.WriteLine($"Ребро {edge.VerticleStart.Name} направляется в {edge.VerticleStop.Name}");
                edge.VerticleStart.IsVisited = true;
                Target = edge.VerticleStop;
                if (targetVerticle.Name == edge.VerticleStop.Name)
                {
                    Path += edge.VerticleStop.Name;
                    return;
                }
                SearchPath(edge.VerticleStop.Name, targetVerticle.Name);
            }
        }
    }
}
