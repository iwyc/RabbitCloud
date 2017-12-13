﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rabbit.Cloud.Serialization.Json;
using Rabbit.Cloud.Serialization.MessagePack;
using Rabbit.Cloud.Serialization.Protobuf;

namespace Rabbit.Cloud.Starter
{
    public class SerializerBootstrap
    {
        public static void Start(IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.Configure<RabbitCloudOptions>(o =>
                    o.Serializers
                        .AddProtobufSerializer()
                        .AddMessagePackSerializer()
                        .AddJsonSerializer());
            });
        }
    }
}