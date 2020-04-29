using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleBoilerplateApi.HealthCheck
{
    public class DatabaseHealthCheck //: IHealthCheck
    {        
        //public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        //{
        //    return HealthCheckResult.Healthy();
        //}
    }
}

// You may install any of the following packages to cater your need as per databse
//Install-Package AspNetCore.HealthChecks.System
//Install-Package AspNetCore.HealthChecks.Network
//Install-Package AspNetCore.HealthChecks.SqlServer
//Install-Package AspNetCore.HealthChecks.MongoDb
//Install-Package AspNetCore.HealthChecks.Npgsql
//Install-Package AspNetCore.HealthChecks.Elasticsearch
//Install-Package AspNetCore.HealthChecks.Solr
//Install-Package AspNetCore.HealthChecks.Redis
//Install-Package AspNetCore.HealthChecks.EventStore
//Install-Package AspNetCore.HealthChecks.AzureStorage
//Install-Package AspNetCore.HealthChecks.AzureServiceBus
//Install-Package AspNetCore.HealthChecks.AzureKeyVault
//Install-Package AspNetCore.HealthChecks.Azure.IoTHub
//Install-Package AspNetCore.HealthChecks.MySql
//Install-Package AspNetCore.HealthChecks.DocumentDb
//Install-Package AspNetCore.HealthChecks.SqLite
//Install-Package AspNetCore.HealthChecks.RavenDB
//Install-Package AspNetCore.HealthChecks.Kafka
//Install-Package AspNetCore.HealthChecks.RabbitMQ
//Install-Package AspNetCore.HealthChecks.IbmMQ
//Install-Package AspNetCore.HealthChecks.OpenIdConnectServer
//Install-Package AspNetCore.HealthChecks.DynamoDB
//Install-Package AspNetCore.HealthChecks.Oracle
//Install-Package AspNetCore.HealthChecks.Uris
//Install-Package AspNetCore.HealthChecks.Aws.S3
//Install-Package AspNetCore.HealthChecks.Consul
//Install-Package AspNetCore.HealthChecks.Hangfire
//Install-Package AspNetCore.HealthChecks.SignalR
//Install-Package AspNetCore.HealthChecks.Kubernetes
//Install-Package AspNetCore.HealthChecks.Gcp.CloudFirestore
