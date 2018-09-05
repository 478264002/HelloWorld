using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Prototype01
{
    /// <summary>
    /// 普通类  构造起来比较麻烦
    /// </summary>
    public class Student
    {
        public Student()//构造起来比较麻烦, 非常耗时
        {
            Thread.Sleep(2000);
            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }
            Console.WriteLine("{0}被构造..", this.GetType().Name);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public void Study()
        {
            Console.WriteLine("{0}在学习.net 设计模式特训", this.Name);
        }

    }
}
