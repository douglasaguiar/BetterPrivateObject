using Microsoft.VisualStudio.TestTools.UnitTesting;
using BetterPrivateObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPrivateObject.Tests
{
  [TestClass]
  public class PrivateTypeTests
  {
    [TestMethod]
    public void InvokePrivateMethodThatReturnsBoolean()
    {
      dynamic subjectPO = new PrivateType<Subject>();

      bool result = subjectPO.privateStaticMethodThatResturnsBoolean();

      Assert.IsTrue(result);
    }

    [TestMethod]
    public void InvokePrivateMethodThatReturnsBooleanWithParameter()
    {
      dynamic subjectPO = new PrivateType<Subject>();

      bool result = subjectPO.privateStaticMethodThatReturnsBooleanWithParameter(true);

      Assert.IsTrue(result);
    }

    [TestMethod]
    public void InvokePrivateVoidMethod()
    {
      dynamic subjectPO = new PrivateType<Subject>();

      subjectPO.privateStaticVoidMethod();

      Assert.IsTrue(true);
    }

    [TestMethod]
    public void InvokePrivateVoidMethodWithParameter()
    {
      dynamic subjectPO = new PrivateType<Subject>();

      subjectPO.privateStaticVoidMethodWithParameter(1);

      Assert.IsTrue(true);
    }

    public class Subject
    {
      private static bool privateStaticMethodThatResturnsBoolean() { return true; }
      private static bool privateStaticMethodThatReturnsBooleanWithParameter(bool p1) { return p1; }
      private static void privateStaticVoidMethod() { }
      private static void privateStaticVoidMethodWithParameter(int p1) { }
    }
  }
}