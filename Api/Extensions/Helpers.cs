using Newtonsoft.Json;
using System;

namespace JWTClaimsDemo.Extensions
{
    public static class Helpers
    {
        public static bool IsNull(this object item)
        {
            return item == null ? true : false;
        }
        public static int ToInt(this object item)
        {
            return Convert.ToInt32(item);
        }
        public static string ToJSONString(this object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
