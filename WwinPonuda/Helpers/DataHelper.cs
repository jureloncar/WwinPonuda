using System.ComponentModel;
using System.Data;

namespace WwinPonuda.Helpers
{
    public class DataHelper
    {
        public static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();

            foreach (PropertyDescriptor prop in  properties)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    dr[prop.Name] = prop.GetValue(item) ?? DBNull.Value;  
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
}
