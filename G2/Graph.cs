namespace G2
{
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

        public void AddVerticle(Verticle verticle)
        {
            Verticls.Add(verticle);
        }

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
        }

        public void SearchPath(Verticle source, Verticle target)
        {
            Console.WriteLine($"Начало: {source.Name} Конец: {target.Name}");

            //перебор рёбер - поиск вершин в которые входит точка старта
            foreach (var edge in Edges)
            {
                if (edge.VerticleStart == source && !edge.VerticleStart.IsVisited)
                {
                    Path += edge.VerticleStart.Name + " ";
                    Console.WriteLine($"Ребро {edge.VerticleStart.Name} направляется в {edge.VerticleStop.Name}");
                    edge.VerticleStart.IsVisited = true;
                    Target = edge.VerticleStop;
                    SearchPath(edge.VerticleStop, target);
                }
            }
        }
    }
}
