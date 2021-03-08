using arbolsiempre.clases.ArbolBinario;
using arbolsiempre.clases.Insertar;
using System;
using System.Collections.Generic;
using System.Text;

namespace arbolsiempre.clases.JuegoAnimal
{
    class AdivinaAnimal
    {
        private static Nodo raiz;

        private InsertarArbol nodosb;

        public AdivinaAnimal()
        {
            raiz = new Nodo("Elefante");
         
        }


        
        public void jugar()
        {
            Nodo nodo = raiz;
            List<InsertarArbol> Arb = new InsertarArbol().cargatodoslosnodos();

            nodosb = Arb.Find(x => x.animal.Contains(""));

            Nodo nodo1 = new Nodo(nodosb.animal);
            Nodo nodo2 = new Nodo(nodosb.pregunta);
            nodo.izquierda = nodo2;
            nodo.derecha = nodo1;

            while (nodo != null) //iteracion del arbol
            {
                
                if (nodo.izquierda != null) //existe una pregunta
                {

                    Console.WriteLine(nodo.valorNodo());
                    nodo = (respuesta()) ? nodo.izquierda : nodo.derecha;
                }
                else
                {
                    Console.WriteLine($"Ya se, es un {nodo.valorNodo()}");
                    if (respuesta())
                    {
                        Console.WriteLine("Gane!!!!   :)");
                    }
                    else
                    {
                        animalNuevo(nodo);
                    }

                    nodo = null;
                    return;
                }// fin if
            }// fin while
        }// fin jugar

        public bool respuesta()
        {

            while (true)
            {
                String resp = Console.ReadLine().ToLower().Trim();
                if (resp.Equals("si")) return true;
                if (resp.Equals("no")) return false;
                Console.WriteLine("La respuesta debe ser SI o NO");
            }
            
        }//fin de respuesta

        private void animalNuevo(Nodo nodo)
        {
            InsertarArbol lo = new InsertarArbol();

            String animalNodo = (String)nodo.valorNodo();
            Console.WriteLine("Cual es tu animal pues?");
            String nuevoA = Console.ReadLine();
            Console.WriteLine($"Que pregunta con respuesta si / no puedo hacer para poder decir que es un {nuevoA}");
            string pregunta = Console.ReadLine();
            Nodo nodo1 = new Nodo(animalNodo);
            Nodo nodo2 = new Nodo(nuevoA);
            //lo.animal = nuevoA;
            //lo.pregunta = animalNodo;
            //lo.guardarArbol(lo);
            Console.WriteLine($"Para un(a) {nuevoA} la respuesta es si / no ?");
            nodo.nuevoValor(pregunta + "?");


            
            if (respuesta())
            {
                
                nodo.izquierda = nodo2;
                nodo.derecha = nodo1;
                lo.animal = nuevoA;
                lo.pregunta = pregunta;
                lo.guardarArbol(lo);

            }
            else
            {
                nodo.izquierda = nodo1;
                nodo.derecha = nodo2;
                lo.animal = pregunta;
                lo.pregunta = nuevoA;
                lo.guardarArbol(lo);
            }

        }

    }
}
