﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Refactoring_MVC.Contexts;
using System.Data;

namespace Refactoring_MVC.Models
{
    public class Regions
    {
        public int Id { get; set; }
        public string Name { get; set; }


        // GETALL (SELECT)
        public List<Regions> GetAll()
        {
            var region = new List<Regions>();
            //List<Regions> region = new List<Regions>();
            try
            {

                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_regions";

                // MEMBUAT KONEKSI    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var reg = new Regions();
                        reg.Id = reader.GetInt32(0);
                        reg.Name = reader.GetString(1);

                        region.Add(reg);
                    }
                }
                else
                {
                    Console.WriteLine("Data Not Found!!");
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.connection.Close();
            return region;
        }

        // INSERT TABLE
        public int insert(string name)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "Insert Into tb_m_regions (name) VALUES (@region_name)";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@region_name";
                pName.Value = name;
                pName.SqlDbType = SqlDbType.VarChar;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(pName);

                // MENJALANKAN COMMAND
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            Connection.connection.Close();
            return result;
        }

        // GETBY ID
        public Regions GetById(int id)
        {
            var reg = new Regions();
            try
            {
                // MEMBUAT KONEKSI      
                Connection.connection.Open();

                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_regions WHERE id = @id";

                // MEMBUAT PARAMETER
                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.Value = id;
                pId.SqlDbType = SqlDbType.Int;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(pId);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    reg.Id = reader.GetInt32(0);
                    reg.Name = reader.GetString(1);
                }
                else
                {
                    reg = new Regions();
                    /*Console.WriteLine("Data Not Found!!");*/
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Connection.connection.Close();
            return reg;
        }

        // UPDATE TABLE
        public int Update(int id, string newname)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "UPDATE tb_m_regions SET name = @newname WHERE id = @id";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter parId = new SqlParameter();
                parId.ParameterName = "@id";
                parId.Value = id;
                parId.SqlDbType = SqlDbType.Int;

                SqlParameter parNewName = new SqlParameter();
                parNewName.ParameterName = "@newname";
                parNewName.Value = newname;
                parNewName.SqlDbType = SqlDbType.VarChar;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(parId);
                command.Parameters.Add(parNewName);

                // MENJALANKAN COMMAND
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            Connection.connection.Close();
            return result;
        }

        // DELETE TABLE
        public int Delete(int id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "DELETE tb_m_regions WHERE id = @id";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter parameterId = new SqlParameter();
                parameterId.ParameterName = "@id";
                parameterId.Value = id;
                parameterId.SqlDbType = SqlDbType.Int;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(parameterId);

                // MENJALANKAN COMMAND
                result = command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    transaction.Rollback();
                }
                catch (Exception rollback)
                {
                    Console.WriteLine(rollback.Message);
                }
            }
            Connection.connection.Close();
            return result;
        }
    }
}