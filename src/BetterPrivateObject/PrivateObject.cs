using System;
using System.Dynamic;
using System.Reflection;

namespace BetterPrivateObject
{
    public class PrivateObject<T> : DynamicObject
    {
		public T Container { get; set; }

		public PrivateObject()
		{
			Container = Activator.CreateInstance<T>();
		}

		public PrivateObject(T container)
		{
			Container = container;
		}

		public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
		{
			MethodInfo method = typeof(T).GetMethod(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

			if (method == null)
			{
				result = null;
				return false;
			}

			result = method.Invoke(Container, args);
			return true;
		}

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            PropertyInfo property = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property == null)
            {
                FieldInfo field = typeof(T).GetField(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (field == null)
                {
                    result = null;
                    return false;
                }
                else
                {
                    result = field.GetValue(Container);
                }
            }
            else
            {
                result = property.GetValue(Container, null);
            }
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            PropertyInfo property = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property == null)
            {
                FieldInfo field = typeof(T).GetField(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (field == null)
                {
                    return false;
                }
                else
                {
                    field.SetValue(Container, value);
                }
            }
            else
            {
                property.SetValue(Container, value, null);
            }
            return true;
        }
    }
}
