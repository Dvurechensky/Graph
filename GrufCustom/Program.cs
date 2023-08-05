using GraphCustomSearcher.Data;
using GraphCustomSearcher;

/// <summary>
/// Ищет в направленном графе путь от точки до точки 
/// учитывает наличие круговых двухсторонних связей
/// </summary>
public class Program
{
    public static void Main()
    {
        var GraphX = new Graph();
        var namesVerticles = new string[] { "Пенсильвания", "Париж", "Магеллан", "Аляска", "Аляска", "Оптимум"};
        var wayEdges = new int[,] { { 0, 1 }, { 1, 0 }, { 1, 2 }, { 2, 1 }, { 2, 5 }, { 3, 1 }, { 3, 4 }, { 4, 3 } };

        GraphX.AddVerticle(AddVerticles(namesVerticles));
        GraphX.AddEdge(AddEdges(wayEdges, AddVerticles(namesVerticles)));

        Console.WriteLine("Пенсильвания->Париж");
        StartSeachPath(GraphX, "Пенсильвания", "Париж");
        Console.WriteLine("Пенсильвания->Оптимум");
        StartSeachPath(GraphX, "Пенсильвания", "Оптимум");
    }

    /// <summary>
    /// Ищет путь от узла до узла
    /// </summary>
    /// <param name="graph">Граф</param>
    /// <param name="start">Точка старта</param>
    /// <param name="stop">Точка прибытия</param>
    public static void StartSeachPath(Graph graph, string start, string stop)
    {
        Console.WriteLine();
        graph.RebuildEdge();
        graph.SearchPath(start, stop);
        if (stop.Contains(graph.Target.Name))
            Console.WriteLine($"--> PATH: {graph.Path}");
        else Console.WriteLine("--> ERROR: Путь невозможен");
        Console.WriteLine();
    }

    /// <summary>
    /// Добавить узлы
    /// </summary>
    /// <param name="namesVerticles">список имён узлов</param>
    /// <returns></returns>
    public static List<Verticle> AddVerticles(string[] namesVerticles)
    {
        var VerticleList = new List<Verticle>();
        foreach (var verticle in namesVerticles)
            VerticleList.Add(new Verticle(verticle));
        return VerticleList;
    }

    /// <summary>
    /// Добавить рёбра (возможные пути между узлами)
    /// </summary>
    /// <param name="VerticleList"></param>
    public static List<Edge> AddEdges(int[,] wayEdges, List<Verticle> VerticleList)
    {
        var EdgeList = new List<Edge>();
        for(int ind = 0; ind < wayEdges.GetLength(0); ind++)
            EdgeList.Add(new Edge(VerticleList[wayEdges[ind,0]], VerticleList[wayEdges[ind, 1]]));
        return EdgeList;
    }
}
