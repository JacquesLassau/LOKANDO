﻿using System.Data.SqlClient;
using LoKando.Models;
using LoKando.DAL.Conn;
using LoKando;
using System.Data;
using System.Collections.Generic;
using System;

namespace LoKando.DAL
{
    public class UsuarioDAL
    {
        public Conexao Conexao { get; set; }

        public UsuarioDAL()
        {
            Conexao = new Conexao();
        }

        public void CadastrarUsuario(Usuario usuario){
            
            using (SqlConnection conexao = Conexao.ConexaoDatabase()){

                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_CadastrarUsuarioV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@USEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@USSENHALOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@USTPUSULOK", SqlDbType.Char, 1);
                comandoDML.Parameters.Add("@USSITLOK", SqlDbType.Char, 1);
                
                comandoDML.Parameters["@USEMAILLOK"].Value = usuario.EmailUsuario;
                comandoDML.Parameters["@USSENHALOK"].Value = usuario.SenhaUsuario;
                comandoDML.Parameters["@USTPUSULOK"].Value = usuario.TipoUsuario;
                comandoDML.Parameters["@USSITLOK"].Value = usuario.SituacaoUsuario;

                comandoDML.ExecuteNonQuery();                
                conexao.Close();
            }
        }

        public void AlterarEmailUsuario(string emailUsuario, string novoEmailUsuario){

            using (SqlConnection conexao = Conexao.ConexaoDatabase()){

                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AlterarEmailUsuarioV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@EmailUsuario", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@NovoEmailUsuario", SqlDbType.VarChar, 100);                

                comandoDML.Parameters["@EmailUsuario"].Value = emailUsuario;
                comandoDML.Parameters["@NovoEmailUsuario"].Value = novoEmailUsuario;
               

                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void AlterarSenhaUsuario(string emailUsuario, string senhaUsuario, string novaSenhaUsuario){

            using (SqlConnection conexao = Conexao.ConexaoDatabase()){

                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AlterarSenhaUsuarioV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@EmailUsuario", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@SenhaUsuario", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@NovaSenhaUsuario", SqlDbType.VarChar, 100);

                comandoDML.Parameters["@EmailUsuario"].Value = emailUsuario;
                comandoDML.Parameters["@SenhaUsuario"].Value = senhaUsuario;
                comandoDML.Parameters["@NovaSenhaUsuario"].Value = senhaUsuario;


                comandoDML.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public Usuario SelecionarUsuarioEmail(string buscaEmailUsuario)
        {

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                Usuario usuario = new Usuario(buscaEmailUsuario);

                SqlCommand comandoDML = new SqlCommand("SP_SelecionarUsuarioEmailV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@USEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters["@USEMAILLOK"].Value = buscaEmailUsuario;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool consultarEmailUsuario = dr.HasRows;

                if (consultarEmailUsuario == false)
                {
                    usuario.EmailUsuario = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        int idUsuario = Convert.ToInt32(dr["USIDUSU"]);
                        string emailUsuario = Convert.ToString(dr["USEMAILLOK"]);
                        string senhaUsuario = Convert.ToString(dr["USSENHALOK"]);
                        string situacaoUsuario = Convert.ToString(dr["USSITLOK"]);
                        string ultimaAtualizacaoUsuario = Convert.ToString(dr["USUHRREG"]);

                        usuario = new Usuario(idUsuario, emailUsuario, senhaUsuario, Convert.ToChar(situacaoUsuario));
                    }
                }

                conexao.Close();
                return usuario;
            }
        }

        public Usuario AcessoUsuario(Usuario usuario)
        {

            using (SqlConnection conexao = Conexao.ConexaoDatabase())
            {
                conexao.Open();

                SqlCommand comandoDML = new SqlCommand("SP_AcessoUsuarioV1", conexao);
                comandoDML.CommandType = CommandType.StoredProcedure;

                comandoDML.Parameters.Add("@USEMAILLOK", SqlDbType.VarChar, 100);
                comandoDML.Parameters.Add("@USSENHALOK", SqlDbType.VarChar, 100);

                comandoDML.Parameters["@USEMAILLOK"].Value = usuario.EmailUsuario;
                comandoDML.Parameters["@USSENHALOK"].Value = usuario.SenhaUsuario;

                SqlDataReader dr = comandoDML.ExecuteReader();

                bool verificarUsuario = dr.HasRows;

                if (verificarUsuario == false)
                {
                    usuario = null;
                }
                else
                {
                    while (dr.Read())
                    {
                        string emailUsuario = Convert.ToString(dr["USEMAILLOK"]);
                        string senhaUsuario = Convert.ToString(dr["USSENHALOK"]);
                        usuario = new Usuario(emailUsuario, senhaUsuario);
                    }
                }

                conexao.Close();
                return usuario;
            }
        }        
    }
}