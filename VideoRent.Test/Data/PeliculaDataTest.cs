using System;
using System.Collections.Generic;
using System.Text;
using VideoRent.Data;
using VideoRentSolution.VideoRent.Domain;

namespace VideoRent.Test.Data
{
    public class PeliculaDataTest
    {
        private String connectionString;

        [SetUp]
        public void Setup()
        {
            //connectionString = ConfigurationManager.ConnectionStrings["VideoConnection"].ConnectionString.ToString();
            this.connectionString = "Data Source=163.178.173.130,1433\\SQLEXPRESS;Initial Catalog=VideoRent_C4H457_II2026;User ID=lenguajes;Password=lenguajesparaiso2025;Encrypt=False;Trust Server Certificate=True";
        }

        [Test]
        public void Insertar_ValidPelicula_InsertsSuccessfully()
        {
            // Arrange
            var peliculaData = new PeliculaData(this.connectionString);

            // Datos de prueba
            var genero = new Genero { GeneroId = 1005, NombreGenero = "Action" }; // Usar un GeneroId existente en b.d. de pruebas
            var actor1 = new Actor { ActorId = 5, NombreActor = "Keanu", ApellidosActor = "Reeve" };
            var peliculaToInsert = new Pelicula
            {
                Titulo = "matrix 1",
                Subtitulada = true,
                Estreno = false,
                Genero = genero,
                Actores = new List<Actor> { actor1 }
            };

            // Act
            Assert.DoesNotThrow(() => peliculaData.Insertar(peliculaToInsert),
                "Insertar una pelicula no debería generar una exepción");
            Assert.That(peliculaToInsert.PeliculaId, Is.GreaterThan(0));
        }

        [Test]
        public async Task GetPeliculasPorTitulo_ReturnValues()
        {
            // 1. Arrange: Asegurarnos de que el dato existe antes de buscarlo
            var peliculaData = new PeliculaData(this.connectionString);

            var peliculaToInsert = new Pelicula
            {
                Titulo = "matrix",
                Subtitulada = true,
                Estreno = false,
                // tengo solo 1005 y 1006
                Genero = new Genero { GeneroId = 1005, NombreGenero = "Action" },
                Actores = new List<Actor> { new Actor { ActorId = 6, NombreActor = "Keanu", ApellidosActor = "Reeve" } }
            };

            // Insertamos la película para garantizar que hay al menos una con "mat"
            peliculaData.Insertar(peliculaToInsert);

            // 2. Act: Ejecutamos el método que queremos probar
            List<Pelicula> peliculas = await peliculaData.GetPeliculasPorTitulo("matrix");

            // 3. Assert: Verificamos el resultado
            Assert.That(peliculas.Count, Is.GreaterThan(0));
        }
    }
}
