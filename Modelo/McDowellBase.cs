using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDowellApp.Modelo
{
    public class McDowellBase
    {
        public static Queue<Pedido> Pedidos = new Queue<Pedido>();      
        public static List<Combo> Carta { get; set; } = new List<Combo>();            

        
         public static void CargarCarta()
        {
            Combo  McDowellBasic = new Combo()
            {
                IDCombo = 1 ,
                PlatoPrincipal = "Hamburguesa Sencilla",
                Acompañamiento = "Papas",
                Bebida = "Fanta",
                Precio = 100
            };McDowellBase.Carta.Add(McDowellBasic);

            Combo McDowellFull = new Combo()
            {
                IDCombo = 2,
                PlatoPrincipal = "Hamburguesa Doble",
                Acompañamiento = "Papas",
                Bebida = "CocaCola",
                Precio = 120
            }; McDowellBase.Carta.Add(McDowellFull);

            Combo McDowellPremiun = new Combo()
            {
                IDCombo = 3,
                PlatoPrincipal = "Hamburguesa Triple",
                Acompañamiento = "Papas",
                Bebida = "CocaCola",
                Precio = 150
            }; McDowellBase.Carta.Add(McDowellPremiun);
        }
    }
}
