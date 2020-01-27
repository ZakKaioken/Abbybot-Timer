# Abbybot Timer
 abbybot's timing api

There are 2 main pieces to the abbybot timer.

# The timer
By default the timer is always active, since it will run at the start of the program forever. it fires a check into it's list of timed objects at a default rate of 500ms. 

example of usage:
```cs
ABTimer timer = new ABTimer();

//Timers that just need to be sent to console go here
timer.Add("timer name", DateTime.Now.AddSeconds(5));
```
you could also chose to add a timed object yourself allowing for easy access to the object's event.

```cs
TimedObject to = new TimedObject("timer name", DateTime.Now.AddSeconds(5));
to.passed += (me, n) => Console.WriteLine($"{to.Name} has passed!!");
timer.Add(to);
```

Of course it's not always optimal to specify an event every time you make an object so I made the function that calls the event handler an overridable method.

Example of new class inheriting from TimeObject
```cs
class SpecialTimeObject : TimeObject {
    public override void DoWork() {
        Console.WriteLine($"I'm special: {Name} is finished.");
        base.DoWork(); 
    }
}
```
Do note the ``base.DoWork();`` inside the overridden method. If you include it the event handler can still be used.

Thank you for taking a look at the abbybot Timer