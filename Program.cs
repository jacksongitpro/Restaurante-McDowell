using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using McDowellApp.Modelo;
using System.Collections;

namespace McDowellApp
{
    class Program
    {               
        static void MostrarPantallaPrincipal()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("========McDowell=======");
                    Console.WriteLine(1 + "-Nuevo Pedido        ");
                    Console.WriteLine(2 + "-Ver Proximo Pedido   ");
                    Console.WriteLine(3 + "-Preparar Proximo Pedido");
                    Console.Write("Su Eleccion: ");
                    int eleccion = int.Parse(Console.ReadLine());
                    switch (eleccion)
                    {
                        case 1:
                            NuevoPedido();
                            break;
                        case 2:
                            VerProximoPedido();
                            break;
                        case 3:
                            PrepararProximoPedido();
                            break;
                        default:
                            Console.WriteLine("Precione enter e Ingrese una opcion Valida");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
                Console.Clear();
                MostrarPantallaPrincipal();
            }         
              
        }

        static void NuevoPedido()
        {            
            Console.Clear();
            Console.WriteLine("===Nuevo Pedido===");
            Pedido pedido= new Pedido()
            {
                NombreCliente = PreguntarNombre(),
                EsParaLLevar = EsParaLLevar(),
                
            };
            //Mostrarinfo del pedido
            bool armandoPedido = true;
            while (armandoPedido)
            {
                MostrarInfoPedido(pedido);
                int eleccion = QueDeseaHacer();
                switch (eleccion)
                {
                    case 1://Agregar Pedido
                        Combo comboElegido = MostrarCarta();
                        if (comboElegido != null)
                        {
                            pedido.Detalle.Add(comboElegido);
                        }
                        break;
                    case 2://final
                        McDowellBase.Pedidos.Enqueue(pedido);
                        Console.Clear();
                        armandoPedido = false;                     
                        break;
                    case 3://cancelar
                        armandoPedido = false;
                        Console.Clear();
                        break;
                }
            }            
        }
        static int QueDeseaHacer()
        {
            Console.WriteLine("*====Opciones====*");
            Console.WriteLine(1 + "-Agregar Combo");
            Console.WriteLine(2 + "-Finalizar   ");
            Console.WriteLine(3 + "-Cancelar");
            Console.Write(" Su Eleccion: ");
            int Eleccion = int.Parse(Console.ReadLine());
            return Eleccion;
        }
        static Combo MostrarCarta()
        {           
            int Cancelar = McDowellBase.Carta.Count;
            Console.Clear();
            Console.WriteLine("===Seleccion de combo===\n");
            int contador = 0;
            for (int i = 0; i < McDowellBase.Carta.Count; i++)
            {
                
                Console.WriteLine(i + " - " + McDowellBase.Carta[i].IDCombo + "| " + McDowellBase.Carta[i].PlatoPrincipal + "| "
                + McDowellBase.Carta[i].Acompañamiento + "| " + McDowellBase.Carta[i].Bebida + "| " + McDowellBase.Carta[i].Precio);
                contador ++;
            }
            Console.WriteLine($"{Cancelar} - CANCELAR: ");
            Console.WriteLine("Su Eleccion: ");
            int Eleccion = int.Parse(Console.ReadLine());
            if(Eleccion > contador | Eleccion < contador)
            {
                Console.Clear();
                //Console.WriteLine("!!!Ingreso un valor invalido!!!");
                //Console.ReadKey();
                MostrarCarta();
            }
            else if (Eleccion == Cancelar)
            {
                return null;
            }

            return McDowellBase.Carta[Eleccion];        
        }       

        static void MostrarInfoPedido(Pedido pedido)
        {
            Console.Clear();
            Console.WriteLine("=====Pedido=====");
            Console.WriteLine("Cliente: " + pedido.NombreCliente);
            if (pedido.EsParaLLevar == true )
            {
                Console.WriteLine("Para LLevar: Si" );
            }else if (pedido.EsParaLLevar == false)
            {
                Console.WriteLine("Para LLevar: No");
            }            
            Console.WriteLine("DETALLE: ");
            for (int i = 0; i < pedido.Detalle.Count; i++)
            {
            Console.WriteLine(i + " - "  + pedido.Detalle[i].IDCombo + " | " + pedido.Detalle[i].PlatoPrincipal + "| "+ pedido.Detalle[i].Acompañamiento + "| " + pedido.Detalle[i].Bebida + "| " + pedido.Detalle[i].Precio);
            }Console.WriteLine("\nTotal: $" + pedido.CalcularTotal());

            
        }
           
        static string PreguntarNombre()
        {          
            Console.WriteLine("Cual es tu nombre ?");
            string NombreCliente = Console.ReadLine();
            return NombreCliente;
        }

        static bool EsParaLLevar()
        {
            bool bandera = false;
            Console.Write("Para LLevar (S/N)?");
            string ParaLLevar = Console.ReadLine().ToUpper();        
            
            while (ParaLLevar != "S" && ParaLLevar != "N")
            {
                Console.Write("Para LLevar (S/N)?");
                ParaLLevar = Console.ReadLine().ToUpper();
            }
            if (ParaLLevar == "S")
            {
             bandera = true;
            }
            else if (ParaLLevar == "N")
            {
             bandera = false;
            }       
            return bandera;

        }
        public static void VerProximoPedido()
        {
            int i = McDowellBase.Pedidos.Count;
            if(i == 0)
            {
                Console.Clear();
                Console.WriteLine("Sin pedidos en Cola, Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else if (i != 0)
            {
                Pedido p = McDowellBase.Pedidos.Peek();
                MostrarInfoPedido(p);
            }           
        }
        static void PrepararProximoPedido()
        {
            int i = McDowellBase.Pedidos.Count;
            Console.Clear();
            if (i == 0)
            {
                Console.Clear();
                Console.WriteLine("No hay pedidos, Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            else if (i != 0)
            {
                Pedido p = McDowellBase.Pedidos.Dequeue();
                MostrarInfoPedido(p);
                Console.WriteLine("Pedido listo para entregar");
                Console.WriteLine("Presione una tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            

        }
        static void Main(string[] args)
        {
            McDowellBase.CargarCarta();
            MostrarPantallaPrincipal();

        }
    }
}
