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
        public int cityTypeId { get; set; }
    }

    public class BuildingToItem
    {
        public int id { get; set; }
        public int id_building { get; set; }
        public int id_item { get; set; }
    }

    public class State
    {
        public int id { get; set; }
        public string name { get; set; }
        public string form { get; set; }
        public int area { get; set; }
        public int population { get; set; }
    }

    public class Province
    {
        public int id { get; set; }
        public string name { get; set; }
        public int state { get; set; }
        public string form { get; set; }
        public int area { get; set; }
        public int population { get; set; }
    }

    public class Settlement
    {
        public int id { get; set; }
        public string name { get; set; }
        public int isCapital { get; set; }
        public int population { get; set; }
        public int cityType { get; set; }
        public int province { get; set; }
        public int state { get; set; }
    }
    public class CityType
    {
        public int id { get; set; }
        public string name { get; set; }
        public int minPopulation { get; set; }
        public int maxPopulation { get; set; }
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
                        name = read[1].ToString().Trim(),
                        base_cost = Convert.ToInt32(read[2]),
                        weight = Convert.ToSingle(read[3]),
                        rarity = read[4].ToString().Trim(),
                        type = read[5].ToString().Trim()
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
                        name = read[1].ToString().Trim(),
                        isShop = Convert.ToInt32(read[2]),
                        cityTypeId = Convert.ToInt32(read[3])
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
                cmd.Parameters.Add("@cityTypeId", SqlDbType.Int).Value = building.cityTypeId;
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

        public List<State> GetStates()
        {
            var states = new List<State>();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetStates", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    states.Add(new State
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString().Trim(),
                        form = read[2].ToString().Trim(),
                        area = Convert.ToInt32(read[3]),
                        population = Convert.ToInt32(read[4])
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return states;
        }

        public List<Province> GetProvincesOfStates(int state_id)
        {
            var provinces = new List<Province>();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetProvinceOfState", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = state_id;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    provinces.Add(new Province
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString().Trim(),
                        state = Convert.ToInt32(read[2]),
                        form = read[3].ToString().Trim(),
                        area = Convert.ToInt32(read[4]),
                        population = Convert.ToInt32(read[5])
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return provinces;
        }

        public State GetStateById(int state_id)
        {
            State state = new State();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetStateById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = state_id;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    state = new State
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString().Trim(),
                        form = read[2].ToString().Trim(),
                        area = Convert.ToInt32(read[3]),
                        population = Convert.ToInt32(read[4])
                    };
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return state;
        }

        public List<Settlement> GetSettlementsOfProvinces(int province_id)
        {
            var settlements = new List<Settlement>();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetSettlementOfProvince", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = province_id;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    settlements.Add(new Settlement
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString().Trim(),
                        isCapital = Convert.ToInt32(read[2]),
                        population = Convert.ToInt32(read[3]),
                        cityType = Convert.ToInt32(read[4]),
                        province = Convert.ToInt32(read[5]),
                        state = Convert.ToInt32(read[6])
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return settlements;
        }

        public Province GetProvinceById(int province_id)
        {
            Province province = new Province();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetProvinceById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = province_id;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    province = new Province
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString().Trim(),
                        state = Convert.ToInt32(read[2]),
                        form = read[3].ToString().Trim(),
                        area = Convert.ToInt32(read[4]),
                        population = Convert.ToInt32(read[5])
                    };
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return province;
        }

        public List<CityType> GetCityTypes()
        {
            List<CityType> cityTypes = new List<CityType>();
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetCityTypes", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    var test = read[3];
                    cityTypes.Add(new CityType
                    {
                        id = Convert.ToInt32(read[0]),
                        name = read[1].ToString().Trim(),
                        minPopulation = Convert.ToInt32(read[2]),
                        maxPopulation = read[3].ToString().Count() == 0 ? int.MaxValue : Convert.ToInt32(read[3])
                    });
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cityTypes;
        }

        public string GetCityTypeById(int cityType_id)
        {
            string cityType = "";
            try
            {
                using var con = new SqlConnection(_connectionString);
                SqlCommand cmd = new SqlCommand("GetCityTypeById", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = cityType_id;
                con.Open();
                SqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    cityType = read[1].ToString().Trim();
                }
                con.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return cityType;
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