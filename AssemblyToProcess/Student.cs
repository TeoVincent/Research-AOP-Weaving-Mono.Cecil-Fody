using TeoVincent.AssemblyToProcess.Attributes;

namespace TeoVincent.AssemblyToProcess
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