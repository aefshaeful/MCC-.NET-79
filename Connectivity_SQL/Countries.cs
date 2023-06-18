using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connectivity_SQLQuery
{
    public class Countries
    {
        // Membuat Tabel Countries
        public string Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }


        //GETALL 
        public List<Countries> GetAllCountries()
        {
            List<Countries> countries = new List<Countries>();
            try
            {
                //Membuat instance untuk command
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_countries";

                //Membuat koneksi    
                Connection.connection.Open();

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var countr = new Countries();
                        countr.Id = reader.GetString(0);
                        countr.Name = reader.GetString(1);
                        countr.RegionId = reader.GetInt32(2);

                        countries.Add(countr);
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
            return countries;
        }


        // INSERT TABLE
        public static int insertCountries(string id, string name, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "Insert Into tb_m_countries (id, name, region_id) VALUES (@id, @name, @region_id)";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter cId = new SqlParameter();
                cId.ParameterName = "@id";
                cId.Value = id;
                cId.SqlDbType = SqlDbType.VarChar;

                SqlParameter cName = new SqlParameter();
                cName.ParameterName = "@name";
                cName.Value = name;
                cName.SqlDbType = SqlDbType.VarChar;

                SqlParameter cRegionId = new SqlParameter();
                cRegionId.ParameterName = "@region_id";
                cRegionId.Value = region_id;
                cRegionId.SqlDbType = SqlDbType.Int;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(cId);
                command.Parameters.Add(cName);
                command.Parameters.Add(cRegionId);

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
        public static List<Countries> GetCountriesById(string id)
        {
            var countries = new List<Countries>();
            try
            {
                // MEMBUAT KONEKSI      
                Connection.connection.Open();

                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "SELECT * from tb_m_countries WHERE id = @id";

                // MEMBUAT PARAMETER
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                paramId.SqlDbType = SqlDbType.VarChar;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(paramId);

                using SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var country = new Countries();
                        country.Id = reader.GetString(0);
                        country.Name = reader.GetString(1);
                        country.RegionId = reader.GetInt32(2);

                        countries.Add(country);
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
            return countries;
        }


        // UPDATE TABLE
        public static int UpdateCountriesName(string id, string newname, int region_id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "UPDATE tb_m_countries SET id = @id, name = @newname, region_id = @region_id WHERE id = @id";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter idparameter = new SqlParameter();
                idparameter.ParameterName = "@id";
                idparameter.Value = id;
                idparameter.SqlDbType = SqlDbType.VarChar;

                SqlParameter newName = new SqlParameter();
                newName.ParameterName = "@newname";
                newName.Value = newname;
                newName.SqlDbType = SqlDbType.VarChar;

                SqlParameter p_regionId = new SqlParameter();
                p_regionId.ParameterName = "@newname";
                p_regionId.Value = newname;
                p_regionId.SqlDbType = SqlDbType.Int;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(idparameter);
                command.Parameters.Add(newName);
                command.Parameters.Add(p_regionId);

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
        public static int DeleteCountriesName(string id)
        {
            int result = 0;
            Connection.connection.Open();

            SqlTransaction transaction = Connection.connection.BeginTransaction();
            try
            {
                // MEMBUAT INSTANCE UNTUK COMMAND 
                SqlCommand command = new SqlCommand();
                command.Connection = Connection.connection;
                command.CommandText = "DELETE tb_m_countries WHERE id = @id";
                command.Transaction = transaction;

                // MEMBUAT PARAMETER
                SqlParameter counId = new SqlParameter();
                counId.ParameterName = "@id";
                counId.Value = id;
                counId.SqlDbType = SqlDbType.VarChar;

                // MENAMBAHKAN PARAMETER DI COMMAND
                command.Parameters.Add(counId);

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


        ////////////////////////VIEW MENU COUNTRIES///////////////////////////
        
        // VIEW MENU INSERT : COUNTRIES
        public void ViewMenuInsert()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tINSERT TO TABLE\t");
            Console.WriteLine("===================================");
            Console.Write("Add a new countries id :");
            string id = Console.ReadLine();
            Console.Write("Add a new name countries :");
            string name = Console.ReadLine();
            Console.Write("Input region id :");
            int region_id = int.Parse(Console.ReadLine());
            int isInsertSuccessful = Countries.insertCountries(id, name, region_id);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Add Data Success");
            }
            else
            {
                Console.WriteLine("Add Data Invalid");
            }
            Console.ReadKey();
            /*ViewMenuCountries();*/
        }

        // VIEW MENU GETBY ID : COUNTRIES
        public void ViewMenuGetById()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tGet Countries by ID\t");
            Console.WriteLine("===================================");
            Console.Write("Input countries id :");
            string id = Console.ReadLine();
            List<Countries> count = Countries.GetCountriesById(id);
            foreach (Countries countries in count)
            {
                Console.WriteLine($"Id: {countries.Id}, Name: {countries.Name}, RegionId: {countries.RegionId}");
            }
            Console.ReadKey();
            /*ViewMenuCountries();*/
        }

        // VIEW MENU UPDATE
        public void ViewMenuUpdate()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tUPDATE TABLE COUNTRIES\t");
            Console.WriteLine("===================================");
            Console.Write("Input countries id :");
            string id = Console.ReadLine();
            Console.Write("Add new country name to update :");
            string newname = Console.ReadLine();
            Console.Write("Input region id: ");
            int region_id = int.Parse(Console.ReadLine());
            int isUpdateSuccessful = Countries.UpdateCountriesName(id, newname, region_id);
            if (isUpdateSuccessful > 0)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
            Console.ReadKey();
           /* ViewMenuCountries();*/
        }

        // VIEW MENU DELETE : COUNTRIES
        public void ViewMenuDelete()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tDELETE TABLE COUNTRIES\t");
            Console.WriteLine("===================================");
            Console.Write("Input a countries id to delete  :");
            string id = Console.ReadLine();
            int isDeleteSuccessful = Countries.DeleteCountriesName(id);
            if (isDeleteSuccessful > 0)
            {
                Console.WriteLine("Delete Successful!");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
            Console.ReadKey();
            /*ViewMenuCountries();*/
        }

        // VIEW MENU GETALL : COUNTRIES
        public void ViewMenuCountries()
        {
            //GETALL : COUNTRIES
            Console.Clear();
            Console.WriteLine("\tGET ALL COUNTRIES\t");
            Console.WriteLine("===================================");
            List<Countries> count = GetAllCountries();
            foreach (Countries countries in count)
            {
                Console.WriteLine($"Id: {countries.Id} Name: {countries.Name} RegionId: {countries.RegionId}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("\tVIEW MENU COUNTRIES\t");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Insert Table");
            Console.WriteLine("2. Getby Id");
            Console.WriteLine("3. Update Table");
            Console.WriteLine("4. Delete Table");
            Console.WriteLine("5. Exit");
            Console.Write("Select a menu :");
            int inputMenuCount = Convert.ToInt32(Console.ReadLine());
            try
            {
                switch (inputMenuCount)
                {
                    case 1:
                        ViewMenuInsert();
                        break;
                    case 2:
                        ViewMenuGetById();
                        break;
                    case 3:
                        ViewMenuUpdate();
                        break;
                    case 4:
                        ViewMenuDelete();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.ViewMenuCountries();
            }
        }
    }
}
