using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Connectivity_SQL
{
    public class Regions
    {
        // MEMBUAT TABLE REGIONS
        public int Id { get; set; }
        public string Name { get; set; }


        // GETALL (SELECT)
        public List<Regions> GetAllRegion()
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
        public static int insertRegion(string name)
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
        public static List<Regions> GetRegionsById(int id)
        {
            var region = new List<Regions>();
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

        // UPDATE TABLE
        public static int UpdateRegionsName(int id, string newname)
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
        public static int DeleteRegionsName(int id)
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


        ////////////////////////VIEW MENU REGIONS///////////////////////////

        // VIEW MENU INSERT : REGIONS
        public void ViewMenuInsert()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tINSERT TO TABLE\t");
            Console.WriteLine("===================================");
            Console.Write("Add a new regions name :");
            string name = Console.ReadLine();
            int isInsertSuccessful = Regions.insertRegion(name);
            if (isInsertSuccessful > 0)
            {
                Console.WriteLine("Add Data Success");
            }
            else
            {
                Console.WriteLine("Add Data Invalid");
            }
            Console.ReadKey();
            /*ViewMenuRegions();*/
        }


        // VIEW MENU GETBY ID : REGIONS
        public void ViewMenuGetById()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tGET REGIONS BY ID\t");
            Console.WriteLine("===================================");
            Console.Write("Input region id :");
            int id = int.Parse(Console.ReadLine());
            List<Regions> regions = Regions.GetRegionsById(id);
            foreach (Regions region in regions)
            {
                Console.WriteLine($"Id: {region.Id} Name: {region.Name}");
            }
            Console.ReadKey();
           /* ViewMenuRegions();*/
        }


        // VIEW MENU UPDATE : REGIONS
        public void ViewMenuUpdate()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tUPDATE TABLE REGIONS\t");
            Console.WriteLine("===================================");
            Console.Write("Input region id :");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Add the name regions to be update :");
            string newname = Console.ReadLine();
            int isUpdateSuccessful = Regions.UpdateRegionsName(id, newname);
            if (isUpdateSuccessful > 0)
            {
                Console.WriteLine("Update Successful!");
            }
            else
            {
                Console.WriteLine("Update Failed");
            }
            Console.ReadKey();
           /* ViewMenuRegions();*/
        }


        // VIEW MENU DELETE : REGIONS
        public void ViewMenuDelete()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\tDELETE TABLE REGIONS\t ==");
            Console.WriteLine("===================================");
            Console.Write("Input a region id to delete :");
            int id = int.Parse(Console.ReadLine());
            int isDeleteSuccessful = Regions.DeleteRegionsName(id);
            if (isDeleteSuccessful > 0)
            {
                Console.WriteLine("Delete Successful!");
            }
            else
            {
                Console.WriteLine("Delete Failed");
            }
            Console.ReadKey();
            /*ViewMenuRegions();*/
        }

        // VIEW MENU GETALL : REGIONS
        public void ViewMenuRegions()
        {
            //GETALL : REGION (Select Tabel Regions)
            ViewMenu viewMenu = new ViewMenu();
            Console.Clear();
            Console.WriteLine("\tGET ALL REGIONS\t");
            Console.WriteLine("===================================");
            List<Regions> regions = GetAllRegion();
            foreach (Regions region in regions)
            {
                Console.WriteLine($"id: {region.Id} Name: {region.Name}");
            }

            Console.WriteLine("\n");
            Console.WriteLine("\tVIEW MENU REGIONS\t");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Insert Table");
            Console.WriteLine("2. Getby Id");
            Console.WriteLine("3. Update Table");
            Console.WriteLine("4. Delete Table");
            Console.WriteLine("5. Exit");
            Console.Write("Select a menu :");
            
            try
            {
                int inputMenuReg = Convert.ToInt32(Console.ReadLine());
                switch (inputMenuReg)
                {
                    case 1:
                        ViewMenuInsert();
                        ViewMenuRegions();
                        break;
                    case 2:
                        ViewMenuGetById();
                        ViewMenuRegions();
                        break;
                    case 3:
                        ViewMenuUpdate();
                        ViewMenuRegions();
                        break;
                    case 4:
                        ViewMenuDelete();
                        ViewMenuRegions();
                        break;
                    case 5:
                        viewMenu.View();
                        break;
                    default:
                        Console.WriteLine("Invalid choice, please try again...");
                        Console.ReadLine();
                        ViewMenuRegions();
                        break;
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("ERROR : Input Not Valid");
                Console.ReadKey();
                this.ViewMenuRegions();
            }
        }
    }
}
