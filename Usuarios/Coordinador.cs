namespace Usuarios;
using WorkingWithBD;
public class Coordinador
{
    public int MostrarOpciones()
    {
        Console.WriteLine("1. Resetear Coordinador");
        Console.WriteLine("2. Crear Nuevo Docente");
        Console.WriteLine("3. Crear Nuevo Almacenista");
        Write("Ingresa tu opcion: ");
        int opcion = Convert.ToInt32(ReadLine());
        return opcion;
    }

}