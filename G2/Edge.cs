namespace G2
{
    public class Edge
    {
        public Verticle VerticleStart { get; set; }
        public Verticle VerticleStop { get; set; }

        public Edge(Verticle verticleStart, Verticle verticleStop)
        {
            VerticleStart = verticleStart;
            VerticleStop = verticleStop;
        }
    }
}
