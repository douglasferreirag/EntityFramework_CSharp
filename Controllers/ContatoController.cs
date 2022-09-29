using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ModuloAPI.Context;
using ModuloAPI.Entities;

namespace ModuloAPI.Controllers
{

                    [ApiController]
                    [Route("[controller]")]
                    public class ContatoController: ControllerBase
                    {

                        private readonly AgendaContext _context;
                    public ContatoController(AgendaContext context)
                    {

                                 _context = context;

                     }
                     [HttpPost]
                    public IActionResult Create(Contato contato){

                                _context.Add(contato);
                                _context.SaveChanges();
                                return Ok(contato);

                    }

                    [HttpGet("{id}")]
                    public IActionResult ObterPorId(int id){

                                    var contato  = _context.Contatos.Find(id);
                                    if(contato == null)
                                            return NotFound();
                                    return Ok(contato);
                    }

                  [HttpPut("{id}")]
                    public IActionResult Atualizar (int id, Contato contato){

                                var ContatoBanco =  _context.Contatos.Find(id);
                                 if(ContatoBanco == null)
                                            return NotFound();
                                ContatoBanco.Nome = contato.Nome;
                                ContatoBanco.Telefone = contato.Telefone;
                                ContatoBanco.Ativo = contato.Ativo;


                                _context.Contatos.Update(ContatoBanco);
                                _context.SaveChanges();

                                return Ok(ContatoBanco);

                }
                [HttpDelete("{id}")]
                public IActionResult Deletar(int id){

                        var ContatoBanco =  _context.Contatos.Find(id);
                        if(ContatoBanco == null)
                                return NotFound();
                        _context.Contatos.Remove(ContatoBanco);
                        _context.SaveChanges();
                        return NoContent();

                }
  


        }
}