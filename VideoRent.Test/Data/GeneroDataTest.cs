namespace VideoRent.Test.Data;
using global::VideoRent.Data;
using Microsoft.Data.SqlClient;
using NUnit.Framework;
using System;
using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text;
using System.Threading.Tasks;
using VideoRentSolution.VideoRent;
using VideoRentSolution.VideoRent.Domain;

[TestFixture]
    public class GeneroDataTest
    {

        private String connectionString;
        [SetUp]
        public void SetUp()
        {
        //
        this.connectionString = "Data Source=163.178.173.130,1433\\SQLEXPRESS;Initial Catalog=VideoRent_C4H457_II2026;User ID=lenguajes;Password=lenguajesparaiso2025;Encrypt=False;Trust Server Certificate=True";
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
