using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Data_Structures
{
    public interface IGraph<T> where T : class
    {
        public bool AddNode(T value);
        public bool AddEdge(T value1, T value2);
        public GraphNode<T> Find(T value);
        public bool RemoveNode(T value);
        public bool RemoveEdge(T value1, T value2);
        public void Clear();
    }
}
