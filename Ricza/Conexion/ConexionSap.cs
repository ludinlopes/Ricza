
using SAPbobsCOM;
using System.Runtime.CompilerServices;

namespace ApiSap.Conexion
{
    public class ConexionSap
    {
        //SAPbobsCOM.Company myCompany;
        private int error = 0;
        private string error_sessage = "";  

        public ConexionSap()
        {
            
            
        }
        public SAPbobsCOM.Company connector() {
            //string lista = "";
            SAPbobsCOM.Company myCompany = new SAPbobsCOM.Company();
            try
            {
                Console.WriteLine("Intentando conectarse a sap b1...");
                
                myCompany.SLDServer = "192.168.5.251:40000";
                myCompany.Server = "192.168.5.251:30015";
                myCompany.CompanyDB = "Z_RICZA_PRUEBAS_04_04_2023";
                myCompany.UserName = "manager";
                myCompany.Password = "1234";
                myCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB;
                myCompany.language = SAPbobsCOM.BoSuppLangs.ln_Spanish_La;

            }
            catch (Exception)
            {
                throw;
            }
            return myCompany;
        }

    }
}
