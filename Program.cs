﻿namespace ProcessMonitor
{
    public class Program
    {
        public static int Main(string[] args)
        {
            Tasks tasks = new Tasks();

            if (args.Length == 0)
            {
                Extensions.PrintArgs();
                return 1;
            }

            switch (Extensions.GetField(args[0].ToUpper()))
            {
                case ARGS.LIST:
                    tasks.ListProcesses();
                    break;

                case ARGS.ADD:
                    Console.WriteLine(tasks.AddProcesses(args[1]));
                    break;

                // TODO Handle sub commands better
                case ARGS.START:
                    if (args.Length > 1 && args[1] == "background") tasks.Start();
                    else Tasks.NewWindow("start background");
                    break;

                case ARGS.ALERT:
                    tasks.Alarm(args[1]);
                    break;

                case ARGS.HELP:
                default:
                    Extensions.PrintArgs();
                    break;
            }

            return 0; 
        }
    }
}