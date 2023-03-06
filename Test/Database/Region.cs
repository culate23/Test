using Model;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace Database
{
    public class Region
    {
        public bool Create(Model.Region region, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_create_region";
                comand.Parameters.Add(new SqlParameter("RegionName", region.RegionName));

                sqlConnection.Open();

                comand.ExecuteNonQuery();
                
            }
            catch(Exception e)
            {
                return false;
            }
            finally
            {
                sqlConnection.Close();
            }
         
            return true;
        }

        public bool Update(Model.Region region, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_update_region";
                comand.Parameters.Add(new SqlParameter("RegionName", region.RegionName));
                comand.Parameters.Add(new SqlParameter("IdRegion", region.IdRegion));

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

        public bool Delete(Model.Region region, string cnn)
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.StoredProcedure;
                comand.CommandText = "SP_delete_region";
                comand.Parameters.Add(new SqlParameter("IdRegion", region.IdRegion));

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

        public List<Model.Region> Get(string cnn, String where = "")
        {
            SqlConnection sqlConnection = new SqlConnection(cnn);
            List<Model.Region> regions = new List<Model.Region>();
            try
            {
                string sql = "select idRegion, RegionName from Region ";

                if(where != "")
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
                    regions.Add(new Model.Region(Convert.ToInt32(dr["IdRegion"]), Convert.ToString(dr["RegionName"])) {});
                }

            }
            catch (Exception e)
            {
                return new List<Model.Region>(); ;
            }
            finally
            {
                sqlConnection.Close();
            }

            return regions;
        }

        public int countRegion(string cnn)
        {
            int cuenta = 0;
            SqlConnection sqlConnection = new SqlConnection(cnn);

            try
            {
                SqlCommand comand = new SqlCommand();
                comand.Connection = sqlConnection;
                comand.CommandType = System.Data.CommandType.Text;
                comand.CommandText = "select count(*) from Region";


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