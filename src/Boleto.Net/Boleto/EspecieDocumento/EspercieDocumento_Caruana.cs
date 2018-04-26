using System;
using System.Collections.Generic;
using System.Text;

namespace BoletoNet
{
    #region Enumerado

    public enum EnumEspecieDocumento_Caruana
    {
        //01 Duplicata
        //02 Nota Promissória
        //03 Cheque
        //04 Letra de Câmbio
        //05 Recibo
        //08 Apólice de Seguro
        //12 Duplicata de Serviço
        //99 Outros

        Duplicata = 1,
        NotaPromissoria = 2,
        Cheque = 3,
        LetraCambio = 4,
        Recibo = 5,
        ApoliceSeguro = 8,
        DuplicataServico = 12,
        Outros = 99
    }

    #endregion

    public class EspecieDocumento_Caruana : AbstractEspecieDocumento, IEspecieDocumento
    {
        #region Construtores

        public EspecieDocumento_Caruana()
        {
            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public EspecieDocumento_Caruana(string codigo)
        {
            try
            {
                this.carregar(codigo);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        #endregion

        #region Metodos Privados

        public string getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana especie)
        {
            return ((int)especie).ToString();
        }

        public EnumEspecieDocumento_Caruana getEnumEspecieByCodigo(string codigo)
        {
            int CodigoEnum = Convert.ToInt32(codigo);
            return (EnumEspecieDocumento_Caruana)Enum.ToObject(typeof(EnumEspecieDocumento_Caruana), CodigoEnum);
        }

        private void carregar(string idCodigo)
        {
            try
            {
                this.Banco = new Banco_Caruana();

                switch (getEnumEspecieByCodigo(idCodigo))
                {
                    case EnumEspecieDocumento_Caruana.Cheque:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.Cheque);
                        this.Especie = "CHEQUE";
                        this.Sigla = "CH";
                        break;
                    case EnumEspecieDocumento_Caruana.Duplicata:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.Duplicata);
                        this.Especie = "DUPLICATA MERCANTIL";
                        this.Sigla = "DM";
                        break;
                    case EnumEspecieDocumento_Caruana.DuplicataServico:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.DuplicataServico);
                        this.Especie = "DUPLICATA DE SERVIÇO";
                        this.Sigla = "DS";
                        break;
                    case EnumEspecieDocumento_Caruana.LetraCambio:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.LetraCambio);
                        this.Especie = "LETRA DE CAMBIO";
                        this.Sigla = "LC";
                        break;
                    case EnumEspecieDocumento_Caruana.NotaPromissoria:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.NotaPromissoria);
                        this.Especie = "NOTA PROMISSÓRIA";
                        this.Sigla = "NP";
                        break;
                    case EnumEspecieDocumento_Caruana.Recibo:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.Recibo);
                        this.Especie = "RECIBO";
                        this.Sigla = "RC";
                        break;
                    case EnumEspecieDocumento_Caruana.ApoliceSeguro:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.ApoliceSeguro);
                        this.Especie = "APÓLICE DE SEGURO";
                        this.Sigla = "AP";
                        break;
                    case EnumEspecieDocumento_Caruana.Outros:
                        this.Codigo = getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.Outros);
                        this.Especie = "OUTROS";
                        this.Sigla = "OUTROS";
                        break;
                    default:
                        this.Codigo = "0";
                        this.Especie = "( Selecione )";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao carregar objeto", ex);
            }
        }

        public static EspeciesDocumento CarregaTodas()
        {
            try
            {
                EspeciesDocumento alEspeciesDocumento = new EspeciesDocumento();
                EspecieDocumento_Caruana ed = new EspecieDocumento_Caruana();

                foreach (EnumEspecieDocumento_Caruana item in Enum.GetValues(typeof(EnumEspecieDocumento_Caruana)))
                {
                    alEspeciesDocumento.Add(new EspecieDocumento_Caruana(ed.getCodigoEspecieByEnum(item)));
                }

                return alEspeciesDocumento;

            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao listar objetos", ex);
            }
        }

        public override IEspecieDocumento DuplicataMercantil()
        {
            return new EspecieDocumento_Caruana(getCodigoEspecieByEnum(EnumEspecieDocumento_Caruana.Duplicata));
        }

        #endregion
    }
}
