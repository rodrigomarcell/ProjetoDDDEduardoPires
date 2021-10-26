using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProjetoModeloDDD.Dominio.Entidades;
using ProjetoModeloDDD.MVC.ViewModels;
using ProjetoModeloDDD.Aplicacao;
using ProjetoModeloDDD.Dominio.Interfaces.Servicos;
using ProjetoModeloDDD.Aplicacao.Interface;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ClientesController : Controller
    {
        
        private readonly IAppServicoCliente _clienteApp;
        private readonly IMapper _mapper;

        public ClientesController(IMapper mapper, IAppServicoCliente clienteApp)
        {
            _mapper = mapper;
            _clienteApp = clienteApp;
        }

        // GET: ClientesController
        public ActionResult Index()
        {
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterTodos());
            return View(clienteViewModel);
        }

        public ActionResult Especiais()
        {
            var clienteViewModel = _mapper.Map<IEnumerable<Cliente>, IEnumerable<ClienteViewModel>>(_clienteApp.ObterClientesEspeciais());
            return View(clienteViewModel);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente); 

            return View(clienteViewModel);
        }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    
                    var clienteDomain = _mapper.Map<ClienteViewModel, Cliente>(cliente);
                    _clienteApp.Adicionar(clienteDomain);
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(cliente);
                }
            }

            return View(cliente);
        }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);

            return View(clienteViewModel);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteViewModel cliente)
        {
            if (ModelState.IsValid)
            {
                var clienteDominio = _mapper.Map<ClienteViewModel, Cliente>(cliente);
                _clienteApp.Atualizar(clienteDominio);

                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _clienteApp.ObterPorId(id);
            var clienteViewModel = _mapper.Map<Cliente, ClienteViewModel>(cliente);
            return View(clienteViewModel);
        }

        // POST: ClientesController/Delete/5
        [HttpPost, ActionName("Delete")]      
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmado(int id)
        {
            try
            {
                var cliente = _clienteApp.ObterPorId(id);
                _clienteApp.Excluir(cliente);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
