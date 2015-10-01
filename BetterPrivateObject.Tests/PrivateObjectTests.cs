using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BetterPrivateObject.Tests
{
    [TestClass]
    public class PrivateObjectTests
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

        [TestMethod]
        public void GetPrivatePropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool actual = subjectPO.privateProperty;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SetPrivatePropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.privateProperty = true;

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InvokePublicMethodThatReturnsBoolean()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool result = subjectPO.publicMethodThatResturnsBoolean();

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvokePublicMethodThatReturnsBooleanWithParameter()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool result = subjectPO.publicMethodThatReturnsBooleanWithParameter(true);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void InvokePublicVoidMethod()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.publicVoidMethod();

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void InvokePublicVoidMethodWithParameter()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.publicVoidMethodWithParameter(1);

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetPublicPropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool actual = subjectPO.publicProperty;

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void SetPublicPropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.publicProperty = true;

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void GetPublicFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            int actual = subjectPO.publicField;

            Assert.AreEqual(Subject.FieldInitialValue, actual);
        }

        [TestMethod]
        public void SetPublicFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            const int newValue = 5;
            subjectPO.publicField = newValue;
            int actual = subjectPO.publicField;

            Assert.AreEqual(newValue, actual);
        }

        [TestMethod]
        public void GetPrivateFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            int actual = subjectPO.privateField;

            Assert.AreEqual(Subject.FieldInitialValue, actual);
        }

        [TestMethod]
        public void SetPrivateFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            const int newValue = 5;
            subjectPO.privateField = newValue;
            int actual = subjectPO.privateField;

            Assert.AreEqual(newValue, actual);
        }

        [TestMethod]
        public void GetPrivateReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            int actual = subjectPO.privateReadonlyField;

            Assert.AreEqual(Subject.FieldInitialValue, actual);
        }

        /// <summary>
        /// Since reflection allows setting readonly fields, why shouldn't we?
        /// </summary>
        [TestMethod]
        public void SetPrivateReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            const int newValue = 5;
            subjectPO.privateReadonlyField = newValue;
            int actual = subjectPO.privateReadonlyField;

            Assert.AreEqual(newValue, actual);
        }

        public class Subject
        {
            public const int FieldInitialValue = 42;

            public int publicField;
            private int privateField;
            private readonly int privateReadonlyField;

            public Subject()
            {
                publicField = FieldInitialValue;
                privateField = FieldInitialValue;
                privateReadonlyField = FieldInitialValue;
            }

            private bool privateMethodThatResturnsBoolean() { return true; }
            private bool privateMethodThatReturnsBooleanWithParameter(bool p1) { return p1; }
            private void privateVoidMethod() { }
            private void privateVoidMethodWithParameter(int p1) { }
            public bool publicMethodThatResturnsBoolean() { return true; }
            public bool publicMethodThatReturnsBooleanWithParameter(bool p1) { return p1; }
            public void publicVoidMethod() { }
            public void publicVoidMethodWithParameter(int p1) { }
            private bool privateProperty { get; set; }
            public bool publicProperty { get; set; }
        }
    }
}
