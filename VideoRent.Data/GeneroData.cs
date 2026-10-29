using Microsoft.Data.SqlClient;
using VideoRent.Domain;

namespace VideoRent.Data

{
    public class GeneroData
    {
        //SE CREA UN OBJETO CONEXION IMPORTANTE
        private readonly String connectionString;
        public GeneroData(String connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<IEnumerable<Genero>> GetGeneros()
        {
            var generos = new List<Genero>();
            using (var connection = new SqlConnection(this.connectionString))
            {
                await connection.OpenAsync();
                using (var command = new SqlConnection("select genero_id, nombre_genero from Genero", connection))
                {
                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var genero = new Genero
                            {
                                GeneroId = reader.GetInt32(0),
                                NombreGenero = reader.GetInt32(1)
                            };
                            generos.Add(genero);
                        }

                    }
                }
               
            }
            return generos;
        } //GetGeneros
    }
}


        
 
