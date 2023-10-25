using WorkingWithBD;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking; // CollectionEntry

bool loggedIn = false;


// Iniciar sesión
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
Console.WriteLine(" ¡Bienvenido, " + username + "!");

if (tipoUsuario == "Estudiante")
{
Estudiante alumno = new Estudiante();
alumno.MostrarOpciones();
}
else if (tipoUsuario == "Docente")
{
Docente docente = new Docente();
docente.MostrarOpciones();
}
else if (tipoUsuario == "Almacenista")
{
Almacenista almacenista = new Almacenista();
almacenista.MostrarOpciones();
}
else if (tipoUsuario == "Coordinador")
{
Coordinador coordinador = new Coordinador();
coordinador.MostrarOpciones();
}
}
else
{
Console.WriteLine("Usuario o Contraseña Incorrectos \n");
}

}
else if (option == 2)
{
// Registro
}
}


bool Login(string username, string password)
{

using (Almacen db = new())
{

var Usuarios = db.Usuarios
.Where(e => e.Usuario1.Equals(username)).Where(e => e.Password.Equals(password));

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

string ObtenerTipoUsuario(string username, string password)
{
using (Almacen db = new Almacen())
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

public class Estudiante : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("3. Generar vale");
    }
}

public class Docente : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("4. Autorizar pedidos (lista)");
    }
}

public class Almacenista : Usuarios
{
    public override void MostrarOpciones()
    {
        base.MostrarOpciones();
        Console.WriteLine("4. Crud de equipos");
        Console.WriteLine("5. Reporte");
    }
}

public class Coordinador : Usuarios
{
    public override void MostrarOpciones()
    {
        Console.WriteLine("1. Resetear Coordinador");
        Console.WriteLine("2. Crear Nuevo Docente");
        Console.WriteLine("3. Crear Nuevo Almacenista");
    }
}