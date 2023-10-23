using ApiSap.Conexion;
using Ricza.Models;
using SAPbobsCOM;
using System.Reflection;

namespace Ricza.Implement
{
    public class ImCoti
    {
        private ConexionSap cn = new ConexionSap();
        private SAPbobsCOM.Company myCompany = new SAPbobsCOM.Company();


        public MDocument GetDocument(int DocEntry, string Metodo, string Acction)
        {
            myCompany = cn.connector();
            myCompany.Connect();

            var Doc = (Documents)myCompany.GetBusinessObject(BoObjectTypes.oQuotations);
            var mDoc = new MDocument();

            if (Doc.GetByKey(DocEntry))
            {
                mDoc.DocEntry = Doc.DocEntry;
                mDoc.ObjType = (int)Doc.DocObjectCode;
                mDoc.CANCELED = Doc.Cancelled.ToString();
                //mDoc.BPLId = Doc.BPLName;
                mDoc.BPLName = Doc.BPLName;
                mDoc.DocType = Doc.DocType.ToString();
                mDoc.CardCode = Doc.CardCode;
                mDoc.CardName = Doc.CardName;
                mDoc.Address = Doc.Address;
                mDoc.U_FacNit = Doc.UserFields.Fields.Item("U_FacNit").Value;
                

                mDoc.DocDate = Doc.DocDate;
                mDoc.Series = Doc.Series;
                mDoc.DocNum = Doc.DocNum;
                mDoc.SlpCode = Doc.SalesPersonCode;
                mDoc.OwnerCode = Doc.DocumentsOwner;
                mDoc.U_FacSerie = Doc.UserFields.Fields.Item("U_FacSerie").Value;
                mDoc.U_FacNum = Doc.UserFields.Fields.Item("U_FacNum").Value;
                mDoc.U_FacNom = Doc.UserFields.Fields.Item("U_FacNom").Value;
                mDoc.U_CAE = Doc.UserFields.Fields.Item("U_CAE").Value;
                mDoc.U_Mensaje = Doc.UserFields.Fields.Item("U_Mensaje").Value;
                mDoc.U_NoCompra = Doc.UserFields.Fields.Item("U_NoCompra").Value;
                mDoc.U_U_NoEnvio = Doc.UserFields.Fields.Item("U_U_NoEnvio").Value;
                mDoc.U_CodServ = Doc.UserFields.Fields.Item("U_CodServ").Value;
                mDoc.U_Pedido = Doc.UserFields.Fields.Item("U_Pedido").Value;
                mDoc.SysRate = Doc.DocRate;
                mDoc.DocCur = Doc.DocCurrency;
                mDoc.VatSum = Doc.VatSum;
                mDoc.DocTotal = Doc.DocTotal;
                mDoc.comments = Doc.Comments;
                mDoc.metodo = Metodo;
                mDoc.controlador = "Cotizacion";
                mDoc.accion = Acction;
                mDoc.titulo = "Cotización";
                myCompany.Disconnect();
                return mDoc;
            }
            else
            {
                mDoc.CardCode = myCompany.GetLastErrorDescription();
                mDoc.CardName = "No encontrado";
                myCompany.Disconnect();
                return mDoc;
            }

            
        }
    }
}
