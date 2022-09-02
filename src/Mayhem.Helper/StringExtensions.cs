using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Mayhem.Helper
{
    public static class StringExtensions
    {
        public static string ToQueryString(this object obj)
        {
            static IEnumerable<string> enumerable(object obj)
            {
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    object[] attrs = prop.GetCustomAttributes(true);
                    if (attrs.Any(x => x is System.Text.Json.Serialization.JsonIgnoreAttribute))
                    {
                        continue;
                    }
                    if (prop.GetValue(obj, null) != null)
                    {
                        yield return $"{prop.Name}={HttpUtility.UrlEncode(prop.GetValue(obj, null).ToString())}";
                    }
                }
            }

            return string.Join("&", enumerable(obj).ToArray());
        }

        public static IEnumerable<string> SplitInParts(this string s, int partLength)
        {
            for (int i = 0; i < s.Length; i += partLength)
            {
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
            }
        }
    }
}
