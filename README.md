System.Net.Mail.Abstractions
====================

Inspired by System.IO.Abstractions and System.Configuration.Abstractions comes System.Net.Mail.Abstractions.
A small and simple abstraction around SmtpClient to help you write TDD focused code.

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
