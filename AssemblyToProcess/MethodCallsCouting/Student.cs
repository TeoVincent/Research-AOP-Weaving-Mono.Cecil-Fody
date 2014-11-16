namespace TeoVincent.AssemblyToProcess.MethodCallsCouting
{
    public class Student
    {
        [CountCallsThem]
        public void PassTheExam()
        {
           // ...
        }

        [CountCallsThem]
        public int BuyBeer()
        {
            // ...
            return 1024;
        }
    }
}