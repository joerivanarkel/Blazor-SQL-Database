using System.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Common.Models;

namespace ProcessService.ProcessClasses
{
    public class BaseProcess
    {
        public async Task<bool> Process()
        {
            var timer = new System.Timers.Timer(10000);
            timer.Elapsed += OnTimedEvent;
            timer.AutoReset = true;
            timer.Enabled = true;
            return true;
        }

        protected virtual void OnTimedEvent(Object source, ElapsedEventArgs e)
        { }

        protected string RandomString()
        {
            var name = string.Empty;
            var random = new Random();
            for (int i = 0; i < 6; i++)
            {
                var randomChar = (char)random.Next('a', 'z');
                name = name + randomChar;
            }
            return name;
        }

        protected int RamdomInt(int firstInt = 0, int secondInt = 1000)
        {
            Random random = new Random();
            return random.Next(firstInt, secondInt);
        }

        protected T RandomEnum<T>()
        {
            Array values = Enum.GetValues(typeof(T));
            Random random = new Random();
            return (T)values.GetValue(random.Next(values.Length));
        }

        protected bool RandomBool()
        {
            var random = new Random();
            var randomBool = random.Next(1, 2);
            return Convert.ToBoolean(randomBool);
        }
    }
}