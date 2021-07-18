using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDowellApp.Modelo
{
    public class Pedido
    {
        public string NombreCliente  { get; set; }
        public bool EsParaLLevar { get; set; }
       
        public List<Combo> Detalle { get; set; } = new List<Combo>();


        public double CalcularTotal()
        {
            double resultado = 0;
            for (int i = 0; i < Detalle.Count; i++)
            {
                Combo combo = Detalle[i];
                resultado += combo.Precio;

            }
            return resultado;
        }          
          
       
    }   
    
}
