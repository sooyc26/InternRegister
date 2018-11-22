using InternRegister.Models.InternsModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace InternRegister.Services
{
    public class InternService
    {
        readonly string connString = ConfigurationManager.ConnectionStrings["Default"].ConnectionString;


        public int Create(InternCreateRequest request)
        {
            int id = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Interns_Insert";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("FirstName", request.FirstName);
                cmd.Parameters.AddWithValue("LastName", request.LastName);
                cmd.Parameters.AddWithValue("Email", request.Email);
                cmd.Parameters.AddWithValue("Password", request.Password);
                cmd.Parameters.AddWithValue("PhoneNumber", request.PhoneNumber);
                cmd.Parameters.AddWithValue("Sponsorship", request.Sponsorship);
                cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        id = (int)reader["Id"];
                    }
                    reader.Close();
                }
                conn.Close();
            }
            return id;
        }

        public List<Intern> ReadAll()
        {
            var interns = new List<Intern>();

            using (var conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Interns_Select_All";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var intern = new Intern()
                        {
                            Id = (int)reader["Id"],
                            FirstName = (string)reader["FirstName"],
                            LastName = (string)reader["LastName"],
                            Email = (string)reader["Email"],
                            Password = (string)reader["Password"],
                            PhoneNumber = (string)reader["PhoneNumber"],
                            Sponsorship = (bool)reader["Sponsorship"],
                            DateCreated = (DateTime)reader["DateCreated"],
                            DateModified = (DateTime)reader["DateModified"]

                        };
                        interns.Add(intern);
                    }
                    conn.Close();
                }
            }
            return interns;
        }

        public Intern ReadById(int id)
        {
            var returnIntern = new Intern();

            using(SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "Interns_Select_ById";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Id", id);

                using (SqlRea)
            }
        }

    }
}