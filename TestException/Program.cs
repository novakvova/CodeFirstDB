using System;

namespace TestException
{
    internal class Program
    {
        class Girl
        {
            public string Size { get; set; }
        }
        static void Main(string[] args)
        {
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);

            //Girl girl=new Girl();
            //girl = null;
            //girl.Size = "23";
            int id = 0;
            id=int.Parse(Console.ReadLine());
            if (id==0)
            {
                //throw new Exception("У нас проблеми Хюстон");
                throw new ExceptionWpf("Проблема в прокладці між сідушкой та кермом"); //new ArgumentException("id не може буть 0");
            }
            //throw new Exception("У нас проблеми Хюстон");
            Console.WriteLine("Hello World!");
        }

        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            if (args.ExceptionObject is ExceptionWpf)
            {
                Console.WriteLine(e.Message);
                
            }
            else
            {
                Console.WriteLine("Невідома помилка. Зверніться до адміна!!!!!!!!!");
                Console.WriteLine("MyHandler caught : " + e.Message);
                Console.WriteLine("Runtime terminating: {0}", args.IsTerminating);
            }
        }
    }
}
