using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjetoModeloDDD.Aplicacao.Interface;
using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly IAppServicoProduto _produtoApp;
        private readonly IAppServicoCliente _clienteApp;
        private readonly IMapper _mapper;

        public ProdutosController(IAppServicoProduto produtoApp, IAppServicoCliente clienteApp, IMapper mapper)
        {
            _produtoApp = produtoApp;
            _clienteApp = clienteApp;
            _mapper = mapper;
        }

        // GET: ProdutosController
        public ActionResult Index()
        {
            var produtoViewModel = _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.ObterTodos());
            return View(produtoViewModel);
        }

        // GET: ProdutosController/Details/5
        public ActionResult Details(int id)
        {
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(_produtoApp.ObterPorId(id));
            return View(produtoViewModel);
        }

        // GET: ProdutosController/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.ObterTodos(), "ClienteId", "Nome");
            return View();
        }

        // POST: ProdutosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDominio = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Adicionar(produtoDominio);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: ProdutosController/Edit/5
        public ActionResult Edit(int id)
        {
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(_produtoApp.ObterPorId(id));
            return View(produtoViewModel);
        }

        // POST: ProdutosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = _mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Atualizar(produtoDomain);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: ProdutosController/Delete/5
        public ActionResult Delete(int id)
        {
            var produtoViewModel = _mapper.Map<Produto, ProdutoViewModel>(_produtoApp.ObterPorId(id));
            return View(produtoViewModel);
        }

        // POST: ProdutosController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProdutoViewModel produto)
        {
            if(id != produto.ID)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    var produtoDomain = _produtoApp.ObterPorId(id);
                    _produtoApp.Excluir(produtoDomain);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View();
                }
            }

            
        }
    }
}
