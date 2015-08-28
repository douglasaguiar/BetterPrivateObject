using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace BetterPrivateObject
{
    /// <summary>
    /// Strongly typed and dynamic implementation of the PrivateType class
    /// from MsTest.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PrivateType<T> : DynamicObject
    {
        public PrivateType()
        {
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            MethodInfo method = typeof(T).GetMethod(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);

            if (method == null)
            {
                result = null;
                return false;
            }

            result = method.Invoke(null, args);
            return true;
        }


        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            PropertyInfo property = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (property == null)
            {
                result = null;
                return false;
            }
            result = property.GetValue(null, null);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            PropertyInfo property = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (property == null)
            {
                return false;
            }
            property.SetValue(null, value, null);
            return true;
        }
    }
}
