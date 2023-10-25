using WorkingWithBD;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // CollectionEntry

bool loggedIn = false;

// iniciar sesion
while (!loggedIn)
{
    Console.WriteLine("=== LogIn / SignUp ===");
    Console.WriteLine("1. Iniciar Sesion");
    Console.WriteLine("2. Registrarse");
    Console.Write("Tu opción: ");
    int option = Convert.ToInt32(Console.ReadLine());

    if (option == 1)
    {
        Console.Write("\nUsuario: ");
        string? username = Console.ReadLine();
        Console.Write("Contraseña: ");
        string? password = Console.ReadLine();

        string tipoUsuario = ObtenerTipoUsuario(username, password);

        if (!string.IsNullOrEmpty(tipoUsuario))
        {
            loggedIn = true;
            Console.WriteLine("¡Bienvenido, " + username + "!");

            if (tipoUsuario == "Estudiante")
            {
                Estu alumno = new Estu();
                alumno.MostrarOpciones();
            }
            else if (tipoUsuario == "Docente")
            {
                Doc docente = new Doc();
                docente.MostrarOpciones();
            }
            else if (tipoUsuario == "Almacenista")
            {
                Alma almacenista = new Alma();
                almacenista.MostrarOpciones();
            }
            else if (tipoUsuario == "Coordinador")
            {
                Coordinador coordinador = new Coordinador();
                do
                {
                    int opcion = coordinador.MostrarOpciones();
                    switch (opcion)
                    {
                        case 1:
                            WriteLine("OPCION 1");

                            break;

                        case 2:
                            Doc docente = new();
                            docente.Registrar();
                            break;

                        case 3:
                            Alma almacenista = new();
                            almacenista.Registrar();
                            WriteLine("OPCION 3");

                            break;

                        default:
                        WriteLine("Not an option");
                            break;
                    }
                } while(true);
            }
        }
        else
        {
            Console.WriteLine("Usuario o Contraseña Incorrectos \n");
        }

    }
    else if (option == 2)
    {
        Register();
    }
}


