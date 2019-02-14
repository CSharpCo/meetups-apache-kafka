using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace Producer
{
    class Program
    {
        public static ProducerConfig producerConfig => new ProducerConfig{BootstrapServers = "localhost:9092"};

        static async Task Main(string[] args)
        {

            while(true){
                RequestMessage();
                var message = Console.ReadLine();
                if(message.Equals("exit", StringComparison.InvariantCultureIgnoreCase)) break;
                await ProduceMessage(message);
            }
            Console.WriteLine("Bye!");
        }

        public static async Task ProduceMessage(string message){

            using(var producer = new Producer<Null,string>(producerConfig)){
                try{
                    var deliveryReport = await producer.ProduceAsync("topic-demo",new Message<Null, string>{Value = message});
                    Console.WriteLine($"Delivered message: '{deliveryReport.Value}' to '{deliveryReport.TopicPartitionOffset}'");                        
                }catch(KafkaException e){
                    await Console.Error.WriteAsync($"Error: {e.Error?.Reason}");
                }
            }
        }

    public static void RequestMessage(){
        Console.Write("Write next message:");
    }

    }
}
