using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prototype01
{
    /// <summary>
    /// 单例类
    /// 构造函数不再公开,提供一个静态的私有变量, 在静态构造函数中去初始化它,
    /// 对外提供一个静态的 获取方法CreateInstance()
    /// 
    /// 单例的限制:
    /// </summary>
    public class StudentSingleton
    {
        private StudentSingleton()//构造起来比较麻烦, 非常耗时---------构造函数不再公开
        {
            Thread.Sleep(1000);//耗时
            long lResult = 0;
            for (int i = 0; i < 100000000; i++)
            {
                lResult += i;
            }
            string bigSize = "占用10M内存";//耗计算资源
            string resource = "占用多个线程和数据库连接资源";//耗有限资源
            Console.WriteLine("{0}被构造，线程id={1}", this.GetType().Name, Thread.CurrentThread.ManagedThreadId);
        }
        private static StudentSingleton _StudentSingleton = null;//提供一个静态的私有变量
        static StudentSingleton()//在静态构造函数中去初始化它,
        {
            _StudentSingleton = new StudentSingleton()
            {
                Id = 479,
                Name = "悠悠吾心"
            };
        }
        public static StudentSingleton CreateInstance()//对外提供一个静态的 获取方法
        {
            return _StudentSingleton;
        }


        public int Id { get; set; }
        public string Name { get; set; }
        public void Study()
        {
            Console.WriteLine("{0}在学习.net高级班公开课之设计模式特训", this.Name);
        }

    }
}
