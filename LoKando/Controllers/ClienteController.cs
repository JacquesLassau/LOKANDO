using System;
using LoKando.Models;
using LoKando.DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoKando.Models.ControllerModel;

namespace LoKando.Controllers
{
    public class ClienteController : Controller
    {
        public ClienteControllerModel ConvertToModel(List<Cliente> listaCliente)
        {
            ClienteControllerModel clienteControllerModel = new ClienteControllerModel();
            if(listaCliente != null)
            {
                // for está sendo usado para CASO deseje incluir validação no carregamento dos registros via controller
                foreach(var cliente in listaCliente)
                {
                    clienteControllerModel.Cliente.Add(cliente);
                }
            }

            return clienteControllerModel;
        }

        [HttpGet]
        public ActionResult CadastrarClienteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                return View("CadastrarClienteUI");
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarClienteAR(string txtNomeCliente, string txtHabilitacaoCliente, string txtCpfCliente, string txtRgCliente, string txtNascimentoCliente,string txtEmailCliente, string txtTelefoneCliente, string txtEnderecoCliente, string txtBairroCliente, string txtCidadeCliente, string selEstadoCliente, string txtCepCliente,string selSituacaoCliente, string txtSenhaCliente)
        {
            if (ValidarAdmin.UsuarioValido())
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
                    usuario = new Usuario(txtEmailCliente, txtSenhaCliente, cliente.TipoUsuarioCliente, Convert.ToChar(selSituacaoCliente));
                    cliente = new Cliente(txtNomeCliente, txtHabilitacaoCliente, txtCpfCliente, txtRgCliente, Convert.ToDateTime(txtNascimentoCliente), txtEmailCliente, txtTelefoneCliente, txtEnderecoCliente, txtBairroCliente, txtCidadeCliente, selEstadoCliente, txtCepCliente, Convert.ToChar(selSituacaoCliente));

                    usuarioDAL.CadastrarUsuario(usuario);
                    clienteDAL.CadastrarCliente(cliente);

                    TempData[Constantes.MensagemAlerta] = "Cliente cadastrado com sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public ActionResult AlterarClienteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                ClienteControllerModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                return View(clienteViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarClienteAR(string txtCodigoCliente, string txtNomeCliente, string txtRgCliente, string txtNascimentoCliente, string txtTelefoneCliente, string txtEnderecoCliente, string txtBairroCliente, string txtCidadeCliente, string selEstadoCliente, string txtCepCliente, string selSituacaoCliente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                Cliente cliente = clienteDAL.SelecionarClienteId(Convert.ToInt32(txtCodigoCliente));

                if (cliente.CodigoCliente == 0)
                {
                    TempData[Constantes.MensagemAlerta] = "Não existe Cliente para o código digitado... Tente novamente!";
                    ClienteControllerModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                    return View("AlterarClienteUI", clienteViewModel);
                }
                else
                {
                    cliente = new Cliente(Convert.ToInt32(txtCodigoCliente), txtNomeCliente, txtRgCliente, Convert.ToDateTime(txtNascimentoCliente), txtTelefoneCliente, txtEnderecoCliente, txtBairroCliente, txtCidadeCliente, selEstadoCliente, txtCepCliente, Convert.ToChar(selSituacaoCliente));
                    clienteDAL.AlterarCliente(cliente);
                    TempData[Constantes.MensagemAlerta] = "Cliente Alterado com Sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public JsonResult SelecionarClienteJR(int codigoCliente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                Cliente cliente = clienteDAL.SelecionarClienteId(codigoCliente);
                return Json(cliente, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Esta informação não pode ser solicitada. Por favor, contate o administrador do sistema.", JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public ActionResult ConsultarClienteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                ClienteControllerModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                return View(clienteViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public ActionResult ExcluirClienteUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                ClienteControllerModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                return View(clienteViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirClienteAR(string txtCodigoCliente)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                ClienteDAL clienteDAL = new ClienteDAL();
                Cliente cliente = clienteDAL.SelecionarClienteId(Convert.ToInt32(txtCodigoCliente));

                if (cliente.CodigoCliente == 0)
                {
                    TempData[Constantes.MensagemAlerta] = "Não existe Cliente para o código digitado... Tente novamente!";
                    ClienteControllerModel clienteViewModel = ConvertToModel(clienteDAL.ListarCliente());
                    return View("ExcluirClienteUI", clienteViewModel);
                }
                else
                {
                    cliente.CodigoCliente = Convert.ToInt32(txtCodigoCliente);
                    clienteDAL.ExcluirCliente(cliente);
                    TempData[Constantes.MensagemAlerta] = "Cliente Excluído com Sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }
    }
}