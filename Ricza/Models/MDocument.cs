﻿using Microsoft.VisualBasic;

namespace Ricza.Models
{
    public class MDocument
    {
        public int? DocEntry { get; set; }
        public int ObjType { get; set; }
        public string CANCELED { get; set; }
        //public int BPLId { get; set; }
        public string BPLName { get; set; }
        public string DocType { get; set; }
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string Address { get; set; }
        public string U_FacNit { get; set; }
        public DateTime DocDate { get; set; }
        public int? Series { get; set; }
        public int? DocNum { get; set; }
        public int? SlpCode { get; set; }
        public int? OwnerCode { get; set; } //Propietario

        public string U_FacSerie { get; set; }
        public string U_FacNum { get; set; }
        public string U_FacNom { get; set; }
        public string U_CAE { get; set; }
        public string U_Mensaje { get; set; }
        public string U_NoCompra { get; set; }
        public string U_U_NoEnvio { get; set; }
        public string U_CodServ { get; set; }
        public string U_Pedido { get; set; }

        public double SysRate { get; set; } //Tipo de cambio
        public string DocCur { get; set; } // Moneda
        public double VatSum { get; set; }
        public double DocTotal { get; set; }

        public string comments { get; set; }


        public string metodo { get; set; }
        public string controlador { get; set; }
        public string? accion { get; set; }
        public string? titulo { get; set; }
    }
}
