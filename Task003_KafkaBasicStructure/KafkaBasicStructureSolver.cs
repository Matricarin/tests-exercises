using System.Text.Json;
using Confluent.Kafka;

namespace Task003_KafkaBasicStructure;

public static class KafkaBasicStructureSolver
{
    private const string Topic = "orders-topic";
    private const string ServiceName = "orders-processig-service";
    private const string ServersAddress = "some_server:9092";

    public static async Task SendOrderMessageAsync(string orderId, string status, CancellationToken token)
    {
        var config = new ProducerConfig
        {
            BootstrapServers = ServersAddress
        };

        var message = JsonSerializer.Serialize(new { OrderOd = orderId, Status = status });

        using (var producer = new ProducerBuilder<Null, string>(config).Build())
        {
            var result = await producer.ProduceAsync(Topic, new Message<Null, string>
            {
                Value = message
            }, token);
        }
    }

    public static void StartConsuming(CancellationToken token)
    {
        var config = new ConsumerConfig
        {
            BootstrapServers = ServersAddress,
            GroupId = ServiceName,
            EnableAutoCommit = false
        };

        using (var consumer = new ConsumerBuilder<Ignore, string>(config).Build())
        {
            consumer.Subscribe(Topic);

            while (!token.IsCancellationRequested)
            {
                var consumeResult = consumer.Consume(token);

                Console.WriteLine(consumeResult.Message.Value);

                consumer.Commit(consumeResult);
            }

            consumer.Close();
        }
    }
}