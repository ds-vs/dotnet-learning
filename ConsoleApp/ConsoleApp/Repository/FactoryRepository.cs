
using Npgsql;

namespace ConsoleApp.Repository
{
    public class FactoryRepository : IBaseRepository<Factory>
    {
        public void Create(Factory facility)
        {
            using(var connection = new NpgsqlConnection(DbConnection.GetConnectionString()))
            {
                connection.Open();
                string commandText = @"INSERT INTO factory (""Id"", ""Name"", ""Description"") VALUES (@id, @name, @description)";
                using (var cmd = new NpgsqlCommand(commandText, connection))
                {
                    cmd.Parameters.AddWithValue("id", facility.Id);
                    cmd.Parameters.AddWithValue("name", facility.Name!);
                    cmd.Parameters.AddWithValue("description", facility.Description!);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Factory Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Factory facility)
        {
            throw new NotImplementedException();
        }
    }
}