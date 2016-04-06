using System;
using System.Collections.Generic;
using System.Threading;
using StackExchange.Redis;

namespace Redis
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionMultiplexer redis = ConnectionMultiplexer.Connect("devtalks");

            IDatabase db = redis.GetDatabase(0);

            var urls = new List<string>() { "/about", "/services", "/help" };
            var rnd = new Random();
            for (int i = 0; i < 5000000; i++)
            {
                if (i%5000 == 0)
                {
                    Console.WriteLine($"Processed {i}");
                }

                var user = rnd.Next(1, 5000);
                var urlIndex = rnd.Next(0, 2);
                var url = urls[urlIndex];
                var date = DateTime.Now.AddDays(rnd.Next(0, 30) * -1).Date;

                try
                {
                    db.StringSetBit(DateGen.GenerateShort(date) + ":users", user, true);
                    db.StringSetBit(DateGen.GenerateShort(date) + ":" + url, user, true);
                    db.SortedSetIncrement(DateGen.GenerateShort(date), url, 1);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Recovering from error");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    redis = ConnectionMultiplexer.Connect("devtalks");
                    db = redis.GetDatabase(0);
                }
            }

            Console.WriteLine("ready");
            Console.ReadLine();
        }
    }

    public static class DateGen
    {
        public static string GenerateShort(DateTime date)
        {
            var result = date.ToString("yyyyMMdd");

            return result;
        }

        public static string GenerateLong(DateTime date)
        {
            var result = date.ToString("yyyyMMddHHmmss");

            return result;
        }
    }
}
