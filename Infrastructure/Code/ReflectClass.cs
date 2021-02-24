using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Code
{
   public class ReflectClass
    {
     public struct PropertyInfo
        {

            public string Name;

            public Type Type;

            public object Value;
        }
        public  List<PropertyInfo> Property { get; set; } = new List<PropertyInfo>();
        public void FromatDitits<T>(T model)
        {
            var newType = model.GetType();
            foreach (var item in newType.GetRuntimeProperties())
            {
                var type = item.PropertyType.Name;
                var IsGenericType = item.PropertyType.IsGenericType;
                var list = item.PropertyType.GetInterface("IEnumerable", false);
                Property.Add (new PropertyInfo() {Name= item.Name,Type= item.PropertyType, Value=item.GetValue(model)});
            //    Console.WriteLine($"属性名称：{item.Name}，类型：{type}，值：{item.GetValue(model)}");
                //if (IsGenericType && list != null)
                //{
                //    var listVal = item.GetValue(model) as IEnumerable<object>;
                //    if (listVal == null) continue;
                //    foreach (var aa in listVal)
                //    {
                //        var dtype = aa.GetType();
                //        foreach (var bb in dtype.GetProperties())
                //        {
                //            var dtlName = bb.Name.ToLower();
                //            var dtlType = bb.PropertyType.Name;
                //            var oldValue = bb.GetValue(aa);
                //            if (dtlType == typeof(decimal).Name)
                //            {
                //                int dit = 4;
                //                if (dtlName.Contains("price") || dtlName.Contains("amount"))
                //                    dit = 2;
                //                bb.SetValue(aa, Math.Round(Convert.ToDecimal(oldValue), dit, MidpointRounding.AwayFromZero));
                //            }
                //            Console.WriteLine($"子级属性名称：{dtlName}，类型：{dtlType}，值：{oldValue}");
                //        }
                //    }
                //}
            }
        }
    }
}
