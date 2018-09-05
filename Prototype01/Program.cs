using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Prototype01
{
    /// <summary>
    /// 1 单例模式/原型模式
    /// 2 浅克隆VS深克隆
    /// 3 原型模式的应用
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                #region ---性能测试---
                //Console.WriteLine("********普通***********");
                //for (int i = 0; i < 5; i++)
                //{
                //    Student student = new Student();
                //    student.Study();
                //}

                //Console.WriteLine("*********单例模式**********");
                //for (int i = 0; i < 5; i++)
                //{
                //    Stopwatch stopwatch = Stopwatch.StartNew();
                //    StudentSingleton student = StudentSingleton.CreateInstance();
                //    student.Study();
                //    Console.WriteLine("花费时间: {0}", stopwatch.ElapsedMilliseconds);
                //}

                //Console.WriteLine("*********原型模式**********");
                //for (int i = 0; i < 5; i++)
                //{
                //    Stopwatch stopwatch = Stopwatch.StartNew();
                //    StudentPrototype student = StudentPrototype.CreateInstance();
                //    student.Study();
                //    Console.WriteLine("花费时间: {0}", stopwatch.ElapsedMilliseconds);
                //}

                #endregion

                #region ---单例的限制--------------------,使用原型模式解决些问题      
                //Console.WriteLine("*********单例的限制**********");
                //{
                //    StudentSingleton student1 = StudentSingleton.CreateInstance();
                //    StudentSingleton student2 = StudentSingleton.CreateInstance();
                //    student1.Id = 506;
                //    student1.Name = "YOYO";
                //    Console.WriteLine("student1 Id {0} Name {1}", student1.Id, student1.Name);
                //    Console.WriteLine("student2 Id {0} Name {1}", student2.Id, student2.Name);
                //}

                //Console.WriteLine("*********原型模式,解决单例的这种限制**********");
                //{
                //    StudentPrototype student1 = StudentPrototype.CreateInstance();
                //    StudentPrototype student2 = StudentPrototype.CreateInstance();
                //    student1.Id = 999;
                //    student1.Name = "生存能力";
                //    Console.WriteLine("student1 Id {0} Name {1}", student1.Id, student1.Name);
                //    Console.WriteLine("student2 Id {0} Name {1}", student2.Id, student2.Name);
                //}
                #endregion

                #region ---浅克隆VS深克隆---
                //Console.WriteLine("*********浅克隆/深克隆**********");
                //{
                //    StudentPrototype student1 = StudentPrototype.CreateInstance();
                //    StudentPrototype student2 = StudentPrototype.CreateInstance();
                //    student1.Id = 999;
                //    student1.Name = "生存能力";//== new String("生存能力")
                //    Console.WriteLine("student1 Id {0} Name {1} cLass.Remark {2}", student1.Id, student1.Name, student1.cLass.Remark);
                //    Console.WriteLine("student2 Id {0} Name {1} cLass.Remark {2}", student2.Id, student2.Name, student2.cLass.Remark);

                //    ////直接在原值上修改,
                //    student1.cLass.Num = 2;
                //    student1.cLass.Remark = "C++ 班";

                //    //以下这样赋值就不会被覆盖, 这时因为(new)开辟了一个新的内存空间, 新实例化了新的对象
                //    //student1.cLass = new CLass() { Num = 3, Remark = "PhonShop 班" };

                //    Console.WriteLine("student1.cLass.Num {0} cLass.Remark {1}", student1.cLass.Num, student1.cLass.Remark);
                //    Console.WriteLine("student2.cLass.Num {0} cLass.Remark {1}", student2.cLass.Num, student2.cLass.Remark);
                //}


                //Console.WriteLine("*********深克隆方法二: 使用二进制序列化方式**********");
                //{
                //    StudentPrototype student1 = StudentPrototype.CreateInstanceSerial();
                //    StudentPrototype student2 = StudentPrototype.CreateInstanceSerial();
                //    student1.Id = 999;
                //    student1.Name = "生存能力";
                //    Console.WriteLine("student1 Id {0} Name {1} cLass.Remark {2}", student1.Id, student1.Name, student1.cLass.Remark);
                //    Console.WriteLine("student2 Id {0} Name {1} cLass.Remark {2}", student2.Id, student2.Name, student2.cLass.Remark);

                //    ////直接在原值上修改,
                //    student1.cLass.Num = 2;
                //    student1.cLass.Remark = "C++ 班";
                //    Console.WriteLine("student1.cLass.Num {0} cLass.Remark {1}", student1.cLass.Num, student1.cLass.Remark);
                //    Console.WriteLine("student2.cLass.Num {0} cLass.Remark {1}", student2.cLass.Num, student2.cLass.Remark);
                //}



                #endregion


                #region ---性能再测试---

                Console.WriteLine("*********深克隆,方式一**********");
                for (int i = 0; i < 5; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    StudentPrototype student = StudentPrototype.CreateInstance();
                    student.Study();
                    Console.WriteLine("花费时间: {0}",stopwatch.ElapsedMilliseconds);
                }

                Console.WriteLine("*********深克隆,方式二**********");
                for (int i = 0; i < 5; i++)
                {
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    StudentPrototype student = StudentPrototype.CreateInstanceSerial();
                    student.Study();
                    Console.WriteLine("花费时间: {0}", stopwatch.ElapsedMilliseconds);
                }



                #endregion




            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.Read();
        }
    }
}
