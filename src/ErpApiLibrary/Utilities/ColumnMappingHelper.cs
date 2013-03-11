/* $Workfile: ColumnMappingHelper.cs $, $Date: 13/01/04 6:51p $, $Author: Joeychen $, $Revision: 4 $ */

using System;
using System.Data;
using System.Linq;
using System.Reflection;
using Monday.DataAccess.Common;

namespace ErpApi.Utility
{
    /// <summary>
    /// RowMapper模組
    /// </summary>
    public static class ColumnMappingHelper
    {
        /// <summary>
        /// Mappings the entity.
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="row">The row.</param>
        /// <returns>
        /// mapping完資料的entity
        /// </returns>
        public static T MappingEntity<T>(DataRow row) where T : new()
        {
            var result = new T();

            ////取得DataRow上所有Column名稱
            var columns = row.Table.Columns.Cast<DataColumn>().Select(x => x.ColumnName);

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (var p in properties)
            {
                ////取得property對應要mapping的column name
                var mappingAttribute = p.GetCustomAttributes(typeof(DBColumnMappingAttribute), false).FirstOrDefault() as DBColumnMappingAttribute;
                var columnName = mappingAttribute == null ? p.Name : mappingAttribute.ColumnName;

                if (columns.Contains(columnName))
                {
                    if (!p.PropertyType.IsEnum)
                    {
                        MappingValueToPropertyType<T>(row, result, p, columnName);
                    }
                    else
                    {
                        MappingValueToEnum<T>(row, result, p, columnName);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// 取得該type的預設值，若為Nullable，則回傳null
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="isNullable">if set to <c>true</c> [is nullable].</param>
        /// <returns>
        /// 該type預設值
        /// </returns>
        private static object GetDefaultValueByType(Type type, bool isNullable)
        {
            if (isNullable || !type.IsValueType)
            {
                return null;
            }
            else
            {
                return Activator.CreateInstance(type);
            }
        }

        /// <summary>
        /// Mappings the value to enum.
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="row">The row.</param>
        /// <param name="result">The result.</param>
        /// <param name="p">The p.</param>
        /// <param name="columnName">Name of the column.</param>
        private static void MappingValueToEnum<T>(DataRow row, T result, PropertyInfo p, string columnName) where T : new()
        {
            p.SetValue(result, Enum.ToObject(p.PropertyType, row[columnName]), null);
        }

        /// <summary>
        /// Mappings the type of the value to property.
        /// </summary>
        /// <typeparam name="T">entity</typeparam>
        /// <param name="row">The row.</param>
        /// <param name="result">The result.</param>
        /// <param name="p">The p.</param>
        /// <param name="columnName">Name of the column.</param>
        private static void MappingValueToPropertyType<T>(DataRow row, T result, PropertyInfo p, string columnName) where T : new()
        {
            bool isNullable = Nullable.GetUnderlyingType(p.PropertyType) != null;
            Type type = Nullable.GetUnderlyingType(p.PropertyType) ?? p.PropertyType;

            var typeDefaultValue = GetDefaultValueByType(type, isNullable);
            var safeValue = row[columnName] == DBNull.Value ? typeDefaultValue : Convert.ChangeType(row[columnName], type);

            p.SetValue(result, safeValue, null);
        }
    }
}