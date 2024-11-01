namespace ConsoleApp1
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            //bai 1
            //Thread.CurrentThread.Name = "Main";
            //Task task01 = new Task(() => PrintNumber("Task 01"));
            //task01.Start();
            //Task task02 = Task.Run(delegate { PrintNumber("Task 02"); });
            //Task task03 = new Task(new Action(() => { PrintNumber("Task 03"); }));
            //task03.Start();
            //Console.WriteLine($"{Thread.CurrentThread.Name}");
            //Console.ReadKey();
            //bai 2
            //Task[] tasks = new Task[5];
            //String taskData = "Hello";
            //for (int i = 0; i < 5; i++)
            //{
            //    tasks[i] = Task.Run(() =>
            //    {
            //        Console.WriteLine($"Task = {Task.CurrentId}, obj = {taskData}, ThreadId = {Thread.CurrentThread.ManagedThreadId}");
            //        Thread.Sleep(1000);
            //    });
            //}
            //try
            //{
            //    Task.WaitAll(tasks);

            //}
            //catch (AggregateException ae)
            //{
            //    Console.WriteLine("One or more exception occur:");
            //    foreach (var ex in ae.Flatten().InnerExceptions)
            //    {
            //        Console.WriteLine("{0}", ex.Message);
            //    }
            //}
            //Console.WriteLine("Statuc of completed tasks:");
            //foreach (var task in tasks)
            //{
            //    Console.WriteLine("Task #{0}: {1}", task.Id, task.Status);
            //}
            //bai 3
            //var range = Enumerable.Range(1, 100000);
            //var resultList = range.Where(i => i % 3 == 0).ToList();
            //Console.WriteLine($"Sequential: Total items are: {resultList.Count}");
            //resultList = range.AsParallel().Where(i => i % 3 == 0).ToList();
            //Console.WriteLine($"Parallel: Total items are: {resultList.Count}");
            //resultList = (from i in range.AsParallel() where i % 3 == 0 select i).ToList();
            //Console.WriteLine($"Parallel: Total items are: {resultList.Count}");
            //Console.ReadLine();
            //bai 4

        }
        static void PrintNumber(string message)
        {
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"{message}: {i}");
                Thread.Sleep(1000);
            }
        }
        public async Task<int> GetContentLength()
        {
            var client = new HttpClient();
            Task<string> getStringTask = client.GetStringAsync("https://dotnet.microsoft.com/en-us/");
            DoIndependentWork();
            string contents = await getStringTask;
            return contents.Length;
        }
        void DoIndependentWork()
        {
            Console.WriteLine("Working...");
        }
    }
}
