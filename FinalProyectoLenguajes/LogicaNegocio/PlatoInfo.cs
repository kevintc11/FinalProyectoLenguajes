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
        public decimal precioPlato { get; set; }
        public int pedidoID { get; set; }
        public string nombrePlato { get; set; }

        public PlatoInfo(int platoID, int cantidadPlato, int pedidoID, decimal precioPlato, string nombrePlato)
        {
            this.platoID = platoID;
            this.cantidadPlato = cantidadPlato;
            this.pedidoID = pedidoID;
            this.nombrePlato = nombrePlato;
            this.precioPlato = precioPlato;
            this.precioTotal = precioPlato * cantidadPlato;
        }

        public PlatoInfo() { }

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

        public decimal getPrecioTotal()
        {
            return precioTotal;
        }

        public decimal getPrecioPlato()
        {
            return precioPlato;
        }

        public int getCantidadPlato()
        {
            return cantidadPlato;
        }

        public void setCantidadPlato(int cantidadPlato)
        {
            this.cantidadPlato = cantidadPlato;
        }

        public void setPrecioTotal(decimal precioTotal)
        {
            this.precioTotal = precioTotal;
        }
    }
}