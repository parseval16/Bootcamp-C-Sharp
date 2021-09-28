using System;
 
public enum AppointmentStatus{

    CONFIRMED,CANCELLED,PENDING

}
public class NotificationManager{

    //EmailNotificationSystem _emailNotificationSystem=new EmailNotificationSystem();
    //SMSDeliverySystem _smsDeliverySystem=new SMSDeliverySystem();
    Action<AppointmentStatus> observers;

    public void Register(Action<AppointmentStatus> observer){
        observers+=observer;
    }
    public void UnRegister(Action<AppointmentStatus> observer){
        observers-=observer;
    }
    public void Notify(AppointmentStatus status){
        Console.WriteLine(status);
        this.observers.Invoke(status);
    }

}
//Observable
public class Appointment{

    AppointmentStatus status;
    NotificationManager _notifyManager;
    public Appointment(NotificationManager notificationManager){
        this._notifyManager=notificationManager;
    }
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
    public void Update(AppointmentStatus status){
        SendEmail();
    }
}
 
public class SMSDeliverySystem{
    public void SendSms(){
    Console.WriteLine("Send SMS Observer" );
    }
    public void Update(AppointmentStatus status){
        SendSms();
    }
 
    
}
 
class Customer{


}

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Hello World");
        EmailNotificationSystem _emailNS=new EmailNotificationSystem();
        SMSDeliverySystem _smsNs=new SMSDeliverySystem();

        Action<AppointmentStatus> _observer1=new Action<AppointmentStatus>(_emailNS.Update);
        Action<AppointmentStatus> _observer2=new Action<AppointmentStatus>(_smsNs.Update);

        NotificationManager _notificationManager=new  NotificationManager();
        _notificationManager.Register (_observer1);
        _notificationManager.Register (_observer2);

        Appointment _appointment=new  Appointment(_notificationManager);
        _appointment.Reserve();
        System.Threading.Tasks.Task.Delay(2000).Wait();
        _appointment.Confirm();
        System.Threading.Tasks.Task.Delay(2000).Wait();
        _appointment.Cancel();

    }
}