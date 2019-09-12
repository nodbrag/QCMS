using System;
using Xunit;
using Qcms.Core.Redis;

namespace Qcms.Redis.Tests
{
    public class UnitTest1
    {
        public UnitTest1()
        {
            RedisHelper.RedisConfig = "127.0.0.1:6379,allowAdmin=true,password=redispass";

        }
        [Fact]
        public void Test1()
        {
            RedisHelper redis = new RedisHelper(1);
            redis.Set("key3", "hahah");
            var value = redis.GetString("key3");
            Assert.True(value == "hahah");
        }
    }
}
