using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Prototype01
{
    /// <summary>
    /// 二进制序列化帮助类
    /// </summary>
    public class SerializeHelper
    {
        /// <summary>
        /// 序列化对象
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static string Serializable(object target)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                new BinaryFormatter().Serialize(stream, target);

                return Convert.ToBase64String(stream.ToArray());
            }
        }

        /// <summary>
        /// 反序列化对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="target"></param>
        /// <returns></returns>
        public static T Derializable<T>(string target)
        {
            byte[] targetArray = Convert.FromBase64String(target);

            using (MemoryStream stream = new MemoryStream(targetArray))
            {
                return (T)(new BinaryFormatter().Deserialize(stream));
            }
        }

        /// <summary>
        /// 深克隆对象
        /// </summary>
        /// <typeparam name="T">要深克隆类   注意:类型必须标记为可序列化</typeparam>
        /// <param name="t">要深克隆的对象</param>
        /// <returns></returns>
        public static T DeepClone<T>(T t)
        {
            return Derializable<T>(Serializable(t));
        }
    }
}
