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

        [TestMethod]
        public void GetPrivateStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool actual = subjectPO.privateStaticProperty;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SetPrivateStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.privateStaticProperty = true;

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InvokePublicMethodThatReturnsBoolean()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool result = subjectPO.publicStaticMethodThatResturnsBoolean();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvokePublicMethodThatReturnsBooleanWithParameter()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool result = subjectPO.publicStaticMethodThatReturnsBooleanWithParameter(true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvokePublicVoidMethod()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticVoidMethod();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InvokePublicVoidMethodWithParameter()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticVoidMethodWithParameter(1);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetPublicStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool actual = subjectPO.publicStaticProperty;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SetPublicStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticProperty = true;

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetPublicStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            int actual = subjectPO.publicStaticField;

            Assert.AreEqual(Subject.FieldInitialValue, actual);
        }

        [TestMethod]
        public void SetPublicStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            const int newValue = 5;
            subjectPO.publicStaticField = newValue;
            int actual = subjectPO.publicStaticField;

            Assert.AreEqual(newValue, actual);
        }

        [TestMethod]
        public void GetPrivateStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            int actual = subjectPO.privateStaticField;

            Assert.AreEqual(Subject.FieldInitialValue, actual);
        }

        [TestMethod]
        public void SetPrivateStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            const int newValue = 5;
            subjectPO.privateStaticField = newValue;
            int actual = subjectPO.privateStaticField;

            Assert.AreEqual(newValue, actual);
        }

        [TestMethod]
        public void GetPrivateStaticReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            int actual = subjectPO.privateStaticReadonlyField;

            Assert.AreEqual(Subject.FieldInitialValue, actual);
        }

        /// <summary>
        /// Since reflection allows setting readonly fields, why shouldn't we?
        /// </summary>
        [TestMethod]
        public void SetPrivateStaticReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            const int newValue = 5;
            subjectPO.privateStaticReadonlyField = newValue;
            int actual = subjectPO.privateStaticReadonlyField;

            Assert.AreEqual(newValue, actual);
        }

        public class Subject
        {
            public const int FieldInitialValue = 42;

            public static int publicStaticField;
            private static int privateStaticField;
            private static readonly int privateStaticReadonlyField;

            static Subject()
            {
                publicStaticField = FieldInitialValue;
                privateStaticField = FieldInitialValue;
                privateStaticReadonlyField = FieldInitialValue;
            }

            private static bool privateStaticMethodThatResturnsBoolean() { return true; }
            private static bool privateStaticMethodThatReturnsBooleanWithParameter(bool p1) { return p1; }
            private static void privateStaticVoidMethod() { }
            private static void privateStaticVoidMethodWithParameter(int p1) { }
            public static bool publicStaticMethodThatResturnsBoolean() { return true; }
            public static bool publicStaticMethodThatReturnsBooleanWithParameter(bool p1) { return p1; }
            public static void publicStaticVoidMethod() { }
            public static void publicStaticVoidMethodWithParameter(int p1) { }
            private static bool privateStaticProperty { get; set; }
            public static bool publicStaticProperty { get; set; }
        }
    }
}