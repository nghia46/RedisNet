using StackExchange.Redis;

class Program
{
    static void Main(string[] args)
    {
        // Connection string
        string redisConnectionString = "localhost:6379";

        try
        {
            using (ConnectionMultiplexer redis = ConnectionMultiplexer.Connect(redisConnectionString))
            {
                IDatabase db = redis.GetDatabase();

                // Set values
                db.StringSet("key1", "Hello World");
                db.StringSet("key2", "1");
                db.StringSet("key1", "Hello World");
                db.StringSet("key2", "1");
                db.StringSet("key1", "Hello World");
                db.StringSet("key2", "1");
                // Get values
                IEnumerable<RedisKey> keys = redis.GetServer(redisConnectionString).Keys();

                // Print all keys and values
                foreach (var key in keys)
                {
                    string? value = db.StringGet(key);
                    Console.WriteLine($"Key: {key}, Value: {value}");
                }
            }
        }
        catch
        {
            Console.WriteLine("Error in connection");

        }
    }
}
