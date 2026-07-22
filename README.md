# Manage Your Education and Skills Funding Contracts Data API

The Manage Your Education and Skills Funding (MYESF) Contracts Data API is used by the MYESF web application and contract event processor azure function to allow the following:

- Provides a contract, content, and document administration service.
- Fetches the complete subcontractor declaration.

## Provider

[The Department for Education](https://www.gov.uk/government/organisations/department-for-education)

## About this project

This project is an ASP.NET Core 6 web application utilising Azure App Service for deployment.

The web application runs on an Azure App service on Azure.

**Note:** The project is currently being updated to be containerised via Docker where the deployment method and target will change, this document will be updated when these changes have been finalised.

# Local Configuration Guide

In order to run the application locally a valid `appsettings.json` file will need to be created in the `Pds.Contracts.Data.Api` project. Below, and included in the repo, there is `appsettings.example.json` which can be used as a base and populated with the required values, which can be retrieved from the Azure Portal.

## Application Settings (`appsettings.json`)

```json
{
  "PdsApplicationInsights": {
    "InstrumentationKey": "",
    "Environment": "local"
  },
  "Logging": {
    "ApplicationInsights": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft": "Error"
      }
    },
    "LogLevel": {
      "Default": "Information"
    }
  },
  "AllowedHosts": "*",
  "AzureAd": {
    "Instance": "https://login.microsoftonline.com/",
    "TenantId": "",
    "ClientId": "",
    "Audience": ""
  },
  "ConnectionStrings": {
    "contracts": ""
  },
  "AuditApiConfiguration": {
    "ApiBaseAddress": "",
    "Authority": "",
    "ClientId": "",
    "ClientSecret": "",
    "TenantId": "",
    "AppUri": ""
  },
  "AzureBlobConfiguration": {
    "ConnectionString": "",
    "ContainerName": "",
    "RetryCount": 3,
    "Delay": ""
  },
  "HttpPolicyOptions": {
    "HttpRetryCount": 3,
    "HttpRetryBackoffPower": 2,
    "CircuitBreakerToleranceCount": 5,
    "CircuitBreakerDurationOfBreak": ""
  },
  "NotificationTopicSBOptions": {
    "ServiceBusConnectionString": "",
    "TopicName": "",
    "RetryCount": 3,
    "MinimumBackoff": "",
    "MaximumBackoff": ""
  }
}
```

### Setting Details

- **`PdsApplicationInsights:InstrumentationKey`**  
  The key value for Application Insights resource for logging purposes.

- **`PdsApplicationInsights:Environment`**  
  The environment which the app is running on for Application Insights for logging purposes.

- **`Logging:ApplicationInsights:LogLevel:Default`**
  The default logging level for the service when logging to Application Insights; refer to the [Microsoft Documentation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=net-9.0-pp) for an explanation of the different levels.

- **`Logging:ApplicationInsights:LogLevel:Microsoft`**
  The default logging level for Microsoft specific information when logging to Application Insights; refer to the [Microsoft Documentation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=net-9.0-pp) for an explanation of the different levels.

- **`Logging:LogLevel:Default`**
  The default logging level for the service; refer to the [Microsoft Documentation](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.logging.loglevel?view=net-9.0-pp) for an explanation of the different levels.

- **`AllowedHosts`** 
  The configuration setting used by web frameworks and development tools to restrict incoming HTTP requests based on the HTTP Host header. It serves as a shield against HTTP Host header attacks and DNS rebinding exploits.

- **`AzureAd:Audience`**  
  The intended recipient of the azure authentication token.
 
- **`AzureAd:ClientId`**  
  The application (client) ID registered in azure ad.

- **`AzureAd:Instance`**  
  The URL of the azure ad service used to authenticate.

- **`AzureAd:TenantId`**  
  The unique identifier for your azure ad tenant.

- **`ConnectionStrings:contracts`**  
  The database connection configuration used by the application to access the contracts database.

- **`AuditApiConfiguration:ApiBaseAddress`** 
  The base URL endpoint used by a client application to route network requests to the Audit API backend.

- **`AuditApiConfiguration:Authority`** 
  The base URL of the Identity Provider responsible for authenticating and issuing tokens for the Audit API client.

- **`AuditApiConfiguration:ClientId`** 
  The Audit API application (client) ID registered in azure ad.

- **`AuditApiConfiguration:ClientSecret`** 
  The confidential credential used by the Audit API application to securely prove its identity to the Identity Provider.

- **`AuditApiConfiguration:TenantId`** 
  The unique identifier for your azure ad tenant.

- **`AuditApiConfiguration:AppUri`** 
  The unique Application ID URI used as the identifier for the protected Audit API resource within the Identity Provider.

- **`AzureBlobConfiguration:ConnectionString`** 
  The connection string used by the application to authenticate and connect to the Azure Blob Storage account.

- **`AzureBlobConfiguration:ContainerName`**
  The name of the specific Azure Blob Storage container where the application uploads, reads, or manages files.

- **`AzureBlobConfiguration:RetryCount`** 
  The maximum number of times the storage client will attempt to re-execute a failed operation (such as uploading or downloading a blob) when a transient error occurs.

- **`AzureBlobConfiguration:Delay`** 
  The amount of time the storage client waits before making its first retry attempt following a transient operation failure.

- **`HttpPolicyOptions:HttpRetryCount`** 
  The number of times that the Http client would automatically resend failed Http requests.

- **`HttpPolicyOptions:HttpRetryBackoffPower`** 
  The handler lifetime in minutes to limit exponential backoff for retrying Http requests.

- **`HttpPolicyOptions:CircuitBreakerToleranceCount`** 
  The limited number of failed requests the circuit breaker will tolerate before beginning a time-out timer.

- **`HttpPolicyOptions:CircuitBreakerDurationOfBreak`** 
  The duration in seconds the circuit breaker remains open before transitioning to a half-open state for re-evaluation.

- **`NotificationTopicSBOptions:ServiceBusConnectionString`** 
  The connection string used by the application to authenticate and connect to the Azure Service Bus namespace.

- **`NotificationTopicSBOptions:TopicName`** 
  The specific topic name where notification messages are published or consumed.

- **`NotificationTopicSBOptions:RetryCount`** 
  The maximum number of times the application will attempt to re-send or re-process a message over the Azure Service Bus if a transient error occurs.

- **`NotificationTopicSBOptions:MinimumBackoff`** 
  The minimum duration of time the application waits before making its first retry attempt following a transient failure.

- **`NotificationTopicSBOptions:MaximumBackoff`**
  The maximum duration of time allowed between retry attempts during transient failures.
  
## Test execution

In order to test the application locally a valid `appsettings.development.json` file will need to be created in the projects (`Pds.Contracts.Data.Api.Tests`, `Pds.Contracts.Data.Services.Tests`). `appsettings.development.example.json`, in the projects can be used as a base and populated with appropriate values which can be found in Azure Portal.

## Test Application Settings (`appsettings.development.json`)

```json
{
  "AzureBlobConfiguration": {
    "ConnectionString": "",
    "ContainerName": "",
    "RetryCount": 3,
    "Delay": ""
  },
  "AuditApiConfiguration": {
    "ApiBaseAddress": "",
    "Authority": "",
    "ClientId": "",
    "ClientSecret": "",
    "TenantId": "",
    "AppUri": ""
  },
  "NotificationTopicSBOptions": {
    "ServiceBusConnectionString": "",
    "TopicName": "",
    "RetryCount": 3,
    "MinimumBackoff": "",
    "MaximumBackoff": ""
  }
}
```

### Setting Details

- **`AzureBlobConfiguration:ConnectionString`** 
  The connection string used by the application to authenticate and connect to the Azure Blob Storage account. (Use `pdsiexcosmoslocal`)

- **`AzureBlobConfiguration:ContainerName`**
  The name of the specific Azure Blob Storage container where the application uploads, reads, or manages files. Always use `testdata`

- **`AzureBlobConfiguration:RetryCount`** 
  The maximum number of times the storage client will attempt to re-execute a failed operation (such as uploading or downloading a blob) when a transient error occurs.

- **`AzureBlobConfiguration:Delay`** 
  The amount of time the storage client waits before making its first retry attempt following a transient operation failure. 
  
- **`AuditApiConfiguration:ApiBaseAddress`** 
  The base URL endpoint used by a client application to route network requests to the Audit API backend.

- **`AuditApiConfiguration:Authority`** 
  The base URL of the Identity Provider responsible for authenticating and issuing tokens for the Audit API client.

- **`AuditApiConfiguration:ClientId`** 
  The Audit API application (client) ID registered in azure ad.

- **`AuditApiConfiguration:ClientSecret`** 
  The confidential credential used by the Audit API application to securely prove its identity to the Identity Provider.

- **`AuditApiConfiguration:TenantId`** 
  The unique identifier for your azure ad tenant.

- **`AuditApiConfiguration:AppUri`** 
  The unique Application ID URI used as the identifier for the protected Audit API resource within the Identity Provider.
  
 - **`NotificationTopicSBOptions:ServiceBusConnectionString`** 
  The connection string used by the application to authenticate and connect to the Azure Service Bus namespace.

- **`NotificationTopicSBOptions:TopicName`** 
  The specific topic name where notification messages are published or consumed.

- **`NotificationTopicSBOptions:RetryCount`** 
  The maximum number of times the application will attempt to re-send or re-process a message over the Azure Service Bus if a transient error occurs.

- **`NotificationTopicSBOptions:MinimumBackoff`** 
  The minimum duration of time the application waits before making its first retry attempt following a transient failure.

- **`NotificationTopicSBOptions:MaximumBackoff`**
  The maximum duration of time allowed between retry attempts during transient failures.
  
## Build and Test

To build and test locally, you can either use Visual Studio, Visual Studio Code or simply use dotnet CLI `dotnet build` and `dotnet test` more information in dotnet CLI can be found at <https://docs.microsoft.com/en-us/dotnet/core/tools/>.

## Contribute

To contribute,

- If you are part of the team then create a branch for changes and then submit your changes for review by creating a pull request.
- If you are external to the organisation then fork this repository and make necessary changes and then submit your changes for review by creating a pull request.
  