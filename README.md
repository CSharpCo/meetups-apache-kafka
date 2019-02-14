# Demo Apache Kafka con DotNetCore

Este repositorio contiene el código de ejemplo utilizado en el Meetup de la Comunidad C# Colombia [https://www.meetup.com/es-ES/csharp-community/events/258086447/].

## Comandos Docker para montar Kafka y ZooKeeper:

### ZooKeeper (https://hub.docker.com/_/zookeeper):
```
docker image pull zookeeper
docker run -d --name zookeeper -p 2181:2181 zookeeper
```

### Kafka (https://hub.docker.com/r/ches/kafka):
```
docker image pull ches/kafka
docker run -d --name kafka -p 7203:7203 -p 9092:9092 -e KAFKA_ADVERTISED_HOST_NAME={DOCKER_IP} -e ZOOKEEPER_IP={DOCKER_IP} ches/kafka
```

### Nuget Packages:
https://github.com/confluentinc/confluent-kafka-dotnet
```
dotnet add package -v 1.0-beta2 Confluent.Kafka
````

