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
			MethodInfo method = typeof(T).GetMethod(binder.Name, BindingFlags.NonPublic | BindingFlags.Instance);

			if (method == null)
			{
				result = null;
				return false;
			}

			result = method.Invoke(Container, args);
			return true;
		}
    }
}
