using NRedisStack.Search.Literals.Enums;
using NRedisStack.Search;
using NRedisStack;
using StackExchange.Redis;
using NRedisStack.RedisStackCommands;

var user1 = new
{
    name = "Paul John",
    email = "paul.john@example.com",
    age = 42,
    city = "London"
};

var user2 = new
{
    name = "Eden Zamir",
    email = "eden.zamir@example.com",
    age = 29,
    city = "Tel Aviv"
};

var user3 = new
{
    name = "Paul Zamir",
    email = "paul.zamir@example.com",
    age = 35,
    city = "Tel Aviv"
};
var schema = new Schema()
    .AddTextField(new FieldName("$.name", "name"))
    .AddTagField(new FieldName("$.city", "city"))
    .AddNumericField(new FieldName("$.age", "age"));
ConfigurationOptions options = new ConfigurationOptions
{
    //list of available nodes of the cluster along with the endpoint port.
    EndPoints = {
        { "localhost", 16379 },
        { "localhost", 16380 },
        // ...
    },
};

ConnectionMultiplexer cluster = ConnectionMultiplexer.Connect(options);
IDatabase db = cluster.GetDatabase();
ISearchCommands ft = db.FT();
ft.Create(
    "idx:users",
    new FTCreateParams().On(IndexDataType.JSON).Prefix("user:"),
    schema);