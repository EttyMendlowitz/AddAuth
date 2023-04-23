using System.Data.SqlClient;
namespace _419Homework.Models

{
    public class ListingManager
    {
        private string _connectionString = @"Data Source=.\sqlexpress;Initial Catalog=RandomDatabase; Integrated Security=true;";


        public void AddNewListing(int id, Listing l)
        {
            using var connection = new SqlConnection(_connectionString);
            using var cmd = connection.CreateCommand();


            cmd.CommandText = "INSERT INTO Listings VALUES (@dateCreated, @description, @name, @phoneNumber, @UserId)";
            cmd.Parameters.AddWithValue("@dateCreated", l.DateCreated);
            cmd.Parameters.AddWithValue("@description", l.Text);
            cmd.Parameters.AddWithValue("@name", l.UserName);
            cmd.Parameters.AddWithValue("@phoneNumber", l.PhoneNumber);
            cmd.Parameters.AddWithValue("@userId", id);
            connection.Open();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "DELETE FROM Listings " +
                                    "WHERE Id = @id";
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();

        }

        public List<Listing> GetListings()
        {
            using SqlConnection connection = new SqlConnection(_connectionString);
            using SqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT l.*, u.Name FROM  Listings l " +
                "JOIN Users u " +
                "ON l.UserId = u.Id ";

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Listing> listings = new List<Listing>();
            while (reader.Read())
            {
                listings.Add(new Listing
                {
                    Id = (int)reader["Id"],
                    DateCreated = (DateTime)reader["DateCreated"],
                    Text = (string)reader["Description"],
                    UserName = (string)reader["Name"],
                    PhoneNumber = (int)reader["PhoneNumber"]


                });
            }
            return listings;

        }
    }
}
