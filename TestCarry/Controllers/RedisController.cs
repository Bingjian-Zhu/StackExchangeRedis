using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestCarry.BaseClass;
using TestCarry.StackExchangeRedis;

namespace TestCarry.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedisController : ControllerBase
    {
        /// <summary>
        /// 设置string的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult SetStr(string key,string value)
        {
            //TimeSpan timeSpan = new TimeSpan();
            RedisHelper redis = new RedisHelper();
            var res = redis.StringSet(key, value, null);
            return Ok(res);
        }

        /// <summary>
        /// 获取key的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        [HttpGet("GetKey")]
        public IActionResult GetStr(string key)
        {
            RedisHelper redis = new RedisHelper();
            var res = redis.StringGet(key);
            return Ok(res);
        }

        [HttpDelete]
        public IActionResult Delete(string key)
        {
            RedisHelper redis = new RedisHelper();
            var res = redis.KeyDelete(key);
            return Ok(res);
        }

        [HttpGet("SetHash")]
        public IActionResult SetHash(string key,string dataKey)
        {
            User user = new User();
            user.ID = Guid.NewGuid().ToString();
            user.name = "admin";
            RedisHelper redis = new RedisHelper();
            var res = redis.HashSet(key,dataKey, user);
            return Ok(res);
        }

        [HttpGet("GetHash")]
        public IActionResult GetHash(string key,string dataKey)
        {
            RedisHelper redis = new RedisHelper();
            var res = redis.HashGet<User>(key, dataKey);
            return Ok(res);
        }

        [HttpGet("GetHashs")]
        public IActionResult GetHashs(string key)
        {
            RedisHelper redis = new RedisHelper();
            var res = redis.HashKeys<User>(key);
            return Ok(res);
        }
    }
}