using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class PlatoInfo
    {
        public int platoID { get; set; }
        public int cantidadPlato { get; set; }
        public decimal precioTotal { get; set; }
        public int pedidoID { get; set; }
        public string nombrePlato { get; set; }

        public PlatoInfo(int platoID, int cantidadPlato, int pedidoID, decimal precioPlato, string nombrePlato)
        {
            this.platoID = platoID;
            this.cantidadPlato = cantidadPlato;
            this.pedidoID = pedidoID;
            this.nombrePlato = nombrePlato;
            this.precioTotal = precioPlato * cantidadPlato;
        }

        public int getPlatoID()
        {
            return platoID;
        }

        public int getPedidoID()
        {
            return pedidoID;
        }

        public string getNombrePlato()
        {
            return nombrePlato;
        }

        //public decimal getPrecioTotal()
        //{
        //    return precioPlato * cantidadPlato;
        //}

        public decimal getPrecioTotal()
        {
            return precioTotal;
        }

        public int getCantidadPlato()
        {
            return cantidadPlato;
        }

    }
}
