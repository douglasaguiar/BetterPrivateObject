using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

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
                result = null;
                return false;
            }
            result = property.GetValue(Container, null);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            PropertyInfo property = typeof(T).GetProperty(binder.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            if (property == null)
            {
                return false;
            }
            property.SetValue(Container, value, null);
            return true;
        }
    }
}
