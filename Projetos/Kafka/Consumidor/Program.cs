using Confluent.Kafka;
using Confluent.Kafka.SyncOverAsync;
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

var config = new ConsumerConfig
{
    GroupId = "devIo",
    BootstrapServers = "localhost:9092"
};

using var consumer = new ConsumerBuilder<string, curso>(config)
    .SetValueDeserializer(new AvroDeserializer<curso>(schemaregistry)
    .AsSyncOverAsync()).Build();

consumer.Subscribe("Cursos");

while (true)
{
    var result = consumer.Consume();
    Console.WriteLine($"{result.Message.Key} - {result.Message.Value.Descricao}");
}