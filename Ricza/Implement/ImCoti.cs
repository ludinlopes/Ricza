using ApiSap.Conexion;
using Ricza.Models;
using SAPbobsCOM;

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

            var Doc = myCompany.GetBusinessObject(BoObjectTypes.oQuotations);
            var inv = (Items)myCompany.GetBusinessObject(BoObjectTypes.oItems);
            var InvMod = (Manufacturers)myCompany.GetBusinessObject(BoObjectTypes.oManufacturers);
            var vend = (SalesPersons)myCompany.GetBusinessObject(BoObjectTypes.oSalesPersons);
            var emp = (EmployeesInfo)myCompany.GetBusinessObject(BoObjectTypes.oEmployeesInfo);
            var mDoc = new MDocument();

            if (Doc.GetByKey(DocEntry))
            {

                mDoc.DocEntry = Doc.DocEntry;
                mDoc.ObjType = (int)Doc.DocObjectCode;
                mDoc.CANCELED = Doc.Cancelled.ToString();
                mDoc.BPLName = Doc.BPLName;
                mDoc.DocType = Doc.DocType.ToString();
                mDoc.CardCode = Doc.CardCode;
                mDoc.CardName = Doc.CardName;
                mDoc.Address = Doc.Address;
                mDoc.U_FacNit = Doc.UserFields.Fields.Item("U_FacNit").Value;
                mDoc.DocDate = Doc.DocDate;
                mDoc.Series = Doc.Series;
                mDoc.DocNum = Doc.DocNum;
                vend.GetByKey(Doc.SalesPersonCode);
                mDoc.SlpCode = vend.SalesEmployeeName;
                emp.GetByKey(Doc.DocumentsOwner);
                mDoc.OwnerCode = emp.LastName + ", " + emp.FirstName;

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
                mDoc.comments = Doc.Lines.Count.ToString();
                mDoc.metodo = Metodo;
                mDoc.controlador = "Cotizacion";
                mDoc.accion = Acction;
                mDoc.titulo = "Cotización";


                mDoc.Detalle = new List<MDetalleDoc>();
                for (int i = 0; i < Doc.Lines.Count; i++)
                {
                    Doc.Lines.SetCurrentLine(i);
                    MDetalleDoc detalle = new MDetalleDoc();

                    detalle.ItemCode = Doc.Lines.ItemCode;
                    detalle.Modelo = Doc.Lines.VendorNum;

                    inv.GetByKey(Doc.Lines.ItemCode);
                    InvMod.GetByKey(inv.Manufacturer);
                    detalle.Marca = InvMod.ManufacturerName;

                    detalle.Dscription = Doc.Lines.ItemDescription;
                    detalle.Quantity = Doc.Lines.Quantity.ToString();
                    detalle.WhsCode = Doc.Lines.WarehouseCode;
                    detalle.DiscPrcnt = Doc.Lines.DiscountPercent;

                    detalle.PrecioUnidad = Doc.Lines.PriceAfterVAT;
                    detalle.LineTotal = Doc.Lines.LineTotal + Doc.Lines.TaxTotal;
                    mDoc.Detalle.Add(detalle);

                }

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

        public void SetDocument()
        {

        }

        public void AddDocument()
        {

        }
    }

}
