using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomJsonSerializer
{
    public static class CustomConvert
    {
        public static string Convert<T>(T obj)
        {
            var builder = new StringBuilder("{");

            WriteProperties(builder, obj);
            WriteFields(builder, obj);

            builder.Remove(builder.Length - 1, 1);
            builder.Append("}");

            return builder.ToString();
        }

        private static void WriteProperties<T>(StringBuilder builder, T obj)
        {
            var typeObj = obj.GetType();
            PropertyInfo[] properties = typeObj.GetProperties();

            foreach (var property in properties)
            {

                builder
                    .Append("\"")
                    .Append(property.Name)
                    .Append("\"=");
                if (property.PropertyType.Equals(typeof(string)))
                {
                    builder
                        .Append("\"")
                        .Append(property.GetValue(obj))
                        .Append("\"")
                        .Append(",");
                }
                else if(property.PropertyType.IsClass)
                {
                    builder.Append("{");
                    Type type = property.PropertyType;
                    WriteProperties(builder, property.GetValue(obj));
                    WriteFields(builder, property.GetValue(obj));
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append("},");
                }
                else
                {
                    builder
                        .Append(property.GetValue(obj))
                        .Append(",");
                }
            }
        }

        private static void WriteFields<T>(StringBuilder builder, T obj)
        {
            var typeObj = obj.GetType();
            FieldInfo[] fields = typeObj.GetFields();

            foreach (var field in fields)
            {
                if (Attribute.IsDefined(field, typeof(NonSerializedAttribute))) continue;

                builder
                    .Append("\"")
                    .Append(field.Name)
                    .Append("\"=");

                if (field.FieldType.Equals(typeof(string)))
                {
                    builder
                        .Append("\"")
                        .Append(field.GetValue(obj))
                        .Append("\"")
                        .Append(",");
                }
                else if (field.FieldType.IsClass)
                {
                    builder.Append("{");
                    Type type = field.FieldType;
                    WriteProperties(builder, field.GetValue(obj));
                    WriteFields(builder, field.GetValue(obj));
                    builder.Remove(builder.Length - 1, 1);
                    builder.Append("},");
                }
                else
                {
                    builder
                        .Append(field.GetValue(obj))
                        .Append(",");
                }
            }
        }

    }
}
