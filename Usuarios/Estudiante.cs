namespace Usuarios;
using WorkingWithBD;

public class Estu : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("3. Generar vale");
    }
}