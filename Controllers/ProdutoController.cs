using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MDP.Models.ClassesDeDominio;
using MDP.Models;
using MDP.Models.DTO;
using MDP.Models.Repositorios;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using MDP.Models.Association;
using System;
using System.IO;
using System.Net;

namespace MDP.Controllers
{
    [Route("api/Produto")]
    [EnableCors("IT3Client")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        public ProdutoRepositorio repositorio;

        public ProdutoController(MDPContext context)
        {
            repositorio = new ProdutoRepositorio(context);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoDTO>> GetProduto(long id)
        {
            var Produto = await repositorio.getProdutoById(id);

            if (Produto.Value == null)
            {
                return NotFound();
            }

            var PlanoFabrico = await repositorio.getPlanoFabricoByProduto(Produto.Value.planoFabricoId, Produto.Value.Id);

            Produto.Value.planoFabrico = PlanoFabrico.Value;

            var ProdutoDTO = Produto.Value.toDTO();

            if (ProdutoDTO == null)
            {
                return NotFound();
            }

            return ProdutoDTO;
        }

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(ProdutoDTO newProduto)
        {
            repositorio.addProduto(new Produto(newProduto.Id, newProduto.nomeProduto, newProduto.descricaoProduto, newProduto.planofabrico.Id, newProduto.planofabrico.operacoes, newProduto.planofabrico.tempo_fabrico));
            return CreatedAtAction(nameof(GetProduto), new { id = newProduto.Id }, newProduto);
        }

        // GET: api/ProdutoDTO/
        [HttpGet]
        public async Task<ActionResult<List<ProdutoDTO>>> GetAllProdutoDTO()
        {
            var listaMaquinasDTO = await obterListaProduto((await repositorio.getAllProdutos()).Value);
            return listaMaquinasDTO.Value;
        }

        private async Task<ActionResult<List<ProdutoDTO>>> obterListaProduto(List<Produto> listaProdutoDTO)
        {
            List<ProdutoDTO> listaProduto = new List<ProdutoDTO>();
            foreach (Produto Produto in listaProdutoDTO)
            {
                var planoFabrico = await repositorio.getPlanoFabricoByProduto(Produto.planoFabricoId, Produto.Id);
                Produto.planoFabrico = planoFabrico.Value;
                listaProduto.Add(Produto.toDTO());
            }
            return listaProduto;
        }

        // PUT: api/Todo/
        [HttpPut]
        public async Task<IActionResult> PutProduto(ProdutoDTO update_produto)
        {
            var produto = await repositorio.getProdutoById(update_produto.Id);

            if (produto.Value == null)
            {
                return NotFound();
            }

            repositorio.updateProduto(update_produto);

            return NoContent();
        }

        // DELETE: api/Produto/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoDTO>> DeleteProduto(long id)
        {
            var produto = await GetProduto(id);

            if (produto == null)
            {
                return NotFound();
            }

            repositorio.deleteProduto(id);

            return NoContent();
        }

    }
}