using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RegionType
    {
        public bool Create(Model.RegionType region, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_create_RegionType";
                comand.Parameters.Add(new SqlParameter("idRegion", region.IdRegion));
                comand.Parameters.Add(new SqlParameter("idCapacityType", region.IdCapacityType));
                comand.Parameters.Add(new SqlParameter("Cost", region.Cost));

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

        public bool Update(Model.RegionType region, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_update_RegionType";
                comand.Parameters.Add(new SqlParameter("idRegion", region.IdRegion));
                comand.Parameters.Add(new SqlParameter("idCapacityType", region.IdCapacityType));
                comand.Parameters.Add(new SqlParameter("Cost", region.Cost));

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

        public bool Delete(Model.RegionType region, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_delete_RegionType";
                comand.Parameters.Add(new SqlParameter("idRegion", region.IdRegion));
                comand.Parameters.Add(new SqlParameter("idCapacityType", region.IdCapacityType));

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

        public List<Model.RegionType> Get(string cnn, String where = "")
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            List<Model.RegionType> regions = new List<Model.RegionType>();
            try
            {
                string sql = "SELECT rt.idRegion, rt.idCapacityType, rt.Cost, r.RegionName, tc.CapacityName " +
                    "FROM RegionType AS rt INNER JOIN Region AS r ON rt.idRegion = r.idRegion " +
                    "INNER JOIN TipoCapacidad AS tc ON rt.idCapacityType = tc.idTipoCapacidad ";

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
                    regions.Add(
                        new Model.RegionType(Convert.ToInt32(dr["idRegion"]), Convert.ToInt32(dr["idCapacityType"]), float.Parse(dr["Cost"].ToString()),
                                            Convert.ToString(dr["RegionName"]), Convert.ToString(dr["CapacityName"])){ });
                }

            }
            catch (Exception e)
            {
                return new List<Model.RegionType>(); ;
            }
            finally
            {
                sqlConnection.Close();
            }

            return regions;
        }
    }
}
