using Xunit;
using BetterPrivateObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetterPrivateObject.Tests
{
    public class PrivateTypeTests
    {
        [Fact]
        public void InvokePrivateMethodThatReturnsBoolean()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool result = subjectPO.privateStaticMethodThatResturnsBoolean();

            Assert.True(result);
        }

        [Fact]
        public void InvokePrivateMethodThatReturnsBooleanWithParameter()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool result = subjectPO.privateStaticMethodThatReturnsBooleanWithParameter(true);

            Assert.True(result);
        }

        [Fact]
        public void InvokePrivateVoidMethod()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.privateStaticVoidMethod();

            Assert.True(true);
        }

        [Fact]
        public void InvokePrivateVoidMethodWithParameter()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.privateStaticVoidMethodWithParameter(1);

            Assert.True(true);
        }

        [Fact]
        public void GetPrivateStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.privateStaticProperty = false;
            bool actual = subjectPO.privateStaticProperty;

            Assert.False(actual);
        }

        [Fact]
        public void SetPrivateStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.privateStaticProperty = true;

            Assert.True(true);
        }

        [Fact]
        public void InvokePublicMethodThatReturnsBoolean()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool result = subjectPO.publicStaticMethodThatResturnsBoolean();

            Assert.True(result);
        }

        [Fact]
        public void InvokePublicMethodThatReturnsBooleanWithParameter()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            bool result = subjectPO.publicStaticMethodThatReturnsBooleanWithParameter(true);

            Assert.True(result);
        }

        [Fact]
        public void InvokePublicVoidMethod()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticVoidMethod();

            Assert.True(true);
        }

        [Fact]
        public void InvokePublicVoidMethodWithParameter()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticVoidMethodWithParameter(1);

            Assert.True(true);
        }

        [Fact]
        public void GetPublicStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticProperty = false;

            bool actual = subjectPO.publicStaticProperty;

            Assert.False(actual);
        }

        [Fact]
        public void SetPublicStaticPropertyValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.publicStaticProperty = true;

            Assert.True(true);
        }

        [Fact]
        public void GetPublicStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            int actual = subjectPO.publicStaticField;

            Assert.Equal(Subject.FieldInitialValue, actual);
        }

        [Fact]
        public void SetPublicStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            const int newValue = 5;
            subjectPO.publicStaticField = newValue;
            int actual = subjectPO.publicStaticField;

            Assert.Equal(newValue, actual);
        }

        [Fact]
        public void GetPrivateStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            int actual = subjectPO.privateStaticField;

            Assert.Equal(Subject.FieldInitialValue, actual);
        }

        [Fact]
        public void SetPrivateStaticFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            const int newValue = 5;
            subjectPO.privateStaticField = newValue;
            int actual = subjectPO.privateStaticField;

            Assert.Equal(newValue, actual);
        }

        [Fact]
        public void GetPrivateStaticReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            subjectPO.privateStaticReadonlyField = Subject.FieldInitialValue;

            int actual = subjectPO.privateStaticReadonlyField;

            Assert.Equal(Subject.FieldInitialValue, actual);
        }

        /// <summary>
        /// Since reflection allows setting readonly fields, why shouldn't we?
        /// </summary>
        [Fact]
        public void SetPrivateStaticReadonlyFieldValue()
        {
            dynamic subjectPO = new PrivateType<Subject>();

            const int newValue = 5;
            subjectPO.privateStaticReadonlyField = newValue;
            int actual = subjectPO.privateStaticReadonlyField;

            Assert.Equal(newValue, actual);
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