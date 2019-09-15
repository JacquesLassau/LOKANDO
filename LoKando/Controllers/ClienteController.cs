using System;
using LoKando.Models;
using LoKando.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoKando.Models.ViewModel;

namespace LoKando.Controllers
{
    public class ClienteController : Controller
    {
        public ClienteModel ConvertToModel(List<Cliente> listaCliente)
        {
            ClienteModel clienteViewModel = new ClienteModel();
            if(listaCliente != null)
            {
                foreach(var cliente in listaCliente)
                {
                    clienteViewModel.Cliente.Add(cliente);
                }
            }

            return clienteViewModel;
        }

        [HttpGet]
        public ActionResult CadastrarClienteUI()
        {
            return View("CadastrarClienteUI");
        }


        [HttpPost]                                                                                                                                                                                                              
        public ActionResult CadastrarClienteAR(string txtNomeCliente, string txtHabilitacaoCliente, string txtCpfCliente, string txtRgCliente, string txtNascimentoCliente,string txtEmailCliente, string txtTelefoneCliente, string txtLogadouroCliente, string txtCidadeCliente, string selEstadoCliente, string txtCepCliente,string selSituacaoCliente, string txtSenhaCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            UsuarioDAL usuarioDAL = new UsuarioDAL();
            Cliente cliente = new Cliente();
            Usuario usuario = new Usuario();

            Cliente clienteEmail = clienteDAL.SelecionarClienteEmail(txtEmailCliente);
            Cliente clienteHabil = clienteDAL.SelecionarClienteHabilitacao(txtHabilitacaoCliente);
            Cliente clienteCpf = clienteDAL.SelecionarClienteCpf(txtCpfCliente);
            Usuario usuarioEmail = usuarioDAL.SelecionarUsuarioEmail(txtEmailCliente);

            if ((usuarioEmail.EmailUsuario != null) || (clienteEmail.EmailCliente != null))
            {
                TempData[Constantes.MensagemAlerta] = "Já existe um cliente vinculado a este e-mail!";
                return View("CadastrarClienteUI");
            }
            else if (clienteHabil.HabilitacaoCliente != null)
            {              
                TempData[Constantes.MensagemAlerta] = "Já existe um cliente vinculado a esta Habilitação!";
                return View("CadastrarClienteUI");
            }
            else if (clienteCpf.CpfCliente != null)
            {                   
                TempData[Constantes.MensagemAlerta] = "Já existe um cliente vinculado a este Cpf!";
                return View("CadastrarClienteUI");
            }
            else
            {
                usuario = new Usuario(txtEmailCliente, txtSenhaCliente, Convert.ToChar(selSituacaoCliente));
                cliente = new Cliente(txtNomeCliente, txtHabilitacaoCliente, txtCpfCliente, txtRgCliente, Convert.ToDateTime(txtNascimentoCliente), txtEmailCliente, txtTelefoneCliente, txtLogadouroCliente, txtCidadeCliente, selEstadoCliente, txtCepCliente, Convert.ToChar(selSituacaoCliente));

                usuarioDAL.CadastrarUsuario(usuario);
                clienteDAL.CadastrarCliente(cliente);

                TempData[Constantes.MensagemAlerta] = "Cliente cadastrado com sucesso!";
                return RedirectToAction("Index", "Inicio");
            }
        }

        [HttpGet]
        public ActionResult AlterarClienteUI()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
            return View(clienteViewModel); 
        }

        [HttpPost]
        public ActionResult AlterarClienteAR(string txtCodigoCliente, string txtNomeCliente, string txtRgCliente, string txtNascimentoCliente, string txtTelefoneCliente, string txtLogadouroCliente, string txtCidadeCliente, string selEstadoCliente, string txtCepCliente, string selSituacaoCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.SelecionarClienteId(Convert.ToInt32(txtCodigoCliente));

            if (cliente.CodigoCliente == 0)
            {
                TempData[Constantes.MensagemAlerta] = "Não existe Cliente para o código digitado... Tente novamente!";
                ClienteModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                return View("AlterarClienteUI", clienteViewModel);
            }
            else
            {
                cliente = new Cliente(Convert.ToInt32(txtCodigoCliente), txtNomeCliente, txtRgCliente, Convert.ToDateTime(txtNascimentoCliente), txtTelefoneCliente, txtLogadouroCliente, txtCidadeCliente, selEstadoCliente, txtCepCliente, Convert.ToChar(selSituacaoCliente));
                clienteDAL.AlterarCliente(cliente);
                TempData[Constantes.MensagemAlerta] = "Cliente Alterado com Sucesso!";
                return RedirectToAction("Index", "Inicio");
            }
        }

        [HttpGet]
        public JsonResult SelecionarClienteJR(int codigoCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.SelecionarClienteId(codigoCliente);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult ConsultarClienteUI()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
            return View(clienteViewModel);
        }

        [HttpGet]
        public ActionResult ExcluirClienteUI()
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            ClienteModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
            return View(clienteViewModel);
        }

        [HttpPost]
        public ActionResult ExcluirClienteAR(string txtCodigoCliente)
        {
            ClienteDAL clienteDAL = new ClienteDAL();
            Cliente cliente = clienteDAL.SelecionarClienteId(Convert.ToInt32(txtCodigoCliente));

            if (cliente.CodigoCliente == 0)
            {
                TempData[Constantes.MensagemAlerta] = "Não existe Cliente para o código digitado... Tente novamente!";
                ClienteModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                return View("ExcluirClienteUI", clienteViewModel);
            }
            else
            {
                cliente.CodigoUsuarioCliente = Convert.ToInt32(txtCodigoCliente);
                clienteDAL.ExcluirCliente(cliente);
                TempData[Constantes.MensagemAlerta] = "Cliente Excluído com Sucesso!";
                return RedirectToAction("Index", "Inicio");
            }
        }
    }
}