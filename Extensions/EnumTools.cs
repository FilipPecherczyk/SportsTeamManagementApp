using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SportsTeamManagementApp.Extensions
{
    public static class EnumTools
    {
        public static string GetDescription(Enum choosenEnum)
        {
            Type type = choosenEnum.GetType();
            MemberInfo[] memInfo = type.GetMember(choosenEnum.ToString());
            if (memInfo?.Length > 0)
            {
                object[] attrs = memInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attrs?.Length > 0)
                    return ((DescriptionAttribute)attrs[0]).Description;
            }
            return choosenEnum.ToString();
        }

        public static T GetEnumValue<T>(string str) where T : struct, IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new Exception("T must be an Enumeration type.");
            }
            T val = ((T[])Enum.GetValues(typeof(T)))[0];
            if (!string.IsNullOrEmpty(str))
            {
                foreach (T enumValue in (T[])Enum.GetValues(typeof(T)))
                {
                    if (enumValue.ToString().Equals(str, StringComparison.OrdinalIgnoreCase))
                    {
                        val = enumValue;
                        break;
                    }
                }
            }

            return val;
        }
    }
}
