using SeleniumAutomation.Frameworks.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Automation.Data
{
    public class PropertyTaxReader
    {
        private string _databaseServer;
        private string _connectionString;

        public static string FIRST_NAME_COLUMN = "FIRST NAME";
        public static string LAST_NAME_COLUMN = "LAST NAME";
        public static string MAILING_STREET_COLUMN = "MAILING STREET";
        public static string MAILING_CITY_COLUMN = "MAILING CITY";
        public static string MAILING_STATE_COLUMN = "MAILING STATE";
        public static string MAILING_STATE_PROVINCE_COLUMN = "MAILing STATE/Province";
        public static string STREET_COLUMN = "street";
        public static string CITY_COLUMN = "CITY";
        public static string STATE_PROVINCE_COLUMN = "STATE/Province";
        public static string ZIP_POSTAL_CODE_COLUMN = "Zip/Postal Code";
        public static string YEAR_BUILT_COLUMN = "YR Built";
        public static string LEAD_STATUS_COLUMN = "LEAD STATUS";
        public static string LOT_SQUARE_FOOT_COLUMN = "LotSquareFoot";
        public static string LAST_SOLD_DATE_COLUMN = "LAST SOLD DATE";
        public static string CO_OWNER_NAME_COLUMN = "CO OWNER NAME";
        public static string ASSESSED_TOTAL_COLUMN = "ASSESSED TOTAL";
        public static string ASSESSED_STRUCTURE_COLUMN = "ASSESSED STRUCTURE";
        public static string ASSESSED_LAND_COLUMN = "Assessed Land";
        public static string ZONING_COLUMN = "ZONING";
        public static string COMPANY_COLUMN = "COMPANY";
        public static string PARCEL_COLUMN = "PARCEL ID";
        public static string LAND_USE_COLUMN = "LAND USE";
        public static string DADABASE_NAME = "PropertyTax_2;";


        public PropertyTaxReader(string databaseServer)
        {
            _databaseServer = databaseServer;
            _connectionString = "server=" + _databaseServer + ";" +
                                         "Trusted_Connection=yes;" +
                                         "database="+ DADABASE_NAME +
                                         "connection timeout=30";
        }

        public async static Task<bool> TestConnection(string databaseServer)
        {

           string connectionString = "server=" + databaseServer + ";" +
                                         "Trusted_Connection=yes;" +
                                "database=" + DADABASE_NAME +
                                         "connection timeout=30";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    await conn.OpenAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    conn.Dispose();
                    return false;
                }
            }
        }

        public  List<String> SelectRecord() 
        {
            List<String> taxIds = new List<String>();

            _connectionString = "server=" + _databaseServer + ";" +
                                         "Trusted_Connection=yes;" +
      "database=" + DADABASE_NAME +
                                         "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            SqlDataReader reader = null;

            using (var cmd = new SqlCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "TaxIds",
                Connection = myConnection
            })
            {

               reader = cmd.ExecuteReader();
            }

            while (reader.Read()) 
            {
                taxIds.Add(reader["TaxId"].ToString());
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return taxIds;
        
        }

        public List<String> SelectDelinquentRecords()
        {
            List<String> taxIds = new List<String>();

            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                      "database=" + DADABASE_NAME +
                                      "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            SqlDataReader reader = null;

            using (var cmd = new SqlCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "TaxIdsDelinquent",
                Connection = myConnection
            })
            {

                reader = cmd.ExecuteReader();
            }

            while (reader.Read())
            {
                taxIds.Add(reader["TaxId"].ToString());
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return taxIds;

        }

        public DataTable GetParcelNumbersByBatch(string batchId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            _connectionString = "server=" + _databaseServer + ";" +
                          "Trusted_Connection=yes;" +
                          "database=" + DADABASE_NAME +
                          "connection timeout=30";

            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                cmd.Connection = con; //database connection
                cmd.CommandText = "ListTaxParcelInformationFromBatch"; //  Stored procedure name
                cmd.CommandType = CommandType.StoredProcedure; // set it to stored proc
                                                               //add parameter if necessary
                cmd.Parameters.Add("@BatchId", SqlDbType.VarChar).Value = batchId;

                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public bool ExecuteQuery(string queryText)
        {
            _connectionString = "server=" + _databaseServer + ";" +
                          "Trusted_Connection=yes;" +
                          "database=" + DADABASE_NAME +
                          "connection timeout=30";
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(_connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        sqlConn.Open();
                        cmd.CommandText = queryText;
                        cmd.Connection = sqlConn;
                        cmd.ExecuteReader();
                        sqlConn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
                 return true;
        }


        public DataTable UpdateParcelNumbersByBatch(string batchId)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            _connectionString = "server=" + _databaseServer + ";" +
                          "Trusted_Connection=yes;" +
                          "database=" + DADABASE_NAME +
                          "connection timeout=30";

            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
               

            }
            catch (Exception ex)
            {

            }
            return dt;
        }

        public DataTable GetReciptsByTaxParcelInformationId(string id)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand();

            _connectionString = "server=" + _databaseServer + ";" +
                          "Trusted_Connection=yes;" +
                          "database=" + DADABASE_NAME +
                          "connection timeout=30";

            SqlConnection con = new SqlConnection(_connectionString);

            try
            {
                cmd.Connection = con; //database connection
                cmd.CommandText ="SELECT [Date]"
                                      +",[ReceiptNumber]"
                                      +",[Amount]"
                                      +" FROM[PropertyTax_2].[dbo].[Receipts]"
                                      + "where TaxParcelInformationId = " + id; 
                //  Stored procedure name
                cmd.CommandType = CommandType.Text; // set it to stored proc
                                                               //add parameter if necessary


                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dt);

            }
            catch (Exception ex)
            {

            }
            return dt;
        }


        public List<List<String>> DilinquentTaxIds()
        {
            List<String> taxIds = new List<String>();
            List<List<String>> rows = new List<List<String>>();

            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                      "database=" + DADABASE_NAME +
                                      "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            SqlDataReader reader = null;

            using (var cmd = new SqlCommand()
            {
                CommandType = System.Data.CommandType.Text,
                CommandText = "SELECT * FROM DilinquentTaxIds",
                Connection = myConnection
            })
            {

                reader = cmd.ExecuteReader();
            }

            while (reader.Read())
            {
                taxIds = new List<String>();
                taxIds.Add(reader[FIRST_NAME_COLUMN].ToString().Trim());
                taxIds.Add(reader[LAST_NAME_COLUMN].ToString().Trim());
                taxIds.Add(reader[MAILING_STREET_COLUMN].ToString().Trim());
                taxIds.Add(reader[MAILING_CITY_COLUMN].ToString().Trim());
                taxIds.Add(reader[MAILING_STATE_COLUMN].ToString().Trim());
                taxIds.Add(reader[MAILING_STATE_PROVINCE_COLUMN].ToString().Trim());
                taxIds.Add(reader[STREET_COLUMN].ToString().Trim());
                taxIds.Add(reader[CITY_COLUMN].ToString().Trim());
                taxIds.Add(reader[STATE_PROVINCE_COLUMN].ToString().Trim());
                taxIds.Add(reader[ZIP_POSTAL_CODE_COLUMN].ToString().Trim());
                taxIds.Add(reader[YEAR_BUILT_COLUMN].ToString().Trim());
                taxIds.Add(reader[LEAD_STATUS_COLUMN].ToString().Trim());
                taxIds.Add(reader[LOT_SQUARE_FOOT_COLUMN].ToString().Trim());
                taxIds.Add(reader[LAST_SOLD_DATE_COLUMN].ToString().Trim());
                taxIds.Add(reader[CO_OWNER_NAME_COLUMN].ToString().Trim());
                taxIds.Add(reader[ASSESSED_TOTAL_COLUMN].ToString().Trim());
                taxIds.Add(reader[ASSESSED_STRUCTURE_COLUMN].ToString().Trim());
                taxIds.Add(reader[ASSESSED_LAND_COLUMN].ToString().Trim());
                taxIds.Add(reader[ZONING_COLUMN].ToString().Trim());
                taxIds.Add(reader[COMPANY_COLUMN].ToString().Trim());
                taxIds.Add(reader[PARCEL_COLUMN].ToString().Trim());
                taxIds.Add(reader[LAND_USE_COLUMN].ToString().Trim());

                rows.Add(taxIds);
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return rows;

        }


        public bool UpdateRecord(Hashtable CurrentRow)
        {
            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                       "database=" + DADABASE_NAME +
                                      "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            using (var cmd = new SqlCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "iTaxParcelInformation",
                Connection = myConnection
            })
            {

                foreach (DictionaryEntry column in CurrentRow)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + column.Key, column.Value));
                }

                cmd.ExecuteNonQuery();
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return true;

        }


        public bool InsertRecord(string ParcelNumber)
        {
            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                       "database=" + DADABASE_NAME +
                                      "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            using (var cmd = new SqlCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "iParecelNumber",
                Connection = myConnection
            })
            {

             
                    cmd.Parameters.Add(new SqlParameter("@" + "TaxId", ParcelNumber));
             

                cmd.ExecuteNonQuery();
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return true;

        }

        public bool InsertDelinquentRecords(Hashtable CurrentRow)
        {
            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                      "database=" + DADABASE_NAME +
                                      "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            using (var cmd = new SqlCommand()
            {
                CommandType = System.Data.CommandType.StoredProcedure,
                CommandText = "iTaxParcelInformationReal",
                Connection = myConnection
            })
            {

                foreach (DictionaryEntry column in CurrentRow)
                {
                    cmd.Parameters.Add(new SqlParameter("@" + column.Key, column.Value));
                }

                cmd.ExecuteNonQuery();
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return true;
        }

        public SeattleTaxIdsCrawlerTotals TaxTotals()
        {
            DataSet ds = TaxTotalReader();

            return new SeattleTaxIdsCrawlerTotals()
            {
                TotalCrawled = ds.Tables[0].Rows[0]["TOTAL_CRAWLED"].ToString(),
                TotalUncrawled = ds.Tables[1].Rows[0]["TOTAL_UNCRAWLED"].ToString(),
                TotalErrorCrawled = ds.Tables[2].Rows[0]["TOTAL_ERRORS"].ToString()

            };

        }


        private DataSet TaxTotalReader()
        {
            List<String> taxIds = new List<String>();

            _connectionString = "server=" + _databaseServer + ";" +
                          "Trusted_Connection=yes;" +
                          "database=" + DADABASE_NAME +
                          "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            DataSet ds = new DataSet();

            using (SqlConnection c = new SqlConnection(_connectionString))
            {
                using (var adapter = new SqlDataAdapter("CrawlerTotals", c))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.Fill(ds);
                }

            }
            return ds;
        }

        public string DatabaseServer
        {
            set { _databaseServer = value; }
            get { return _databaseServer; }
        }

    }
}
