using Dapper;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Mayhem.Settings
{
    public class MayhemSettings : IMayhemSettings
    {
        public void ReadSettings(string connectionString)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                PropertyInfo[] properties = GetType().GetProperties();

                foreach (PropertyInfo property in properties)
                {
                    string value = db.QuerySingle<string>($"select [Value] from setting.Setting where [Key] = '{property.Name}'");
                    Type propertyType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                    property.SetValue(this, Convert.ChangeType(value, propertyType), null);
                }
            }
        }
    }
}
