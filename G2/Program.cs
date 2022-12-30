///Ищет в направленном графе путь от точки до точки

using G2;

var VerticleList = new List<Verticle>();
var EdgeList = new List<Edge>();
var graph = new Graph();
VerticleList.Add(new Verticle("Пенсильвания"));
VerticleList.Add(new Verticle("Париж"));
VerticleList.Add(new Verticle("Магеллан"));
VerticleList.Add(new Verticle("Аляска"));
VerticleList.Add(new Verticle("Оптимум"));
EdgeList.Add(new Edge(VerticleList[0], VerticleList[1]));//Пенсильвания - Париж
EdgeList.Add(new Edge(VerticleList[1], VerticleList[0]));//Париж - Пенсильвания
EdgeList.Add(new Edge(VerticleList[1], VerticleList[2]));//Париж - Магеллан
EdgeList.Add(new Edge(VerticleList[2], VerticleList[1]));//Магеллан - Париж
EdgeList.Add(new Edge(VerticleList[3], VerticleList[1]));//Аляска - Париж
EdgeList.Add(new Edge(VerticleList[3], VerticleList[4]));//Аляска - Оптимум
EdgeList.Add(new Edge(VerticleList[4], VerticleList[3]));//Оптимум - Аляска

for (int i = 0; i < VerticleList.Count; i++)
{
    graph.AddVerticle(VerticleList[i]);
}

foreach(var edge in EdgeList)
{
    graph.AddEdge(edge);
}

graph.SearchPath(VerticleList[0], VerticleList[2]);
if (VerticleList[2].Name.Contains(graph.Target.Name))
{
    Console.WriteLine(graph.Path);
}
else Console.WriteLine("Путь невозможен");
