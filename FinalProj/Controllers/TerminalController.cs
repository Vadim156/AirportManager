using Airport.Data.Repositories;
using FinalProj.Models;
using Logic.data_implement;
using Logic.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FinalProj.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerminalController : ControllerBase
    {
        private Terminal _baseTerminal1 { get; set; }

        private readonly ITerminalRepository _terminalRepository;
        public TerminalController(ITerminalRepository terminalRepository)
        {
            _terminalRepository = terminalRepository;
            AddTerminals();
        }

        async void AddTerminals()
        {
            var numberOfTerminals = _terminalRepository.GetAllAsync().Result.Count();
            if (!(numberOfTerminals >= 8))
            {
                _baseTerminal1 = new Terminal();
                ITerminal[] terminals = new ITerminal[8 - numberOfTerminals];
                for(int i = 0; i < terminals.Length; i++)
                {
                    terminals[i] = new Terminal() { Number = ++i };
                    i--;
                    //terminals.Add(new Terminal());
                }
                foreach (var t in terminals)
                {
                    Terminal terminal = new Terminal()
                    {
                        CrossingTime = t.CrossingTime,
                        Number = t.Number,
                        IsFree = t.IsFree,
                        TerminalId = t.TerminalId
                    };

                    //this.AddNode(t);
                    //if (terminal.Number <= 8 && terminal.Number >= 0)
                        if (!_terminalRepository.Exists(terminal.TerminalId).Result)
                            if (!_terminalRepository.GetAllAsync().Result.Any(x => x.Number == terminal.Number))
                            {
                                await _terminalRepository.AddAsync(terminal);

                            }
                }
            }

        }
            
                    
               
            
            
            
        // GET: api/<TerminalController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<TerminalController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TerminalController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TerminalController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TerminalController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
