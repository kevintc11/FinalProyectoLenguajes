using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogicaNegocio
{
    public class ListPlatoInfo
    {

        List<PlatoInfo> listaPlatos = new List<PlatoInfo>();

        public ListPlatoInfo() { }

        public void addPlato(PlatoInfo plato)
        {
            listaPlatos.Add(plato);
        }

        public List<PlatoInfo> GetListPlatoInfo()
        {
            return listaPlatos;
        }

        public void eliminarPlato(PlatoInfo platoRemove)
        {
            listaPlatos.Remove(platoRemove);
        }

        public Boolean contienePlato(int platoIDSearch)
        {

            PlatoInfo plato = new PlatoInfo();

            foreach (PlatoInfo info in listaPlatos)
            {
                if (info.getPlatoID() == platoIDSearch)
                {
                    return true;
                }
            }

            return false;
        }

        public PlatoInfo getPlato(int platoID)
        {
            PlatoInfo plato = new PlatoInfo();

            foreach (PlatoInfo info in listaPlatos)
            {
                if (info.getPlatoID() == platoID)
                {
                    plato = info;
                }
            }
            return plato;
        }

        public void modificarCantidadPlatos(int cantidadNueva, int platoID)
        {
            foreach (PlatoInfo info in listaPlatos)
            {
                if (info.getPlatoID() == platoID)
                {
                    info.setCantidadPlato(cantidadNueva);
                    info.setPrecioTotal(info.getPrecioPlato() * Decimal.ToInt32(info.getCantidadPlato()));
                    return;
                }
            }

        }


        public void setCantidadPlatoExistente(int cantidadNueva, int platoID)
        {
            foreach (PlatoInfo info in listaPlatos)
            {
                if (info.getPlatoID() == platoID)
                {
                    info.setCantidadPlato(info.getCantidadPlato() + cantidadNueva);
                    info.setPrecioTotal(info.getPrecioPlato() * Decimal.ToInt32(info.getCantidadPlato()));
                    return;
                }
            }

        }

        public Boolean isEmpty()
        {
            if (listaPlatos.Count() >= 1)
            {
                return false;
            }

            return true;
        }

    }
}