bool Login(string username, string password)
{
    using (Almacen db = new())
    {
        var Usuarios = db.Usuarios.Where(e => e.Usuario1.Equals(username)).Where(e => e.Password.Equals(password));

        if ((Usuarios is null) || !Usuarios.Any())
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}


void Register()
{
    Console.WriteLine("\n=== Registro ===");
    bool userExists;
    string? newUser;
    string? newPassword;
    long userId;

    do
    {
        userExists = false;

        Console.Write("Nuevo Usuario: ");
        newUser = Console.ReadLine();

        using (Almacen db = new())
        {
            var Usuarios = db.Usuarios.Where(e => e.Usuario1.Equals(newUser));

            if ((Usuarios is null) || !Usuarios.Any())
            {
                userExists = false;

            }
            else
            {
                userExists = true;
                Console.WriteLine("El usuario ya existe. Inténtalo con un nombre de usuario diferente.\n");
            }
        }
    } while (userExists);

    bool coincide;
    do
    {
        coincide = false;

        Console.Write("Contraseña: ");
        newPassword = Console.ReadLine();
        Console.Write("Repite la contraseña: ");
        string? verifyPassword = Console.ReadLine();

        if (newPassword != verifyPassword)
        {
            Console.WriteLine("Las contraseñas no coinciden\n");

        }
        else
        {
            coincide = true;
        }
    } while (!coincide);

    // Agregar al estudiante a la tabla Usuario con su Username y su contraseña
    using (Almacen db = new())
    {
        userId = db.Usuarios.Max(u => u.UsuarioId);
        db.Usuarios.Add(new Usuario { UsuarioId = userId + 1, Usuario1 = newUser, Password = newPassword });
        db.SaveChanges();
    }

    Console.WriteLine("\nRegistro de usuario exitoso. Ahora puedes iniciar sesión con tu nuevo usuario.\n");

    Console.WriteLine(" - - - Ahora ingresa la siguiente informacion - - -");
    Console.Write("Ingresa tu Registro: ");
    int id = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingresa tu Nombre: ");
    string? name = ReadLine();
    Console.Write("Ingresa tu Apellido Paterno: ");
    string? firstName = ReadLine();
    Console.Write("Ingresa tu Apellido Materno: ");
    string? LastName = ReadLine();
    Console.Write("Ingresa tu Semestre: ");
    int semesterId = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("1: A1 - 2: B1 - 3: C1 - 4: D1 - 5: E1 - 6: F1 - 7: G1 - 8: H1 - 9: I1 - 10: J1 - 11: K1 - 12: L1 - 13: M1 - 14: N1 - 15: O1 - 16: P1 - 17: Q1 - 18: R1 - 19: S1 - 20: T1 - 21: U1 - 22: V1 - 23: W1 - 24: X1 - 25: Y1 - 26: Z1");
    Console.Write("Ingresa tu Grupo: ");
    int groupId = Convert.ToInt32(Console.ReadLine());
    Console.Write("Ingresa tu Adeudo: ");
    decimal adeudo = Convert.ToDecimal(Console.ReadLine());
    Console.Write("Ingresa tu Correo: ");
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

    // Agregar al Estudiante a la tabla estudiante con toda su informacion
    using (Almacen db = new())
    {
        db.Estudiantes.Add(new Estudiante { EstudianteId = id, Nombre = name, ApellidoPaterno = firstName, ApellidoMaterno = LastName, SemestreId = semesterId, GrupoId = groupId, Adeudo = adeudo, Correo = correo, PlantelId = plantelId, UsuarioId = userId });
        db.SaveChanges();
    }
}


string ObtenerTipoUsuario(string username, string password)
{
    using (Almacen db = new())
    {
        var query = from usuario in db.Usuarios
                    where usuario.Usuario1 == username && usuario.Password == password
                    select new
                    {
                        TipoEstudiante = db.Estudiantes.Any(e => e.UsuarioId == usuario.UsuarioId),
                        TipoDocente = db.Docentes.Any(e => e.UsuarioId == usuario.UsuarioId),
                        TipoAlmacenista = db.Almacenista.Any(e => e.UsuarioId == usuario.UsuarioId),
                        TipoCoordinador = db.Coordinadors.Any(e => e.UsuarioId == usuario.UsuarioId)
                    };

        var result = query.FirstOrDefault();

        if (result != null)
        {
            if (result.TipoEstudiante) return "Estudiante";
            if (result.TipoDocente) return "Docente";
            if (result.TipoAlmacenista) return "Almacenista";
            if (result.TipoCoordinador) return "Coordinador";
        }

        return string.Empty;
    }
}


public class Usuarios
{
    public virtual void MostrarOpciones()
    {
        Console.WriteLine("\n=== Usuario ===");
        Console.WriteLine("1. Editar Perfil");
        Console.WriteLine("2. Darse de baja");
    }
}

public class Estu : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("3. Generar vale");
    }
}

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

public class Alma : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("3. Crud de equipos");
        Console.WriteLine("4. Reporte");
    }
    public void Registrar()
    {
        Console.WriteLine("\n=== Registro ===");

        long userId;
        long almacenistaId;

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

        // Agregar al almacenista a la tabla Usuario con su Username y su contraseña
        using (Almacen db = new())
        {
            userId = db.Usuarios.Max(u => u.UsuarioId);
            db.Usuarios.Add(new Usuario { UsuarioId = userId + 1, Usuario1 = name, Password = name });
            db.SaveChanges();
        }

        // Agregar al Almacenista a la tabla estudiante con toda su informacion
        using (Almacen db = new())
        {
            almacenistaId = db.Almacenista.Max(d => d.AlmacenistaId);
            db.Almacenista.Add(new Almacenistum { AlmacenistaId = almacenistaId + 1, Nombre = name, ApellidoMaterno = firstName, ApellidoPaterno = lastName, Correo = correo, PlantelId = plantelId, UsuarioId = userId });
            db.SaveChanges();
        }

    }
}

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