using Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class CapacityType
    {

        public bool Create(Model.CapacityType capacityType, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_create_TipoCapacidad";
                comand.Parameters.Add(new SqlParameter("CapacityName", capacityType.NameCapacityType));
                comand.Parameters.Add(new SqlParameter("QuantityUnits", capacityType.QuantityUnits));

                sqlConnection.Open();

                comand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }

        public bool Update(Model.CapacityType capacityType, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_update_TipoCapacidad";
                comand.Parameters.Add(new SqlParameter("CapacityName", capacityType.NameCapacityType));
                comand.Parameters.Add(new SqlParameter("QuantityUnits", capacityType.QuantityUnits));
                comand.Parameters.Add(new SqlParameter("idTipoCapacidad", capacityType.IdCapacityType));

                sqlConnection.Open();

                comand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }

        public bool Delete(Model.CapacityType capacityType, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_delete_TipoCapacidad";
                comand.Parameters.Add(new SqlParameter("idTipoCapacidad", capacityType.IdCapacityType));

                sqlConnection.Open();

                comand.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }

            return true;
        }

        public List<Model.CapacityType> Get(string cnn, String where = "")
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            List<Model.CapacityType> capacityTypes = new List<Model.CapacityType>();
            try
            {
                string sql = "select idTipoCapacidad, CapacityName, QuantityUnits from TipoCapacidad ";

                if (where != "")
                {
                    sql += where;
                }

                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.Text;
                comand.CommandText = sql;


                sqlConnection.Open();

                SqlDataReader dr = comand.ExecuteReader();

                while (dr.Read())
                {
                    capacityTypes.Add(new Model.CapacityType(Convert.ToInt32(dr["idTipoCapacidad"]), Convert.ToString(dr["CapacityName"]),Convert.ToInt32(dr["QuantityUnits"])) { });
                }

            }
            catch (Exception e)
            {
                return new List<Model.CapacityType>(); ;
            }
            finally
            {
                sqlConnection.Close();
            }

            return capacityTypes;
        }


        public int countCapatyType(string cnn, int id)
        {
            int cuenta = 0;
            SqlConnection sqlConnection = new SqlConnection(cnn);

            try
            {
               SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.Text;
                comand.CommandText = "select count(*) from RegionType where idCapacityType = " + id.ToString();


                sqlConnection.Open();

                cuenta = Convert.ToInt32(comand.ExecuteScalar());


            }
            catch (Exception e)
            {
                return 0;
            }
            finally
            {
                sqlConnection.Close();
            }

            return cuenta;
        }
    }
}
