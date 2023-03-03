
using Npgsql;

namespace ConsoleApp.Repository
{
    public class FactoryRepository : IBaseRepository<Factory>
    {
        public void Create(Factory facility)
        {
            try
            {
                using(var connection = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    connection.Open();
                    string sqlCommand = @"INSERT INTO factory (""Id"", ""Name"", ""Description"") VALUES (@id, @name, @description)";
                    using (var cmd = new NpgsqlCommand(sqlCommand, connection))
                    {
                        cmd.Parameters.AddWithValue("id", facility.Id);
                        cmd.Parameters.AddWithValue("name", facility.Name!);
                        cmd.Parameters.AddWithValue("description", facility.Description!);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

        public void Delete(int id)
        {
            try
            {
                using(var connection = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    connection.Open();
                    string sqlCommand = @"DELETE FROM factory WHERE ""Id""=@id";
                    using (var cmd = new NpgsqlCommand(sqlCommand, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

        public Factory Get(int id)
        {
            try 
            {
                using(var connection = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    connection.Open();
                    string sqlCommand = @"SELECT * FROM factory WHERE ""Id""=@id";
                    using (var cmd = new NpgsqlCommand(sqlCommand, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                Factory factory = ReadFactory(reader);
                                return factory;
                            }
                        }
                    }
                }
                return new Factory();
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return new Factory();
            }
        }

        public List<Factory> GetAll() 
        { 
            try 
            {
                using(var connection = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    connection.Open();

                    string sqlCommand = "SELECT * FROM factory";

                    using (var cmd = new NpgsqlCommand(sqlCommand, connection))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            var factories = new List<Factory>();
                            while (reader.Read())
                            {
                                factories.Add(ReadFactory(reader));
                            }
                            return factories;
                        }
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return new List<Factory>();
            }
        }

        public void Update(int id, Factory facility)
        {
            var sqlCommand = @"UPDATE factory
                SET ""Name""=@name, ""Description""=@description
                WHERE ""Id""=@id";

            try
            {
                using (var connection = new NpgsqlConnection(DbConnection.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new NpgsqlCommand(sqlCommand, connection))
                    {
                        cmd.Parameters.AddWithValue("id", id);
                        cmd.Parameters.AddWithValue("name", facility.Name!);
                        cmd.Parameters.AddWithValue("description", facility.Description!);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }

        private Factory ReadFactory(NpgsqlDataReader reader)
        {
            int? id = (int)reader[@"Id"];
            string? name = (string)reader[@"Name"];
            string? description = (string)reader[@"Description"];

            var factory = new Factory
            {
                Id = id.Value,
                Name = name,
                Description = description
            };
            return factory;
        }
    }
}