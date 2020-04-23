using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using CachingSolutionsSamples.Managers;
using CachingSolutionsSamples.Service;
using Microsoft.Extensions.Caching.Redis;
using NorthwindLibrary;

namespace CachingSolutionsSamples
{
	[TestClass]
	public class CacheTests
	{
		[TestMethod]
		public void MemoryCache()
		{
			var categoryManager = new EntitiesManager(new MyMemoryCache());

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(categoryManager.GetItems<Category>().Count());
				Thread.Sleep(100);
			}
		}

		[TestMethod]
		public void RedisCache()
		{
			var categoryManager = new EntitiesManager(new MyRedisCache(new RedisCacheOptions
            {
				Configuration = "localhost:6379",
				InstanceName = "Sample"
			}));

			for (var i = 0; i < 10; i++)
			{
				Console.WriteLine(categoryManager.GetItems<Category>().Count());
				Thread.Sleep(100);
			}
		}
	}
}
