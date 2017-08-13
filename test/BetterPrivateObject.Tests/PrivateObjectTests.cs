using System;
using Xunit;

namespace BetterPrivateObject.Tests
{
     public class PrivateObjectTests
    {
        [Fact]
        public void InvokePrivateMethodThatReturnsBoolean()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool result = subjectPO.privateMethodThatResturnsBoolean();

            Assert.True(result);
        }

        [Fact]
        public void InvokePrivateMethodThatReturnsBooleanWithParameter()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool result = subjectPO.privateMethodThatReturnsBooleanWithParameter(true);

            Assert.True(result);
        }

        [Fact]
        public void InvokePrivateVoidMethod()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.privateVoidMethod();

            Assert.True(true);
        }

        [Fact]
        public void InvokePrivateVoidMethodWithParameter()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.privateVoidMethodWithParameter(1);

            Assert.True(true);
        }

        [Fact]
        public void GetPrivatePropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool actual = subjectPO.privateProperty;

            Assert.False(actual);
        }

        [Fact]
        public void SetPrivatePropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.privateProperty = true;

            Assert.True(true);
        }

        [Fact]
        public void InvokePublicMethodThatReturnsBoolean()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool result = subjectPO.publicMethodThatResturnsBoolean();

            Assert.True(result);
        }

        [Fact]
        public void InvokePublicMethodThatReturnsBooleanWithParameter()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool result = subjectPO.publicMethodThatReturnsBooleanWithParameter(true);

            Assert.True(result);
        }

        [Fact]
        public void InvokePublicVoidMethod()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.publicVoidMethod();

            Assert.True(true);
        }

        [Fact]
        public void InvokePublicVoidMethodWithParameter()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.publicVoidMethodWithParameter(1);

            Assert.True(true);
        }

        [Fact]
        public void GetPublicPropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            bool actual = subjectPO.publicProperty;

            Assert.False(actual);
        }

        [Fact]
        public void SetPublicPropertyValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            subjectPO.publicProperty = true;

            Assert.True(true);
        }

        [Fact]
        public void GetPublicFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            int actual = subjectPO.publicField;

            Assert.Equal(Subject.FieldInitialValue, actual);
        }

        [Fact]
        public void SetPublicFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            const int newValue = 5;
            subjectPO.publicField = newValue;
            int actual = subjectPO.publicField;

            Assert.Equal(newValue, actual);
        }

        [Fact]
        public void GetPrivateFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            int actual = subjectPO.privateField;

            Assert.Equal(Subject.FieldInitialValue, actual);
        }

        [Fact]
        public void SetPrivateFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            const int newValue = 5;
            subjectPO.privateField = newValue;
            int actual = subjectPO.privateField;

            Assert.Equal(newValue, actual);
        }

        [Fact]
        public void GetPrivateReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            int actual = subjectPO.privateReadonlyField;

            Assert.Equal(Subject.FieldInitialValue, actual);
        }

        /// <summary>
        /// Since reflection allows setting readonly fields, why shouldn't we?
        /// </summary>
        [Fact]
        public void SetPrivateReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateObject<Subject>();

            const int newValue = 5;
            subjectPO.privateReadonlyField = newValue;
            int actual = subjectPO.privateReadonlyField;

            Assert.Equal(newValue, actual);
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
