using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prototype01
{
    /// <summary>
    /// 原型类 
    /// 原型模式: 1)和(上面)单例类 一样, 只是在CreateInstance()方法中使用MemberwiseClone()方法创建克隆对象.
    ///	2)浅克隆: 引用类型只会克隆地址(所有引用类型直接赋值会有影响, 必须使用new 的方法重新产生对象方式)
    ///	3)深克隆: 方法一: 在CreateInstance()方法中浅克隆之后对所有引用类型(除字符串)使用new 创建对象
    ///        方法二: 使用二进制序列化方式: 把所有对象标记为可序列化[Serializable]

    ///使用场景: 1)当构造对象时比较麻烦,非常耗时,(需要创建重复的对象) 而他们的区别只是某些属性(ID/Name等等)的区别
    ///	2)备忘录模式, 备忘前先克隆;
    ///	3)(按需更新)只更新更改的字段: 数据库更新前先克隆, 把克隆的拿去修改,再对比哪些被修改了.
    ///	4)回滚需求: 使用前先克隆, 更新后当需要回滚时
    /// </summary>
    [Serializable]
    public class StudentPrototype
    {
        private StudentPrototype()//构造起来比较麻烦, 非常耗时
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

        private static StudentPrototype _StudentPrototype = null;

        static StudentPrototype()
        {
            _StudentPrototype = new StudentPrototype()
            {
                Id = 337,
                Name = "歌神",
                cLass = new CLass() { Num = 1, Remark = "高级班" }
            };
        }

        public static StudentPrototype CreateInstance()
        {
            StudentPrototype studentPrototypes = (StudentPrototype)_StudentPrototype.MemberwiseClone();//这种是浅克隆(默认)
            // 深克隆: 方法一: 在CreateInstance()方法中浅克隆之后对所有引用类型(除字符串)使用new 创建对象
            studentPrototypes.cLass = new CLass() { Num = 1, Remark = "高级班" };//这样就是深克隆

            return studentPrototypes;
        }

        /// <summary>
        /// 深克隆: 方法二: 使用二进制序列化方式: 把所有对象标记为可序列化[Serializable]
        /// </summary>
        /// <returns></returns>
        public static StudentPrototype CreateInstanceSerial()
        {
            return SerializeHelper.DeepClone<StudentPrototype>(_StudentPrototype);
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public CLass cLass { get; set; }
        public void Study()
        {
            Console.WriteLine("{0}在学习.net高级班公开课之设计模式特训", this.Name);
        }
    }
}
