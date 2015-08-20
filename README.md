# BetterPrivateObject

Better private object, using dynamic object. Yes, it's very cool!

If you want to test a private method like this:

```csharp
public class Subject
{
	private int annoyingPrivateSum(int num1, int num2) { return num1+num2; }
}
```

You just have to do this:

```csharp
[TestMethod]
public void TestPrivateMethod()
{
	dynamic subjectPO = new PrivateObject<Subject>();

	int result = subjectPO.annoyingPrivateSum(1, 1);

	Assert.AreEqual(2, result);
}
```

Nice!?
