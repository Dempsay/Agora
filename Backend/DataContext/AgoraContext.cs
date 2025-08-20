using Microsoft.EntityFrameworkCore;
using Service.Models;

namespace Backend.DataContext
{
    public class AgoraContext: DbContext
    {
        public DbSet<TipoInscripcion> TipoInscripciones { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<TipoInscripcionCapacitacion> TiposInscripcionesCapacitacion { get; set; }
        public DbSet<Inscripcion> Inscripciones { get; set; }
        public AgoraContext(){ }
        public AgoraContext(DbContextOptions<AgoraContext> options) : base(options) 
        { 
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Cargamos los datos iniciales de TipoInscripcion (publico en general, Docentes, Estudiantes, Jubilados.)
            modelBuilder.Entity<TipoInscripcion>().HasData(
                new TipoInscripcion { Id = 1, Nombre = "Público en general" },
                new TipoInscripcion { Id = 2, Nombre = "Docentes" },
                new TipoInscripcion { Id = 3, Nombre = "Estudiantes" },
                new TipoInscripcion { Id = 4, Nombre = "Jubilados" }
            );

            //Cargamos los datos iniciales de Usuario (admin, user)
            modelBuilder.Entity<Usuario>().HasData(
                new Usuario { Id = 1, Nombre = "Administrador", Email = "admin@gmail.com", Password = "admin123",
                    TipoUsuario = Service.Enums.TipoUsuarioEnum.Administrador },
                new Usuario { Id = 2, Nombre = "Usuario", Email = "", Password = "user123",
                    TipoUsuario = Service.Enums.TipoUsuarioEnum.Estudiante });

            //Cargamos los datos iniciales de Capacitacion
            modelBuilder.Entity<Capacitacion>().HasData(
                new Capacitacion
                {
                    Id = 1,
                    Nombre = "Capacitación en C#",
                    Detalle = "Aprende los fundamentos de C#",
                    Ponente = "Juan Pérez",
                    FechaHora = new DateTime(2023, 10, 15, 10, 0, 0),
                    Cupo = 30,
                    InscripcionAbierta = true,
                    IsDeleted = false
                },
                new Capacitacion
                {
                    Id = 2,
                    Nombre = "Capacitación en ASP.NET Core",
                    Detalle = "Desarrollo web con ASP.NET Core",
                    Ponente = "María López",
                    FechaHora = new DateTime(2023, 10, 20, 14, 0, 0),
                    Cupo = 25,
                    InscripcionAbierta = true,
                    IsDeleted = false
                }
            );
            //Cargamos los datos iniciales de TipoInscripcionCapacitacion y sus costos
            modelBuilder.Entity<TipoInscripcionCapacitacion>().HasData(
                new TipoInscripcionCapacitacion { Id = 1, CapacitacionId = 1, TipoInscripcionId = 1, Costo = 10000 },
                new TipoInscripcionCapacitacion { Id = 2, CapacitacionId = 1, TipoInscripcionId = 2, Costo = 8000 },
                new TipoInscripcionCapacitacion { Id = 3, CapacitacionId = 1, TipoInscripcionId = 3, Costo = 5000 },
                new TipoInscripcionCapacitacion { Id = 4, CapacitacionId = 1, TipoInscripcionId = 4, Costo = 3000 }
            );
            // cargamos los datos iniciales de inscripciones
            modelBuilder.Entity<Inscripcion>().HasData(
                new Inscripcion { Id = 1, Apellido = "Gómez", Nombre = "Carlos", Dni = "12345678", Email = "carlos.gomez@gmail.com", TipoInscripcionId = 1, CapacitacionId = 1, Acreditado = false, Importe = 10000, Pagado = false },
                new Inscripcion { Id = 2, Apellido = "Martínez", Nombre = "Ana", Dni = "87654321", Email = "ana.martinez@gmail.com", TipoInscripcionId = 2, CapacitacionId = 1, Acreditado = false, Importe = 5000, Pagado = false },
                new Inscripcion { Id = 3, Apellido = "Pérez", Nombre = "Juan", Dni = "11223344", Email = "juan.perez@gmail.com", TipoInscripcionId = 3, CapacitacionId = 2, Acreditado = false, Importe = 4000, Pagado = false },
                new Inscripcion { Id = 4, Apellido = "Lopez", Nombre = "Maria", Dni = "44332211", Email = "maria.lopez@gmail.com", TipoInscripcionId = 4, CapacitacionId = 2, Acreditado = false, Importe = 3000, Pagado = false },
                new Inscripcion { Id = 5, Apellido = "Fernandez", Nombre = "Luis", Dni = "55667788", Email = "luis.fernandez@gmail.com", TipoInscripcionId = 1, CapacitacionId = 2, Acreditado = false, Importe = 12000, Pagado = false }
            );

            modelBuilder.Entity<TipoInscripcion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Usuario>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Capacitacion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<TipoInscripcionCapacitacion>().HasQueryFilter(p => !p.IsDeleted);
            modelBuilder.Entity<Inscripcion>().HasQueryFilter(p => !p.IsDeleted);

        }
    }
}
