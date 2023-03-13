using Confluent.Kafka;
using Confluent.SchemaRegistry;
using Confluent.SchemaRegistry.Serdes;
using cursokafka;

//Servidor do Schema Regsitry
var schemaConfig = new SchemaRegistryConfig
{
    Url = "http://localhost:8081"
};

//classe de cnfiguração para não precisar bater sempre no servidor do schema registry aumentando o desempenho da aplicação
var schemaregistry = new CachedSchemaRegistryClient(schemaConfig);

var config = new ProducerConfig { BootstrapServers = "localhost:9092" };

//Produz uma mensagem do kafka do tipo curso
using var producer = new ProducerBuilder<string, curso>(config)
    .SetValueSerializer(new AvroSerializer<curso>(schemaregistry))
    .Build();

var message = new Message<string, curso>()
{
    Key = Guid.NewGuid().ToString(),
    Value = new curso
    {
        Id = Guid.NewGuid().ToString(),
        Descricao = "Primeiro objeto avro no kafka"
    }
};

var result = await producer.ProduceAsync("Cursos", message);

Console.WriteLine($"{result.Offset} - {result.TopicPartition}");
Console.ReadKey();