using Microsoft.VisualStudio.TestTools.UnitTesting;
using VideoRent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.Data.SqlClient;
using VideoRent.Domain;

namespace VideoRent.Data.Tests
{
    [TestFixture]
    public class GeneroDataTest
    {

        private String connectionString;
        [SetUp]
        public void SetUp {
        //
        this.connectionString = "Data Source=AMENA\\SQLEXPRESS;Initial Catalog=videorent;User ID=lenguajes;Password=lenguajesparaiso2025;Encrypt=False;Trust Server Certificate=True";
        }


        [Test]
        public async Task GetGeneros()
        {
            //Assert

            using (var connection = new SqlConnection(this.connectionString))
            {
                await connection.OpenAsync();
                // Clean up existing test data
                using (var deleteCommand = new SqlCommand("DELETE FROM PeliculaActor", connection))
                {
                    await deleteCommand.ExecuteNonQueryAsync();
                }
                using (var deleteCommand = new SqlCommand("DELETE FROM Pelicula", connection))
                {
                    await deleteCommand.ExecuteNonQueryAsync();
                }
                using (var deleteCommand = new SqlCommand("DELETE FROM Genero", connection))
                {
                    await deleteCommand.ExecuteNonQueryAsync();
                }

                // Insert test data
                using (var insertCommand1 = new SqlCommand("INSERT INTO Genero (nombre_genero) VALUES ('Action'), ('Comedia')", connection))
                {
                    await insertCommand1.ExecuteNonQueryAsync();
                }
            }
            GeneroData generoData = new GeneroData(this.connectionString);
            //Act
            IEnumerable<Genero> generos = await generoData.GetGeneros();
            Assert.That(generos.Count(), Is.EqualTo(2));
        }


    }
}