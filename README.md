System.Net.Mail.Abstractions
====================

Inspired by System.IO.Abstractions and System.Configuration.Abstractions comes System.Net.Mail.Abstractions.
A small and simple abstraction around SmtpClient to help you write TDD focused code.

[![Build status](https://ci.appveyor.com/api/projects/status/pgc4qo4v4h1fphk7?svg=true)](https://ci.appveyor.com/project/gavynriebau/system-net-mail-abstractions)

# Install

	PM> Install-Package System.Net.Mail.Abstractions

# Register

```csharp
var builder = new ContainerBuilder();

// Register ISmtpClient using your favourite DI container
builder.RegisterInstance(new SmtpClient()).As<ISmtpClient>();

// Register other dependencies
// ...

var container = builder.Build();
```

# Consume

```csharp
public class MyClass
{
   private ISmtpClient _smtpClient;

   public MyClass(ISmtpClient smtpClient)
   {
       _smtpClient = smtpClient;
   }

   public void DoSomethingThenSendEmail()
   {
       // ...

       if (true)
       {
           var from = "alerts@thesystem.com";
           var recipients = "manager@thesystem.com";
           var subject = "Extreme warning";

           var body = new StringBuilder()
               .AppendLine("Dear Manager,")
               .AppendLine("")
               .AppendLine("The plant is about to explode")
               .AppendLine("")
               .AppendLine("Kind Regards,")
               .AppendLine("The System")
               .ToString();

           _smtpClient.Send(from, recipients, subject, body); 
       }

       // ...
   }
}
```

# Test

```csharp
[TestFixture]
public class MyClassTests
{
    [Test]
    public void MyClass_WhenSomeCondition_SendsEmail()
    {
        // Arrange.
        var smtpClient = Substitute.For<ISmtpClient>(); // Using NSubstitute to create a mock of ISmtpClient.
        var sut = new MyClass(smtpClient);              // Pass in the mocked class

        // Act.
        sut.DoSomethingThenSendEmail();

        // Assert.
        // Ensure ISmtpClient.Send was called
        smtpClient.Received(1).Send("alerts@thesystem.com", "manager@thesystem.com", "Extreme warning", Arg.Any<string>());
    }
}
```
