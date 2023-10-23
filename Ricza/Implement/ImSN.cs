using ApiSap.Conexion;
using Microsoft.AspNetCore.Mvc;
using Ricza.Models;
using SAPbobsCOM;

namespace Ricza.Implement
{
    public class ImSN : Controller
    {
        private ConexionSap cn = new ConexionSap();
        private SAPbobsCOM.Company myCompany = new SAPbobsCOM.Company();

        public MSocioNegocios Consulta(string Codigo)
        {
            myCompany = cn.connector();
            myCompany.Connect();
            MSocioNegocios sn = new MSocioNegocios();
            BusinessPartners mySN = (BusinessPartners)myCompany.GetBusinessObject(BoObjectTypes.oBusinessPartners);
            PaymentTermsTypes metodPay = (PaymentTermsTypes)myCompany.GetBusinessObject(BoObjectTypes.oPaymentTermsTypes);
            var vendedor = (SalesPersons)myCompany.GetBusinessObject(BoObjectTypes.oSalesPersons);

            if (mySN.GetByKey(Codigo))
            {
                sn.CardCode = mySN.CardCode;
                if (mySN.CardType.ToString() == "cCustomer")
                {
                    sn.CardType = "Cliente";
                }
                //sn.CardType = mySN.CardType.ToString();
                sn.CardName = mySN.CardName;
                sn.Address = mySN.Address;
                sn.U_NIT = mySN.UserFields.Fields.Item("U_NIT").Value;
                sn.Phone1 = mySN.Phone1;
                sn.E_Mail = mySN.EmailAddress;
                sn.Name = mySN.ContactPerson;
                if (metodPay.GetByKey(mySN.PayTermsGrpCode))
                {
                    sn.GroupNum = metodPay.PaymentTermsGroupName;
                }
                if (vendedor.GetByKey(mySN.SalesPersonCode))
                {
                    sn.SlpCode = vendedor.SalesEmployeeName;
                }
                sn.Currency = mySN.Currency;
                sn.Balance = mySN.CurrentAccountBalance.ToString();

                sn.U_Vendedor_2 = mySN.UserFields.Fields.Item("U_Vendedor_2").Value;
                sn.U_Vendedor_3 = mySN.UserFields.Fields.Item("U_Vendedor_3").Value;
                sn.U_Vendedor_4 = mySN.UserFields.Fields.Item("U_Vendedor_4").Value;
                sn.U_Vendedor_5 = mySN.UserFields.Fields.Item("U_Vendedor_5").Value;



            }
            else
            {
                sn.CardCode = "No encontrado";
                sn.CardName = "No encontrado";
            }
            myCompany.Disconnect();
            return sn;

        }
    }
}
