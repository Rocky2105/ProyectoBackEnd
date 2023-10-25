namespace Usuarios;
public class Usuarios
{
    public virtual void MostrarOpciones()
    {
        Console.WriteLine("\n=== Usuario ===");
        Console.WriteLine("1. Editar Perfil");
        Console.WriteLine("2. Darse de baja");
    }
}