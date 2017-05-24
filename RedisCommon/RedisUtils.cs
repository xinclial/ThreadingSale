using RedisCommon.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisCommon
{
    public static class RedisUtils
    {
        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <param name="value">值</param>
        /// <returns>true:成功，false:失败</returns>
        public static bool Add<T>(string strKey, int DefaultDb, T value)
        {
            var isSuccess = false;
            using (var redisClient = RedisManager.GetClient(DefaultDb))
            {
                isSuccess = redisClient.Add<T>(strKey, value);
            }

            return isSuccess;
        }


        /// <summary>
        /// 添加缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <param name="value">值</param>
        /// <param name="tspan">过期时间</param>
        /// <returns>true:成功，false:失败</returns>
        public static bool Add<T>(string strKey, int DefaultDb, T value, TimeSpan tspan)
        {
            var isSuccess = false;
            using (var redisClient = RedisManager.GetClient(DefaultDb))
            {
                isSuccess = redisClient.Add<T>(strKey, value, tspan);
            }

            return isSuccess;
        }



        /// <summary>
        /// 覆盖同一key值缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <param name="value">值</param>
        /// <returns>true:成功，false:失败</returns>
        public static bool Set<T>(string strKey, int DefaultDb, T value)
        {
            var isSuccess = false;
            using (var redisClient = RedisManager.GetClient(DefaultDb))
            {
                isSuccess = redisClient.Set<T>(strKey, value);
            }

            return isSuccess;
        }


        /// <summary>
        /// 覆盖同一key值缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <param name="value">值</param>
        /// <param name="tspan">过期时间</param>
        /// <returns>true:成功，false:失败</returns>
        public static bool Set<T>(string strKey, int DefaultDb, T value, TimeSpan tspan)
        {
            var isSuccess = false;
            using (var redisClient = RedisManager.GetClient(DefaultDb))
            {
                isSuccess = redisClient.Set<T>(strKey, value, tspan);
            }

            return isSuccess;
        }


        /// <summary>
        /// 获取缓存
        /// </summary>
        /// <typeparam name="T">要返回的数据类型</typeparam>
        /// <param name="strKey">键</param>
        /// <returns>返回键对应的值，不存在则返回NULL</returns>
        public static T Get<T>(string strKey, int DefaultDb)
        {
            using (var redisClient = RedisManager.GetClient(DefaultDb))
            {
                return redisClient.Get<T>(strKey);
            }
        }


        /// <summary>
        /// 移除指定键的缓存
        /// </summary>
        /// <param name="strKey">键</param>
        /// <returns>true | false</returns>
        public static bool Remove(string strKey, int DefaultDb)
        {
            var isSuccess = false;
            using (var redisClient = RedisManager.GetClient(DefaultDb))
            {
                isSuccess = redisClient.Remove(strKey);
            }

            return isSuccess;
        }



    }
}
