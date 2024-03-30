using Microsoft.Extensions.Configuration;
using System.Data;
using Task_Api.Entity;
using Task_Api.ServiceInterface;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace Task_Api.Repository
{
    public class Employee : IEmployee
    {

        ////============================== for SQL CONNECT ========================////
        private readonly IConfiguration _iconfiguration;
        public Employee(IConfiguration configuration)
        {
            _iconfiguration = configuration;
        }
        ////============================== for SQL CONNECT ========================////

        public async Task<long> EmployeeSave(EmployeeEntity employeeEntity)
        {
            SqlConnection conn = new SqlConnection(_iconfiguration.GetConnectionString("DBConnectionstring").ToString());
            conn.Open();
            SqlCommand cmd = new SqlCommand("ACD_INSERT_UPDATE_EMPLOYEE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EMP_ID", employeeEntity.EMP_ID);
            cmd.Parameters.AddWithValue("@EMP_NAME", employeeEntity.EMP_NAME);
            cmd.Parameters.AddWithValue("@EMP_AGE", employeeEntity.EMP_AGE);
            cmd.Parameters.AddWithValue("@EMP_CITY", employeeEntity.EMP_CITY);
            int ret = cmd.ExecuteNonQuery();
            conn.Close();
            return ret;
        }

        public async Task<List<EmployeeEntity>> GetEmployeeList()
        {
            SqlConnection conn = new SqlConnection(_iconfiguration.GetConnectionString("DBConnectionstring").ToString());
            conn.Open();
            DataSet ds = new DataSet();
            List<EmployeeEntity> employeeEntity = new List<EmployeeEntity>();
            SqlCommand cmd = new SqlCommand("ACD_GET_ALL_EMPLOYEE", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CAMMAND_TYPE", "GET_ALL_EMPLOYEE");
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    employeeEntity.Add(new EmployeeEntity
                    {
                        EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString()),
                        EMP_NAME = dr["EMP_NAME"].ToString(),
                        EMP_AGE = Convert.ToInt32(dr["EMP_AGE"].ToString()),
                        EMP_CITY = dr["EMP_CITY"].ToString()
                    });
                }
            }
            return employeeEntity;
        }

        public async Task<EmployeeEntity> GetEmployeeById(int empid)
        {
            try
            {
                SqlConnection conn = new SqlConnection(_iconfiguration.GetConnectionString("DBConnectionstring").ToString());
                conn.Open();
                EmployeeEntity employeeEntity = new EmployeeEntity();
                SqlCommand cmd = new SqlCommand("ACD_GET_ALL_EMPLOYEE", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@CAMMAND_TYPE", "GET_DATA_BY_ID");
                cmd.Parameters.AddWithValue("@EMP_ID", empid);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    if (dr != null)
                    {
                        employeeEntity.EMP_ID = Convert.ToInt32(dr["EMP_ID"].ToString());
                        employeeEntity.EMP_NAME = dr["EMP_NAME"].ToString();
                        employeeEntity.EMP_AGE = Convert.ToInt32(dr["EMP_AGE"].ToString());
                        employeeEntity.EMP_CITY = dr["EMP_CITY"].ToString();
                    }
                }
                conn.Close();
                return employeeEntity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



    }
}
