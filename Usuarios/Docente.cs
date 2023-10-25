namespace Usuarios;
using WorkingWithBD;
public class Doc : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("3. Autorizar pedidos (lista)");
    }
    public void Registrar()
    {
        Console.WriteLine("\n=== Registro ===");

        long userId;
        long docenteId;

        Console.WriteLine(" - - - Ahora ingresa la siguiente informacion - - -");
        Console.Write("Ingresa el Nombre: ");
        string? name = ReadLine();
        Console.Write("Ingresa el Apellido Paterno: ");
        string? firstName = ReadLine();
        Console.Write("Ingresa el Apellido Materno: ");
        string? lastName = ReadLine();
        Console.Write("Ingresa el Correo: ");
        string? correo = ReadLine();
        Console.WriteLine("1: Colomos - 2: Tonalá - 3: Rio Santiago");
        Console.Write("Ingresa tu Plantel: ");
        long plantelId = Convert.ToInt32(ReadLine());

        bool PlantelExists = false;

        // hacer una consulta para saber si existe el plantel
        using (Almacen db = new())
        {
            var Planteles = db.Plantels.Where(p => p.PlantelId.Equals(plantelId));

            if ((Planteles is null) || !Planteles.Any())
            {
                PlantelExists = false;

            }
            else
            {
                foreach (Plantel p in Planteles)
                {
                    plantelId = p.PlantelId;
                }
            }
        }

        // Agregar al docente a la tabla Usuario con su Username y su contraseña
        using (Almacen db = new())
        {
            userId = db.Usuarios.Max(u => u.UsuarioId);

            db.Usuarios.Add(new Usuario { UsuarioId = userId + 1, Usuario1 = name, Password = name });
            db.SaveChanges();
        }

        // Agregar al Docente a la tabla estudiante con toda su informacion
        using (Almacen db = new())
        {
            docenteId = db.Docentes.Max(d => d.DocenteId);
            db.Docentes.Add(new Docente { DocenteId = docenteId + 1, Nombre = name, ApellidoMaterno = firstName, ApellidoPaterno = lastName, Correo = correo, PlantelId = plantelId, UsuarioId = userId });
            db.SaveChanges();
        }

    }
}