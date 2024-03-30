using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Task_Api.Entity;
using Task_Api.ServiceInterface;

namespace Task_Api.Repository
{
    public class City: ICity
    {


        ////============================== for SQL CONNECT ========================////
        private readonly IConfiguration _iconfiguration;
        public City(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        ////============================== for SQL CONNECT ========================////
        public async Task<long> CitySave(CityEntity cityEntity)
        {
            SqlConnection conn = new SqlConnection(_iconfiguration.GetConnectionString("DBConnectionstring").ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ACD_INSERT_UPDATE_CITY", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", cityEntity.ID);
            cmd.Parameters.AddWithValue("@CITY_NAME", cityEntity.CITY_NAME);
            cmd.Parameters.AddWithValue("@ACTIVE", cityEntity.ACTIVE);
            int ret = cmd.ExecuteNonQuery();
            conn.Close();
            return ret;
        }

    }
}
