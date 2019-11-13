using System.Dynamic;
using System.Reflection;

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
                FieldInfo field = typeof(T).GetField(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                if (field == null)
                {
                    result = null;
                    return false;
                }
                else
                {
                    result = field.GetValue(null);
                }
            }
            else
            {
                result = property.GetValue(null, null);
            }
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            PropertyInfo property = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            if (property == null)
            {
                FieldInfo field = typeof(T).GetField(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                if (field == null)
                {
                    return false;
                }
                else
                {
                    field.SetValue(null, value);
                }
            }
            else
            {
                property.SetValue(null, value, null);
            }
            return true;
        }
    }
}
