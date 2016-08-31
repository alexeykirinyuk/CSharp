using System;
using System.Reflection;
using System.Text;

namespace CustomJsonSerializer
{
    /// <summary>
    /// 
    /// </summary>
    public static class CustomConverter
    {
       /// <summary>
       /// 
       /// </summary>
       /// <typeparam name="T"></typeparam>
       /// <param name="object"></param>
       /// <returns></returns>
        public static string Convert<T>(T @object)
        {
            var result = string.Empty;

            if (null == @object)
            {
                result = "null";
                return result;
            }

            var type = @object.GetType();

            if (typeof(string).Equals(type))
            {
                result = $"\"{@object}\"";
            }
            else if (typeof(double).Equals(type) || typeof(float).Equals(type))
            {
                result = @object.ToString().Replace(',', '.');
            }
            else if (typeof(bool).Equals(type))
            {
                result = ((@object as bool?) ?? false).ToString().ToLower();
            }
            else if (typeof(DateTime).Equals(type)) 
            {
                var dateTime = @object as DateTime?;
                result = dateTime.Value.ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ssZ");
            }
            else if (type.IsArray)
            {
                result = ConvertArray(@object);
            }
            else if (type.IsClass || (type.IsValueType && !type.IsPrimitive))
            {
                result = ConvertObject(@object);
            }
            else if (type.IsPrimitive)
            {
                result = @object.ToString();
            }
            return result;
        }

        private static string ConvertObject<T>(T @object)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("{").Append(ConvertMembers(@object)).Append('}');
            return stringBuilder.ToString();
        }

        private static string ConvertArray<T>(T @object)
        {
            var builder = new StringBuilder();
            var array = @object as Array;
            if (null == array)
            {
                return null;
            }

            builder.Append('[');

            foreach(var element in array)
            {
                builder.Append(Convert(element)).Append(',');
            }

            builder.Remove(builder.Length - 1, 1).Append("]");
            return builder.ToString();
        }

        private static string ConvertMembers<T>(T @object)
        {
            var builder = new StringBuilder();
            var members = @object.GetType().GetMembers();

            foreach (var member in members)
            {
                if ((MemberTypes.Field != member.MemberType && 
                    MemberTypes.Property != member.MemberType)
                    || Attribute.IsDefined(member, typeof(NonSerializedAttribute)))
                {
                    continue;
                }

                var convertedObject = string.Empty;

                try
                {
                    convertedObject = Convert(GetValue(member, @object));
                    builder.Append($"\"{ member.Name }\"=").Append(convertedObject).Append(',');
                }
                catch { }
            }
            return builder.Remove(builder.Length - 1, 1).ToString();
        }

        private static object GetValue<T>(MemberInfo member, T @object)
        {
            if (MemberTypes.Field == member.MemberType)
            {
                return (member as FieldInfo).GetValue(@object);
            }
            else if (MemberTypes.Property == member.MemberType)
            {
                return (member as PropertyInfo).GetValue(@object);
            }
            return null;
        }

        private static Type GetType(MemberInfo member)
        {
            if (MemberTypes.Field == member.MemberType)
            {
                return (member as FieldInfo).FieldType;
            }
            else if (MemberTypes.Property == member.MemberType)
            {
                return (member as PropertyInfo).PropertyType;
            }
            return null;
        }
    }
}
