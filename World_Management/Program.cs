using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace World_Management
{
    public class Item
    {
        public int id { get; set; }
        public string name { get; set; }
        public int base_cost { get; set; }
        public float weight { get; set; }
        public string rarity { get; set; }
        public string type { get; set; }

    }

    public class Building
    {
        public int id { get; set; }
        public string name { get; set; }
        public int isShop { get; set; } 
    }

    public class BuildingToItem
    {
        public int id { get; set; }
        public int id_building { get; set; }
        public int id_item { get; set; }
    }

    public class ConnectDB
    {
        private string _connectionString;

        public ConnectDB(IConfiguration configuration)
        {
            _connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=DnD_World_db;Integrated Security=True";
        }

        public List<Item> GetItems()
        {
            var items = new List<Item>();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetItems", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    items.Add(new Item
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString(),
                        base_cost = Convert.ToInt32(read[2]),
                        weight = Convert.ToSingle(read[3]),
                        rarity = read[4].ToString(),
                        type = read[5].ToString()
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return items;
        }

        public void AddItem(Item item)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("AddItem", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = item.name;
                cmd.Parameters.Add("@base_cost", SqlDbType.Int).Value = item.base_cost;
                cmd.Parameters.Add("@weight", SqlDbType.Float).Value = item.weight;
                cmd.Parameters.Add("@rarity", SqlDbType.VarChar, 100).Value = item.rarity;
                cmd.Parameters.Add("@type", SqlDbType.VarChar, 100).Value = item.type;
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        public List<Building> GetBuildings()
        {
            var buildings = new List<Building>();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetBuildings", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    buildings.Add(new Building
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString(),
                        isShop = Convert.ToInt32(read[2])
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return buildings;
        }

        public void AddBuilding(Building building)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("AddBuilding", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.VarChar, 100).Value = building.name;
                cmd.Parameters.Add("@isShop", SqlDbType.Int).Value = building.isShop;
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    
        public void AddBuildingToItem(BuildingToItem buildingToItem)
        {
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("AddBuildingToItem", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id_building", SqlDbType.Int).Value = buildingToItem.id_building;
                cmd.Parameters.Add("@id_item", SqlDbType.Int).Value = buildingToItem.id_item;
                con.Open();
                cmd.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        private static IConfiguration configuration1;

        [STAThread]
        static void Main()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true);

            configuration1 = builder.Build();
            ConnectDB db = new ConnectDB(configuration1);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var main = new MainForm();
            Application.Run(main);
        }
    }
}