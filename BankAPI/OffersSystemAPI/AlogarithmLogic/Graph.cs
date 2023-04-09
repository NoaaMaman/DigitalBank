namespace OffersSystemAPI.AlogarithmLogic
{
    public class Graph
    {
        private Dictionary<string, List<string>> _edges = new Dictionary<string, List<string>>();

        public void AddEdge(string fromNode, string toNode)
        {
            if (!_edges.ContainsKey(fromNode))
            {
                _edges[fromNode] = new List<string>();
            }
            _edges[fromNode].Add(toNode);
        }

        public List<string> GetNeighbors(string node)
        {
            if (_edges.ContainsKey(node))
            {
                return _edges[node];
            }
            else
            {
                return new List<string>();
            }
        }
    }
}
