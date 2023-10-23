using ApiSap.Conexion;
using Ricza.Models;
using SAPbobsCOM;

namespace Ricza.Implement
{
    public class ImItem
    {
        private ConexionSap cn = new ConexionSap();
        private SAPbobsCOM.Company myCompany = new SAPbobsCOM.Company();

        public MArticulo GetItem(String Codigo) {
            myCompany = cn.connector();
            myCompany.Connect();
            MArticulo Item = new MArticulo();
            var ItemSap = (Items)myCompany.GetBusinessObject(BoObjectTypes.oItems);
            if (ItemSap.GetByKey(Codigo))
            {
                Item.ItemCode = ItemSap.ItemCode;
                Item.Marca = "Indefinido";//ItemSap.QuantityOnStock.ToString();.
                Item.Modelo = "Indefinido";
                Item.ItemName = ItemSap.ItemName;
                Item.UserText = ItemSap.User_Text;
                Item.OnHand = (int?)ItemSap.QuantityOnStock;
                Item.Precio = ItemSap.PricingUnit;
                Item.U_TipoA2 = ItemSap.UserFields.Fields.Item("U_TipoA2").Value;
                Item.PicturName = ItemSap.Picture;


                Item.Metodo = "Buscar";
                Item.Controlador = "Articulo";
            }

            return Item;
        }
    }
}
