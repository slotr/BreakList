using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;

namespace Break_List.Class
{
    public static class PivotClass
    {
        public static DataTable ToPivotTable<T, TColumn, TRow, TData>(this IEnumerable<T> source,
      Func<T, TColumn> columnSelector,
      Expression<Func<T, TRow>> rowSelector,
      Func<IEnumerable<T>, TData> dataSelector)
        {
            var table = new DataTable();
            var rowName = ((MemberExpression)rowSelector.Body).Member.Name;
            table.Columns.Add(new DataColumn(rowName));
            var enumerable = source as T[] ?? source.ToArray();
            var columns = enumerable.Select(columnSelector).Distinct();

            var enumerable1 = columns as TColumn[] ?? columns.ToArray();
            foreach (var column in enumerable1)
                table.Columns.Add(new DataColumn(column.ToString()));

            var rows = enumerable.GroupBy(rowSelector.Compile())
                             .Select(rowGroup => new
                             {
                                 rowGroup.Key,
                                 Values = enumerable1.GroupJoin(
                                     rowGroup,
                                     c => c,
                                     columnSelector,
                                     (c, columnGroup) => dataSelector(columnGroup))
                             });

            foreach (var row in rows)
            {
                var dataRow = table.NewRow();
                var items = row.Values.Cast<object>().ToList();
                items.Insert(0, row.Key);
                dataRow.ItemArray = items.ToArray();
                table.Rows.Add(dataRow);
            }

            return table;
        }
    }
}
