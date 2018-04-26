using System;
using System.Collections;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumInstrucoes_Caruana
    {
        Protestar = 9,                      // Emite aviso ao sacado após N dias do vencto, e envia ao cartório após 5 dias úteis
        NaoProtestar = 10,                  // Inibe protesto, quando houver instrução permanente na conta corrente
        ImportanciaporDiaDesconto = 30,
        Percentual_Multa = 35,
        ProtestoFinsFalimentares = 42,
        ProtestarAposNDiasCorridos = 81,
        ProtestarAposNDiasUteis = 82,
        NaoReceberAposNDias = 91,
        DevolverAposNDias = 92,
        JurosdeMora = 998,
        DescontoporDia = 999,
    }

    #endregion

    public class Instrucao_Caruana : AbstractInstrucao, IInstrucao
    {

        #region Construtores

        public Instrucao_Caruana()
        {
            try
            {
                this.Banco = new Banco(655);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public Instrucao_Caruana(int codigo)
        {
            this.carregar(codigo, 0);
        }

        public Instrucao_Caruana(int codigo, int nrDias)
        {
            this.carregar(codigo, nrDias);
        }

        public Instrucao_Caruana(int codigo, double valor)
        {
            this.carregar(codigo, valor);
        }
        #endregion

        #region Metodos Privados

        private void carregar(int idInstrucao, double valor)
        {
            try
            {
                this.Banco = new Banco_Votorantim();
                this.Valida();

                switch ((EnumInstrucoes_Caruana)idInstrucao)
                {
                    case EnumInstrucoes_Caruana.Percentual_Multa:
                        this.Codigo = (int)EnumInstrucoes_Caruana.Percentual_Multa;
                        this.Descricao = "Após vencimento cobrar multa de " + valor + " %";
                        break;
                    case EnumInstrucoes_Caruana.JurosdeMora:
                        this.Codigo = (int)EnumInstrucoes_Caruana.JurosdeMora;
                        this.Descricao = "Após vencimento cobrar R$ " + valor + " por dia de atraso";
                        break;
                    default:
                        this.Codigo = 0;
                        this.Descricao = " (Selecione) ";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        private void carregar(int idInstrucao, int nrDias)
        {
            try
            {
                this.Banco = new Banco_Votorantim();
                this.Valida();

                switch ((EnumInstrucoes_Caruana)idInstrucao)
                {
                    case EnumInstrucoes_Caruana.Protestar:
                        this.Codigo = (int)EnumInstrucoes_Caruana.Protestar;
                        this.Descricao = "Protestar após " + nrDias + " dias úteis.";
                        break;
                    case EnumInstrucoes_Caruana.NaoProtestar:
                        this.Codigo = (int)EnumInstrucoes_Caruana.NaoProtestar;
                        this.Descricao = "Não protestar";
                        break;
                    case EnumInstrucoes_Caruana.ImportanciaporDiaDesconto:
                        this.Codigo = (int)EnumInstrucoes_Caruana.ImportanciaporDiaDesconto;
                        this.Descricao = "Importância por dia de desconto.";
                        break;
                    case EnumInstrucoes_Caruana.ProtestoFinsFalimentares:
                        this.Codigo = (int)EnumInstrucoes_Caruana.ProtestoFinsFalimentares;
                        this.Descricao = "Protesto para fins falimentares";
                        break;
                    case EnumInstrucoes_Caruana.ProtestarAposNDiasCorridos:
                        this.Codigo = (int)EnumInstrucoes_Caruana.ProtestarAposNDiasCorridos;
                        this.Descricao = "Protestar no " + nrDias + "º dia corrido após vencimento";
                        break;
                    case EnumInstrucoes_Caruana.ProtestarAposNDiasUteis:
                        this.Codigo = (int)EnumInstrucoes_Caruana.ProtestarAposNDiasUteis;
                        this.Descricao = "Protestar no " + nrDias + "º dia útil após vencimento";
                        break;
                    case EnumInstrucoes_Caruana.NaoReceberAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Caruana.NaoReceberAposNDias;
                        this.Descricao = "Não receber após " + nrDias + " dias do vencimento";
                        break;
                    case EnumInstrucoes_Caruana.DevolverAposNDias:
                        this.Codigo = (int)EnumInstrucoes_Caruana.DevolverAposNDias;
                        this.Descricao = "Devolver após " + nrDias + " dias do vencimento";
                        break;
                    case EnumInstrucoes_Caruana.JurosdeMora:
                        this.Codigo = (int)EnumInstrucoes_Caruana.JurosdeMora;
                        this.Descricao = "Após vencimento cobrar R$ "; // por dia de atraso
                        break;
                    case EnumInstrucoes_Caruana.DescontoporDia:
                        this.Codigo = (int)EnumInstrucoes_Caruana.DescontoporDia;
                        this.Descricao = "Conceder desconto de R$ "; // por dia de antecipação
                        break;
                    default:
                        this.Codigo = 0;
                        this.Descricao = "( Selecione )";
                        break;
                }

                this.QuantidadeDias = nrDias;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public override void Valida()
        {
            //base.Valida();
        }

        #endregion

    }
}
