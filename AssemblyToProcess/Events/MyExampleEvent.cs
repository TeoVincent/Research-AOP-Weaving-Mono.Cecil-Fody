namespace TeoVincent.AssemblyToProcess.Events
{
    public class MyExampleEvent : AEvent
    {
        public MyExampleEvent()
            : base(typeof(MyExampleEvent).Name)
        { }
    }
}