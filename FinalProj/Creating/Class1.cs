using Airport.Data.Repositories;
using FinalProj.Models;
using Logic.data_implement;
using Logic.Data_Structures;
using Logic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Creating
{
    public class Class1 : Class2
    {
        private BaseTerminal _baseTerminal1 { get; set; }
        public BaseTerminal terminal1 { get { return _baseTerminal1; } }
        public ImpGraph graph { get { return _graph; } }
        private ImpGraph _graph { get; set; }

        public Class1()
        {
            //_terminalRepository = terminalRepository;  
            _graph = new ImpGraph();
            _baseTerminal1 = new BaseTerminal();
            _graph.AddNode(_baseTerminal1);
            //List<Terminal> terminals = new List<Terminal>();
            FinalProj.Models.Terminal[] terminals = new FinalProj.Models.Terminal[8];
            terminals[0]=_baseTerminal1;
            for(int i = 1;i < terminals.Length; i++)
            {
                terminals[i] = new FinalProj.Models.Terminal { Number = i++ };
                _graph.AddNode(terminals[i]);
            }
            for(int i = 1; i <= terminals.Length-3; i++)
            {
                _graph.AddEdge(terminals[i], terminals[i++]);
            }

            _graph.AddEdge(terminals[5], terminals[7]);
            _graph.AddEdge(terminals[6], terminals[8]);
            _graph.AddEdge(terminals[7], terminals[8]);
            _graph.AddEdge(terminals[8], terminals[4]);

        }

        
    }
}
