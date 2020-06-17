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
    public class VeiculoController : Controller
    {
        public LocadorControllerModel LocadorConvertToModel(List<Locador> listaLocador)
        {
            LocadorControllerModel locadorControllerModel = new LocadorControllerModel();
            if (listaLocador != null)
            {
                // for está sendo usado para CASO deseje incluir validação no carregamento dos registros via controller
                foreach (var locador in listaLocador)
                {
                    locadorControllerModel.Locador.Add(locador);
                }
            }

            return locadorControllerModel;
        }

        public VeiculoControllerModel VeiculoConvertToModel(List<Veiculo> listaVeiculo)
        {
            VeiculoControllerModel veiculoControllerModel = new VeiculoControllerModel();
            if (listaVeiculo != null)
            {
                // for está sendo usado para CASO deseje incluir validação no carregamento dos registros via controller
                foreach (var veiculo in listaVeiculo)
                {
                    veiculoControllerModel.Veiculo.Add(veiculo);
                }
            }

            return veiculoControllerModel;
        }

        [HttpGet]
        public ActionResult CadastrarVeiculoUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                LocadorControllerModel locadorViewModel = LocadorConvertToModel(locadorDAL.ListarLocador());
                return View(locadorViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CadastrarVeiculoAR(string txtCodigoLocador, string selTipoVeiculo, string txtMarcaVeiculo, string txtModeloVeiculo, string txtCorVeiculo, string selCombustivelVeiculo, string txtAnoVeiculo, string selSituacaoVeiculo, string txtPlacaVeiculo, string txtRenavamVeiculo, string txtValorDiariaVeiculo)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                VeiculoDAL veiculoDAL = new VeiculoDAL();

                Locador locador = new Locador();
                Veiculo veiculo = new Veiculo();

                if (txtCodigoLocador == "" || txtCodigoLocador == null)
                {
                    TempData[Constantes.MensagemAlerta] = "Acesso Negado! Não é possível incluir um veículo sem o código do locador. Tente novamente... ";
                    return RedirectToAction("CadastrarVeiculoUI", "Veiculo");

                }
                else
                {
                    Locador codigoLocador = locadorDAL.SelecionarLocadorId(Convert.ToInt32(txtCodigoLocador));
                    Veiculo placaVeiculo = veiculoDAL.SelecionarVeiculoPlaca(txtPlacaVeiculo);
                    Veiculo renavamVeiculo = veiculoDAL.SelecionarVeiculoRenavam(txtRenavamVeiculo);

                    if (codigoLocador.CodigoLocador == 0)
                    {
                        TempData[Constantes.MensagemAlerta] = "Código do Locador inválido! Tente novamente... ";
                        return RedirectToAction("CadastrarVeiculoUI", "Veiculo");
                    }
                    else if (placaVeiculo.PlacaVeiculo != null)
                    {
                        TempData[Constantes.MensagemAlerta] = "Esta placa de veículo já existe no sistema! Tente novamente... ";
                        return RedirectToAction("CadastrarVeiculoUI", "Veiculo");
                    }
                    else if (renavamVeiculo.RenavamVeiculo != null)
                    {
                        TempData[Constantes.MensagemAlerta] = "Este RENAVAM já existe no sistema! Tente novamente... ";
                        return RedirectToAction("CadastrarVeiculoUI", "Veiculo");
                    }
                    else
                    {
                        veiculo = new Veiculo(Convert.ToInt32(txtCodigoLocador), selTipoVeiculo, txtMarcaVeiculo, txtModeloVeiculo, txtPlacaVeiculo, txtRenavamVeiculo, selCombustivelVeiculo, txtCorVeiculo, txtAnoVeiculo, Convert.ToDecimal(txtValorDiariaVeiculo), Convert.ToChar(selSituacaoVeiculo));
                        veiculoDAL.CadastrarVeiculo(veiculo);

                        TempData[Constantes.MensagemAlerta] = "Veiculo cadastrado com sucesso!";
                        return RedirectToAction("Index", "Inicio");
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }
        }

        [HttpGet]
        public ActionResult AlterarVeiculoUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                VeiculoDAL veiculoDAL = new VeiculoDAL();
                VeiculoControllerModel veiculoViewModel = VeiculoConvertToModel(veiculoDAL.ListarVeiculoLocador());
                return View(veiculoViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }                      
        }

        [HttpGet]
        public ActionResult ConsultarVeiculoUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                VeiculoDAL veiculoDAL = new VeiculoDAL();
                VeiculoControllerModel veiculoViewModel = VeiculoConvertToModel(veiculoDAL.ListarVeiculoLocador());
                return View(veiculoViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        public ActionResult ExcluirVeiculoUI()
        {
            if (ValidarAdmin.UsuarioValido())
            {
                VeiculoDAL veiculoDAL = new VeiculoDAL();
                VeiculoControllerModel veiculoViewModel = VeiculoConvertToModel(veiculoDAL.ListarVeiculoLocador());
                return View(veiculoViewModel);
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }            
        }

        [HttpGet]
        public JsonResult SelecionarLocadorJR(int codigoLocador)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                Locador locador = locadorDAL.SelecionarLocadorId(codigoLocador);
                return Json(locador, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Esta informação não pode ser solicitada. Por favor, contate o administrador do sistema.", JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpGet]
        public JsonResult SelecionarVeiculoLocadorJR(string placaVeiculo)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                VeiculoDAL veiculoDAL = new VeiculoDAL();
                Veiculo veiculo = veiculoDAL.SelecionarVeiculoPlaca(placaVeiculo);
                return Json(veiculo, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("Esta informação não pode ser solicitada. Por favor, contate o administrador do sistema.", JsonRequestBehavior.AllowGet);
            }
            
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AlterarVeiculoAR(string txtCodigoLocador, string selTipoVeiculo, string txtMarcaVeiculo, string txtModeloVeiculo, string txtPlacaVeiculo, string txtCorVeiculo, string selCombustivelVeiculo, string txtAnoVeiculo, string selSituacaoVeiculo, string txtValorDiariaVeiculo)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                LocadorDAL locadorDAL = new LocadorDAL();
                VeiculoDAL veiculoDAL = new VeiculoDAL();

                Locador locador = new Locador();
                Veiculo veiculo = new Veiculo();

                if (txtCodigoLocador == "" || txtCodigoLocador == null)
                {
                    TempData[Constantes.MensagemAlerta] = "Acesso Negado! Não é possível alterar um veículo sem o código do locador. Tente novamente... ";
                    return RedirectToAction("AlterarVeiculoUI", "Veiculo");
                }
                else
                {
                    Locador codigoLocador = locadorDAL.SelecionarLocadorId(Convert.ToInt32(txtCodigoLocador));

                    if (codigoLocador.CodigoLocador == 0)
                    {
                        TempData[Constantes.MensagemAlerta] = "Código do Locador inválido! Tente novamente... ";
                        return RedirectToAction("AlterarVeiculoUI", "Veiculo");
                    }
                    else
                    {
                        veiculo = new Veiculo(Convert.ToInt32(txtCodigoLocador), selTipoVeiculo, txtMarcaVeiculo, txtModeloVeiculo, txtPlacaVeiculo, selCombustivelVeiculo, txtCorVeiculo, txtAnoVeiculo, Convert.ToDecimal(txtValorDiariaVeiculo), Convert.ToChar(selSituacaoVeiculo));
                        veiculoDAL.AlterarVeiculo(veiculo);

                        TempData[Constantes.MensagemAlerta] = "Veiculo Alterado com sucesso!";
                        return RedirectToAction("Index", "Inicio");
                    }
                }
            }
            else
            {
                return RedirectToAction("Login", "AreaRestrita");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirVeiculoAR(string txtPlacaVeiculo)
        {
            if (ValidarAdmin.UsuarioValido())
            {
                VeiculoDAL veiculoDAL = new VeiculoDAL();
                Veiculo veiculo = new Veiculo();
                Veiculo placaVeiculo = veiculoDAL.SelecionarVeiculoPlaca(txtPlacaVeiculo);

                if (placaVeiculo.PlacaVeiculo == null)
                {
                    TempData[Constantes.MensagemAlerta] = "Acesso Negado! Não Existe o veículo no sistema! Tente novamente... ";
                    return RedirectToAction("ExcluirVeiculoUI", "Veiculo");
                }
                else
                {
                    veiculo = new Veiculo(txtPlacaVeiculo);
                    veiculoDAL.ExcluirVeiculo(veiculo);
                    TempData[Constantes.MensagemAlerta] = "Veiculo excluído com sucesso!";
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