using frossi.Models;
using Microsoft.EntityFrameworkCore;

namespace frossi.Data
{
    public class Seeding
    {
        public static class ModelSeeding
        {
            public static void SeedAllModels(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<Users>().HasData(
                    new Users
                    {
                        IdUser = 1,
                        Nombre = "FabioLo",
                        Email = "fabio_d_rossi@hotmail.com",
                        Password = "3276a0d74a9f4ca3f3959825dcba457d19e1f9340aa404abbcde25af2fb3b272"
                    }
                );
                modelBuilder.Entity<Solicitantes>().HasData(
                   new Solicitantes
                   {
                       Id = 1,
                       IdTipoDoc = 1,
                       NroDoc = "20514866",
                       Nombres = "Diego Armando",
                       Apellido="Rossi"
                    },
                    new Solicitantes
                    {
                        Id = 2,
                        IdTipoDoc = 1,
                        NroDoc = "20514877",
                        Nombres = "Rafaela",
                        Apellido = "Carra"
                    }
                );
                modelBuilder.Entity<TiposExamenes>().HasData(
                   new TiposExamenes
                   {
                       Id = 1,
                       Nombre = "Motocicletas",
                   },
                   new TiposExamenes
                   {
                       Id = 2,
                       Nombre = "Automóviles",
                   },
                   new TiposExamenes
                   {
                       Id = 3,
                       Nombre = "Profesional",
                   }
                );
                modelBuilder.Entity<TiposDoc>().HasData(
                    new TiposDoc
                    {
                        Id = 1,
                        Nombre = "DNI",
                        Descri = "Documento Nacional de Identidad",
                    },
                    new TiposDoc
                    {
                        Id = 2,
                        Nombre = "LC",
                        Descri = "Libreta Cívica",
                    },
                    new TiposDoc
                    {
                        Id = 3,
                        Nombre = "PA",
                        Descri = "Pasaporte",
                    }
                );
                modelBuilder.Entity<ExaPreguntas>().HasData(
                    new ExaPreguntas
                    {
                       Id = 1,
                       IdTipoExamen = 1,
                       Texto = "¿Cuál es la función principal de los cinturones de seguridad en un vehículo?",
                       PathImagen = "",
                       RtaCorrecta=1
                    },
                    new ExaPreguntas
                    {
                        Id = 2,
                        IdTipoExamen = 1,
                        Texto = "¿Qué significa una luz amarilla intermitente en un semáforo?",
                        PathImagen = "",
                        RtaCorrecta = 3
                    },
                    new ExaPreguntas
                    {
                        Id = 3,
                        IdTipoExamen = 1,
                        Texto = "¿Cuál es la distancia de seguimiento recomendada para mantener en condiciones de lluvia o niebla?",
                        PathImagen = "",
                        RtaCorrecta = 1
                    }
                );
                modelBuilder.Entity<ExaOpciones>().HasData(
                    new ExaOpciones
                    {
                        Id = 1,
                        IdPregunta = 1,
                        Orden = 1,
                        TextoOpcion = "Reducir el riesgo de lesiones en caso de accidente."
                    },
                    new ExaOpciones
                    {
                        Id = 2,
                        IdPregunta = 1,
                        Orden = 2,
                        TextoOpcion = "Mantener el vehículo en una velocidad segura."
                    },
                    new ExaOpciones
                    {
                        Id = 3,
                        IdPregunta = 1,
                        Orden = 3,
                        TextoOpcion = "Mejorar la eficiencia del combustible."
                    },
                    new ExaOpciones
                    {
                        Id = 4,
                        IdPregunta = 2,
                        Orden = 1,
                        TextoOpcion = "Prepararse para detenerse."
                    },
                    new ExaOpciones
                    {
                        Id = 5,
                        IdPregunta = 2,
                        Orden = 2,
                        TextoOpcion = "Acelerar para cruzar antes de que cambie a rojo."
                    },
                    new ExaOpciones
                    {
                        Id = 6,
                        IdPregunta = 2,
                        Orden = 3,
                        TextoOpcion = "Pasar con precaución si es seguro hacerlo."
                    },
                    new ExaOpciones
                    {
                        Id = 7,
                        IdPregunta = 3,
                        Orden = 1,
                        TextoOpcion = "Doble la distancia habitual."
                    },
                    new ExaOpciones
                    {
                        Id = 8,
                        IdPregunta = 3,
                        Orden = 2,
                        TextoOpcion = "Mantener la misma distancia que en condiciones normales."
                    },
                    new ExaOpciones
                    {
                        Id = 9,
                        IdPregunta = 3,
                        Orden = 3,
                        TextoOpcion = "Reducir la distancia a la mitad para tener una mejor visibilidad."
                    }
                );
            }
        }
    }
}
