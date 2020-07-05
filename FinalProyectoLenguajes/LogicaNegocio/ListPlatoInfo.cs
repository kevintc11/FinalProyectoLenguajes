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

        public void eliminarPlato()
        {
            MessageBox.Show(listaPlatos.Count() + "");

        }
    }
}
