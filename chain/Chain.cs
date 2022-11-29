using System;

interface IWarningHandler
{
    IWarningHandler SetNext(IWarningHandler nextHandler);
    void Handle(int daysOfPaymentDelay);
}

abstract class WarningHandler : IWarningHandler
{
    protected IWarningHandler _nextHandler;

    public virtual void Handle(int daysOfPaymentDelay)
    {
        if (_nextHandler != null)
        {
            _nextHandler.Handle(daysOfPaymentDelay);
        }
        else
        {
            Console.WriteLine("What now?");
        }
    }

    public IWarningHandler SetNext(IWarningHandler nextHandler)
    {
        _nextHandler = nextHandler;

        return nextHandler;
    }
}

class LightWarning : WarningHandler
{
    public override void Handle(int daysOfPaymentDelay)
    {
        if (daysOfPaymentDelay == 1)
        {
            Console.WriteLine("Send push notification");
        }
        else
        {
            base.Handle(daysOfPaymentDelay);
        }
    }
}
class MediumWarning : WarningHandler
{
    public override void Handle(int daysOfPaymentDelay)
    {
        if (daysOfPaymentDelay > 1 && daysOfPaymentDelay <= 5)
        {
            Console.WriteLine("Send email notification");
        }
        else
        {
            base.Handle(daysOfPaymentDelay);
        }
    }
}

class LastWarning : WarningHandler
{
    public override void Handle(int daysOfPaymentDelay)
    {
        if (daysOfPaymentDelay > 5 && daysOfPaymentDelay <= 10)
        {
            Console.WriteLine("Send SMS");
        }
        else
        {
            base.Handle(daysOfPaymentDelay);
        }
    }
}

class Ban : WarningHandler
{
    public override void Handle(int daysOfPaymentDelay)
    {
        if (daysOfPaymentDelay > 10)
        {
            Console.WriteLine("Ban this dude");
        }
        else
        {
            base.Handle(daysOfPaymentDelay);
        }
    }
}


class Program44
{
    static void Main(string[] args)
    {
        IWarningHandler lightWarningHandler = new LightWarning();
        IWarningHandler mediumWarningHandler = new MediumWarning();
        IWarningHandler LastWarningHandler = new LastWarning();
        IWarningHandler BanHandler = new Ban();

        lightWarningHandler.SetNext(mediumWarningHandler).SetNext(LastWarningHandler).SetNext(BanHandler);

        lightWarningHandler.Handle(1);
        lightWarningHandler.Handle(4);
        lightWarningHandler.Handle(9);
        lightWarningHandler.Handle(12);
    }
}

