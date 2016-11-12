using SeleniumAutomation.Automation.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumAutomation.Automation.Record.Utilities
{
    public class OutputFile
    {
        public  static string DelinquientCSVContent(List<List<String>> content)
        {

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(PropertyTaxReader.FIRST_NAME_COLUMN + "," +
                          PropertyTaxReader.LAST_NAME_COLUMN + "," + 
                          PropertyTaxReader.MAILING_STREET_COLUMN + "," +
                          PropertyTaxReader.MAILING_CITY_COLUMN + "," + 
                          PropertyTaxReader.MAILING_STATE_COLUMN + "," + 
                          PropertyTaxReader.MAILING_STATE_PROVINCE_COLUMN + "," +
                          PropertyTaxReader.STREET_COLUMN + ","+
                          PropertyTaxReader.CITY_COLUMN + "," + 
                          PropertyTaxReader.STATE_PROVINCE_COLUMN + "," + 
                          PropertyTaxReader.ZIP_POSTAL_CODE_COLUMN + "," + 
                          PropertyTaxReader.YEAR_BUILT_COLUMN + "," +
                          PropertyTaxReader.LEAD_STATUS_COLUMN + "," +
                          PropertyTaxReader.LOT_SQUARE_FOOT_COLUMN + "," + 
                          PropertyTaxReader.LAST_SOLD_DATE_COLUMN + "," + 
                          PropertyTaxReader.CO_OWNER_NAME_COLUMN + "," + 
                          PropertyTaxReader.ASSESSED_TOTAL_COLUMN + "," + 
                          PropertyTaxReader.ASSESSED_STRUCTURE_COLUMN + "," + 
                          PropertyTaxReader.ASSESSED_LAND_COLUMN + "," + 
                          PropertyTaxReader.ZONING_COLUMN + "," + 
                          PropertyTaxReader.COMPANY_COLUMN + "," + 
                          PropertyTaxReader.PARCEL_COLUMN + "," + 
                          PropertyTaxReader.LAND_USE_COLUMN);
            string finalData = string.Empty;
            foreach (List<string> row in content)
            {
                for(int i = 0; i < row.Count; i++)
                {
                    finalData = row[i];
                    if (row[i].Contains(","))
                    {
                        finalData = "\""+row[i]+ "\"";
                    }

                    if (i == row.Count - 1)
                    {
                        sb.AppendLine(finalData);
                    }
                    else
                    {
                        sb.Append(finalData + ",");
                    }
                }
            }

            return sb.ToString();
        }
    }
}
