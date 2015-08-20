using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterPrivateObject.Tests
{
	[TestClass]
	public class PrivateObjectUnitTest
	{
		[TestMethod]
		public void InvokePrivateMethodThatReturnsBoolean()
		{
			dynamic subjectPO = new PrivateObject<Subject>();

			bool result = subjectPO.privateMethodThatResturnsBoolean();

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void InvokePrivateMethodThatReturnsBooleanWithParameter()
		{
			dynamic subjectPO = new PrivateObject<Subject>();

			bool result = subjectPO.privateMethodThatReturnsBooleanWithParameter(true);

			Assert.IsTrue(result);
		}

		[TestMethod]
		public void InvokePrivateVoidMethod()
		{
			dynamic subjectPO = new PrivateObject<Subject>();

			subjectPO.privateVoidMethod();

			Assert.IsTrue(true);
		}

		[TestMethod]
		public void InvokePrivateVoidMethodWithParameter()
		{
			dynamic subjectPO = new PrivateObject<Subject>();

			subjectPO.privateVoidMethodWithParameter(1);

			Assert.IsTrue(true);
		}
	}

	public class Subject
	{
		private bool privateMethodThatResturnsBoolean() { return true; }
		private bool privateMethodThatReturnsBooleanWithParameter(bool p1) { return p1; }
		private void privateVoidMethod() { }
		private void privateVoidMethodWithParameter(int p1) { }
	}
}
