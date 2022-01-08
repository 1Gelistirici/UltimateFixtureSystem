using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Common
{
    public class EnumHelper
    {
            public static string GetEnumDescriptionText<T>(int enumValue)
            {
                List<string> list = new List<string>();
                foreach (var v in Enum.GetValues(typeof(T)))
                {
                    if ((enumValue & Convert.ToInt32(v)) <= 0) continue;
                    FieldInfo fi = typeof(T).GetField(v.ToString());
                    DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                    if (attributes.Length > 0)
                        list.Add(attributes[0].Description);
                }
                return string.Join(", ", list.ToArray());
            }
            public static string GetEnumDescription<T>(string enumValue)
            {
                var type = typeof(T);
                var memInfo = type.GetMember(enumValue);
                var attributes = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);

                return attributes.Length != 0 ? ((DescriptionAttribute)attributes[0]).Description : null;
            }

            public static string GetEnumDescriptionTextWithoutBitwise<T>(int enumValue)
            {
                FieldInfo fi = typeof(T).GetField(typeof(T).GetEnumName(enumValue));
                DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                return attributes.Length > 0 ? attributes[0].Description : null;
            }
        }
    }
