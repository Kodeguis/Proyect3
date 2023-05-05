using System;
using System.Drawing;

namespace grafos_s12{
    class Program{
        static void Main(){
            Console.WriteLine("Grafos");
            int n,a;
            int datoNodo,origen,destino;
            Console.WriteLine("Ingrese cant. de nodos:");
            n=int.Parse(Console.ReadLine());
            Nodo grafo = null;
            for (int i = 0; i < n; i++) {
                Console.WriteLine("Nombre Nodo:");
                datoNodo = int.Parse(Console.ReadLine());
                grafo = InsertarNodo(grafo, datoNodo);
            }
            Console.WriteLine("Ingrese cant. aristas:");
            a = int.Parse(Console.ReadLine());
            Arista aristaAux;
            for (int i = 0; i < a; i++) {
                Console.WriteLine("Ingrese arista(" + (i + 1) + "): ");
                Console.WriteLine("Ingrese origen: ");
                origen = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese destino: ");
                destino = int.Parse(Console.ReadLine());
                aristaAux = InsertarArista(grafo, origen, destino);
                Nodo nodoOrigen = ObtenerNodo(grafo, origen);
                nodoOrigen.ady = aristaAux;
            }
            MostrarGrafo(grafo);
        }

        static Arista InsertarArista(Nodo grafo, int origen, int destino){
            Arista aristaAux = null;
            Arista nuevaArista = new Arista();
            Arista ultimaArista = new Arista();
            Nodo nodoOrigen = new Nodo();
            Nodo nodoDestino = new Nodo();
            nodoOrigen = ObtenerNodo(grafo, origen);
            if (nodoOrigen != null){
                nodoDestino= ObtenerNodo(grafo, destino);
                if (nodoDestino != null) {
                    if (ObtenerArista(nodoOrigen,nodoDestino)==null){
                        nuevaArista.sig = null;
                        nuevaArista.destino = nodoDestino;
                        if (nodoOrigen.ady == null){
                            nodoOrigen.ady=nuevaArista;
                        }
                        else{
                            ultimaArista = nodoOrigen.ady;
                            while (ultimaArista.sig != null) {
                                ultimaArista=ultimaArista.sig;;
                            }
                            ultimaArista.sig=nuevaArista;
                        }
                    }
                }
            }
            return aristaAux;
        }
        static Arista ObtenerArista(Nodo origen, Nodo destino) { 
            Arista arista= origen.ady;
            while (arista != null && arista.destino != destino){
                arista = arista.sig;
            }
            return arista;
        }

        static Nodo ObtenerNodo(Nodo grafo, int valor){
            Nodo auxNodo = grafo;
            while (auxNodo != null && auxNodo.dato!=valor) {
                auxNodo = auxNodo.sig;
            }
            return auxNodo;
        }
        static Nodo InsertarNodo(Nodo grafo, int valor){
            Nodo nuevoNodo = new Nodo();
            Nodo nodoUltimo = new Nodo();
            if (ObtenerNodo(grafo, valor) == null){
                nuevoNodo.dato= valor;
                nuevoNodo.sig = null;
                nuevoNodo.ady = null;
                if (grafo == null){
                    grafo = nuevoNodo;
                }else{
                    nodoUltimo = grafo;
                    while (nodoUltimo.sig != null){
                        nodoUltimo = nodoUltimo.sig;
                    }
                    nodoUltimo.sig = nuevoNodo;
                }
            }

            return grafo;
        }
        static void MostrarGrafo(Nodo grafo){
            Nodo nodoAux = grafo;
            while (nodoAux != null){
                Console.Write(nodoAux.dato);
                Arista aristaAux=nodoAux.ady;

                while (aristaAux != null){
                    Console.Write("-->");
                    Console.Write(aristaAux.destino.dato+" ");
                    aristaAux = aristaAux.sig;
                }
                nodoAux = nodoAux.sig;
                Console.WriteLine("");
            }

    
        }
        static void InicializarNodos(Nodo grafo) {
            Nodo nodoActual = grafo;
            while (nodoActual != null) {
            //nodoActual.pred = null;
            //nodoActual.distanciaFuente = int.MaxValue;
            //nodoActual.visitado = false;
            nodoActual = nodoActual.sig;
            }
        }

        //static void Djikstra(Nodo grafo, int origen)
        //{
        //    Nodo nodoOrigen = ObtenerNodo(grafo, origen);
        //    Nodo nodoMinimo, nodoDestino;
        //    Arista adyacente, aristaActual;

        //    InicializarNodos(grafo);

        //    if(nodoOrigen != null){
        //        nodoOrigen.distanciaFuente = 0;
        //        while(nodoMinimo = ObtenerMinimo(grafo))
        //        {
        //            nodoMinimo.visitado = true;
        //            adyacente = nodoMinimo.ady;
        //            aristaActual = adyacente;

        //            while(aristaActual != null)
        //            {
        //                nodoDestino = aristaActual.destino;

        //                if(nodoDestino.distanciaFuente > nodoMinimo.distanciaFuente + aristaActual.distancia)
        //                {
        //                    nodoDestino.distanciaFuente = nodoMinimo.distanciaFuente + aristaActual.distancia);
        //                    nodoDestino.pred = nodoMinimo;
        //                }

        //                aristaActual = aristaActual.sig;
        //            }
        //        }
        //    }
        //}
    }
}