﻿using System;
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
            LocadorDAL locadorDAL = new LocadorDAL();
            LocadorControllerModel locadorViewModel = LocadorConvertToModel(locadorDAL.ListarLocador());
            return View(locadorViewModel);
        }

        [HttpGet]
        public JsonResult SelecionarLocadorJR(int codigoLocador)
        {
            LocadorDAL locadorDAL = new LocadorDAL();
            Locador locador = locadorDAL.SelecionarLocadorId(codigoLocador);
            return Json(locador, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult CadastrarVeiculoAR(string txtCodigoLocador, string selTipoVeiculo, string txtMarcaVeiculo, string txtModeloVeiculo, string txtCorVeiculo, string selCombustivelVeiculo, string selSituacaoVeiculo, string txtPlacaVeiculo, string txtRenavamVeiculo, string txtValorDiariaVeiculo)
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
                    veiculo = new Veiculo(Convert.ToInt32(txtCodigoLocador), selTipoVeiculo, txtMarcaVeiculo, txtModeloVeiculo, txtPlacaVeiculo, txtRenavamVeiculo, selCombustivelVeiculo, txtCorVeiculo, Convert.ToDecimal(txtValorDiariaVeiculo), Convert.ToChar(selSituacaoVeiculo));
                    veiculoDAL.CadastrarVeiculo(veiculo);

                    TempData[Constantes.MensagemAlerta] = "Veiculo cadastrado com sucesso!";
                    return RedirectToAction("Index", "Inicio");
                }
            }               

        }

        public ActionResult AlterarVeiculoUI()
        {

            LocadorDAL locadorDAL = new LocadorDAL();
            LocadorControllerModel locadorViewModel = LocadorConvertToModel(locadorDAL.ListarLocador());
            return View(locadorViewModel);

            VeiculoDAL veiculoDAL = new VeiculoDAL();
            VeiculoControllerModel veiculoViewModel = VeiculoConvertToModel(veiculoDAL.ListarVeiculo());
            return View(veiculoViewModel);
        }
    }
}