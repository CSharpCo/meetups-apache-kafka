using System;
using Confluent.Kafka;

namespace Consumer
{
    class Program
    {
        static void Main(string[] args)
        {
            var config = new ConsumerConfig{
                GroupId = "test-consumer",
                BootstrapServers = "localhost:9092",
                AutoOffsetReset = AutoOffsetResetType.Earliest
            };
            Console.Write("Topic to suscribe in this session:");
            var topic = Console.ReadLine();
            using(var consumer = new Consumer<Ignore,string>(config)){
                consumer.Subscribe(topic);
                var consumig = true;
                consumer.OnError += (_,e) => consumig = !e.IsFatal;
                while(true){
                    try{
                        var consumeReport = consumer.Consume();
                        Console.WriteLine($"Consumed message: '{consumeReport.Value}' at: '{consumeReport.TopicPartitionOffset}'");
                    }catch(ConsumeException e){
                        Console.WriteLine($"Error: {e.Error?.Reason}");
                    }
                }
            }
        }
    }
}
