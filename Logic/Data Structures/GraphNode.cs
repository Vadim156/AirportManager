﻿using FinalProj.Models;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Data_Structures
{
    public class GraphNode<T> 
    {
        
        #region Internal Variable - generic value and List of neighbor nodes       
        T value;
        List<GraphNode<T>> neighbors;
        #endregion nodes

        #region Constructor- initialize value and blank neighbour list
        public GraphNode(T value)
        {
            this.value = value;
            this.neighbors = new List<GraphNode<T>>();
        }
        #endregion

        #region Readonly Properties - value and List of neighbor nodes              
        public T Value
        {
            get { return value; }
        }
        public IList<GraphNode<T>> Neighbors
        {
            get { return neighbors.AsReadOnly(); }
        }
        #endregion

        #region Basic Operations-AddNeighbors, RemoveNeighbors, RemoveAllNeighbors, ToString
        public bool AddNeighbors(GraphNode<T> neighbor)
        {
            if (neighbors.Contains(neighbor))
            {
                return false;
            }
            else
            {
                neighbors.Add(neighbor);
                return true;
            }
        }
        
        public bool RemoveNeighbors(GraphNode<T> neighbor)
        {
            return neighbors.Remove(neighbor);
        }
        public bool RemoveAllNeighbors()
        {
            for (int i = neighbors.Count; i >= 0; i--)
            {
                neighbors.RemoveAt(i);
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[ Node Value " + value + " with Neighbors : ");
            for (int i = 0; i < neighbors.Count; i++)
            {
                nodeString.Append(neighbors[i].Value + " ");
            }
            nodeString.Append("]");
            return nodeString.ToString();
        }

        
        #endregion

    }

    #region Graph: Search Type Enum        
    enum SearchType
    {
        DFS,
        BFS
    }
    #endregion
}
