using System;

public class Program
{
    public static void Main(string[] args)
    {
        ListaEnlazada lista = new ListaEnlazada();

   
        lista.Agregar(10);
        lista.Agregar(20);
        lista.Agregar(30);


        lista.Imprimir();


        lista.Buscar(20);


        lista.Modificar(20, 25);


        lista.Imprimir();


        lista.Eliminar(10);


        lista.Imprimir();
    }
}

public class Nodo
{
    public int Valor { get; set; }
    public Nodo? Siguiente { get; set; }

    public Nodo(int valor)
    {
        Valor = valor;
        Siguiente = null;
    }
}

public class ListaEnlazada
{
    private Nodo? cabeza;

    public ListaEnlazada()
    {
        cabeza = null;
    }


    public void Agregar(int valor)
    {
        Nodo nuevoNodo = new Nodo(valor);
        if (cabeza == null)
        {
            cabeza = nuevoNodo;
        }
        else
        {
            Nodo actual = cabeza;
            while (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }
            actual.Siguiente = nuevoNodo;
        }
        Console.WriteLine($"Elemento {valor} agregado.");
    }


    public void Eliminar(int valor)
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        if (cabeza.Valor == valor)
        {
            cabeza = cabeza.Siguiente;
            Console.WriteLine($"Elemento {valor} eliminado.");
            return;
        }

        Nodo actual = cabeza;
        while (actual.Siguiente != null && actual.Siguiente.Valor != valor)
        {
            actual = actual.Siguiente;
        }

        if (actual.Siguiente == null)
        {
            Console.WriteLine($"Elemento {valor} no encontrado.");
        }
        else
        {
            actual.Siguiente = actual.Siguiente.Siguiente;
            Console.WriteLine($"Elemento {valor} eliminado.");
        }
    }


    public bool Buscar(int valor)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor == valor)
            {
                Console.WriteLine($"Elemento {valor} encontrado.");
                return true;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Elemento {valor} no encontrado.");
        return false;
    }

    public void Modificar(int valorAntiguo, int valorNuevo)
    {
        Nodo actual = cabeza;
        while (actual != null)
        {
            if (actual.Valor == valorAntiguo)
            {
                actual.Valor = valorNuevo;
                Console.WriteLine($"Elemento {valorAntiguo} modificado a {valorNuevo}.");
                return;
            }
            actual = actual.Siguiente;
        }
        Console.WriteLine($"Elemento {valorAntiguo} no encontrado.");
    }


    public void Imprimir()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = cabeza;
        Console.WriteLine("Elementos de la lista:");
        while (actual != null)
        {
            Console.WriteLine(actual.Valor);
            actual = actual.Siguiente;
        }
    }
}