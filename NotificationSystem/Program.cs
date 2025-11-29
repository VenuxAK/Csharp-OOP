/*
 * A system that sends notifications to users. Notifications can be Email or SMS.
 * A simple C# console project that demonstrates all 5 SOLID principles.
 * 
 * **/


/* SRP - Single Responsibility Principle
 * Separate responsibilities: one class for user, another for notification sending.
 * *****/

public class User
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}


/* OCP - Open/Closed Principle
 * Add new notification types without modifying existing code.
 * *****/

public interface INotification
{
    void Send(User user, string message);
}

// Email notification
public class EmailNotification : INotification
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"Email sent to {user.Email}: {message}");
    }
}

// SMS notification
public class SmsNotification : INotification
{
    public void Send(User user, string message)
    {
        Console.WriteLine($"SMS sent to {user.Phone}: {message}");
    }
}

/* ISP - Interface Segregation Principle
 * Seperate interfaces for different kind of actions.
 * If we want to add WhatsApp notifications later, 
 * we just create a new class without changing Email or SMS classes.
 * 
 * *****/



/* LSP - Liskov Substitution Principle
 * can be replace any INotification implementation without breaking code.
 * *****/

public class NotificationService
{
    public void Notify(User user, string message, INotification notification)
    {
        notification.Send(user, message);
    }
}

/**
 * Works for EmailNotification, SmsNotification, or any future notification.
 * *****/




/* DIP - Dependency Inversion Principle
 * NotificationService depends on abstractions (INotification), 
 * not concrete classes (EmailNotification or SmsNotification).
 * *****/

internal class Program
{
    static void Main(string[] args)
    {
        User user = new User() { Name = "ArKar", Email = "arkar@gmail.com", Phone = "959123123"};

        INotification email = new EmailNotification();
        INotification sms = new SmsNotification();

        NotificationService notificationService = new NotificationService();
        notificationService.Notify(user, "Hello via email", email);     // Depend on abstraction
        notificationService.Notify(user, "Hello via sms", sms);         // Depend on abstraction

    }
}








