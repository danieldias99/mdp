using MDP.Models.ClassesDeDominio;
using MDP.Models.DTO;
using MDP.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using MDP.Models.Association;

namespace MDP.Models.Repositorios
{



    public class ProdutoRepositorio
    {

        private readonly MDPContext _context;

        public ProdutoRepositorio(MDPContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Produto>> getProdutoById(long id)
        {
            var Produto = await _context.Produtos.FindAsync(id);
            return Produto;
        }

        public async Task<ActionResult<PlanoFabrico>> getPlanoFabricoByProduto(long Id_planoFabrico, long Id_produto)
        {
            var planoFabrico = await _context.PlanosFabrico.FindAsync(Id_planoFabrico);
            var ordensAll = await _context.OrdensFabrico.ToListAsync();
            var ordens = setOrdensPProduto(ordensAll, Id_planoFabrico);
            planoFabrico.Id_produto = Id_produto;
            planoFabrico.operacoes = ordens;
            return planoFabrico;
        }

        public List<OrdemFabrico> setOrdensPProduto(List<OrdemFabrico> ordensAll, long id_plano_producao)
        {
            var ordens = new List<OrdemFabrico>();

            foreach (var ordem in ordensAll)
            {
                if (ordem.Id_planoFabrico == id_plano_producao)
                    ordens.Add(ordem);
            }
            return ordens;
        }

        public async Task<ActionResult<List<Produto>>> getAllProdutos()
        {
            return await _context.Produtos.ToListAsync();
        }

        public void addProduto(Produto newProduto)
        {
            _context.Produtos.Add(newProduto);
            _context.SaveChanges();
        }

        public async void updateProduto(Produto update_produto)
        {
            var current_produto = await _context.Produtos.FindAsync(update_produto.Id);
            current_produto.informacaoProduto = update_produto.informacaoProduto;
            _context.Entry(current_produto).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async void deleteProduto(long id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            _context.Produtos.Remove(produto);
            _context.Entry(produto).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}