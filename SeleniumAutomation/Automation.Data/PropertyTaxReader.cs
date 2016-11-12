using System;
using System.Collections;
using System.Collections.Generic;
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
        
        public PropertyTaxReader(string databaseServer)
        {
            _databaseServer = databaseServer;
            _connectionString = "server=" + _databaseServer + ";" +
                                         "Trusted_Connection=yes;" +
                                         "database=PropertyTax; " +
                                         "connection timeout=30";
        } 

        public  List<String> SelectRecord() 
        {
            List<String> taxIds = new List<String>();

            _connectionString = "server=" + _databaseServer + ";" +
                                         "Trusted_Connection=yes;" +
                                         "database=PropertyTax; " +
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
                                      "database=PropertyTax; " +
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


        public List<List<String>> DilinquentTaxIds()
        {
            List<String> taxIds = new List<String>();
            List<List<String>> rows = new List<List<String>>();

            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                      "database=PropertyTax; " +
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

        //           private const string FIRST_NAME_COLUMN = "FIRST NAME";
        //private const string LAST_NAME_COLUMN = "LAST NAME";
        //private const string MAILING_STREET_COLUMN = "MAILING STREET";
        //private const string MAILING_CITY_COLUMN = "MAILING CITY";
        //private const string MAILING_STATE_COLUMN = "MAILING STATE";
        //private const string MAILING_STATE_PROVINCE_COLUMN = "MAILing STATE/Province";
        //private const string STREET_COLUMN = "street";
        //private const string CITY_COLUMN = "CITY";
        //private const string STATE_PROVINCE_COLUMN = "STATE/Province";
        //private const string ZIP_POSTAL_CODE_COLUMN = "Zip/Postal Code";
        //private const string YEAR_BUILT_COLUMN = "YR Built";
        //private const string LEAD_STATUS_COLUMN = "LEAD STATUS";
        //private const string LOT_SQUARE_FOOT_COLUMN = "LotSquareFoot";
        //private const string LAST_SOLD_DATE_COLUMN = "LAST SOLD DATE";
        //private const string CO_OWNER_NAME_COLUMN = "CO OWNER NAME";
        //private const string ASSESSED_TOTAL_COLUMN = "ASSESSED TOTAL";
        //private const string ASSESSED_STRUCTURE_COLUMN = "ASSESSED STRUCTURE";
        //private const string ASSESSED_LAND_COLUMN = "Assessed Land";
        //private const string ZONING_COLUMN = "ZONING";
        //private const string COMPANY_COLUMN = "COMPANY";
        //private const string PARCEL_COLUMN = "PARCEL ID";
        //private const string LAND_USE_COLUMN = "LAND USE";

        rows.Add(taxIds);
            }

            myConnection.Close();
            myConnection.Dispose();
            GC.Collect();

            return rows;

        }

        public bool InsertRecord(Hashtable CurrentRow)
        {
            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                      "database=PropertyTax; " +
                                      "connection timeout=30";

            SqlConnection myConnection = new SqlConnection(_connectionString);

            myConnection.Open();

            using (var cmd = new SqlCommand() { CommandType = System.Data.CommandType.StoredProcedure,
                                                CommandText = "iTaxParcelInformation",
                                                Connection = myConnection })
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

        public bool InsertDelinquentRecords(Hashtable CurrentRow)
        {
            _connectionString = "server=" + _databaseServer + ";" +
                                      "Trusted_Connection=yes;" +
                                      "database=PropertyTax; " +
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

        public string DatabaseServer
        {
            set { _databaseServer = value; }
            get { return _databaseServer; }
        }

    }
}
