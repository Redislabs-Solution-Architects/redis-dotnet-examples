using System;
using System.Text.Json;

namespace Redis.DotNet.NRedisStack.QueryParams.Extensions
{
	public static class JsonExtensions
	{
        public static List<T> DeserializeJsonList<T>(this List<string> jsonStrings)
        {
            List<T> result = new List<T>();

            foreach (string jsonString in jsonStrings)
            {
                T obj = JsonSerializer.Deserialize<T>(jsonString);
                result.Add(obj);
            }

            return result;
        }
    }
}

