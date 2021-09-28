using System;
 
public enum AppointmentStatus{

    CONFIRMED,CANCELLED,PENDING

}
public class NotificationManager{

    EmailNotificationSystem _emailNotificationSystem=new EmailNotificationSystem();
    SMSDeliverySystem _smsDeliverySystem=new SMSDeliverySystem();

    public void Notify(AppointmentStatus status){
        Console.WriteLine(status);
        _emailNotificationSystem.SendEmail();
        _smsDeliverySystem.SendSms();
    }

}
//Observable
public class Appointment{

    AppointmentStatus status;
    NotificationManager _notifyManager=new NotificationManager();
    public void Confirm(){
        this.status=AppointmentStatus.CONFIRMED;
        this.Notify();
    }
    public void Cancel(){
        this.status=AppointmentStatus.CANCELLED;
        this.Notify();
    }

    public void Reserve(){

        this.status=AppointmentStatus.PENDING;
        this.Notify();
    }
    void Notify(){
        _notifyManager.Notify(this.status);
    }

}
 
public class EmailNotificationSystem{
 
    public void SendEmail(){
    Console.WriteLine("Send Enail Observer" );
    }
}
 
public class SMSDeliverySystem{
    public void SendSms(){
    Console.WriteLine("Send SMS Observer" );
    }
}
 
class Customer{


}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
        Appointment _appointment=new  Appointment();
        _appointment.Reserve();
        System.Threading.Tasks.Task.Delay(2000).Wait();
        _appointment.Confirm();
        System.Threading.Tasks.Task.Delay(2000).Wait();
        _appointment.Cancel();

    }
}