using Mapster;
using Pds.Contracts.Data.Common.Responses;
using Pds.Contracts.Data.Services.Models;
using DataModel = Pds.Contracts.Data.Repository.DataModels;
using ServiceModel = Pds.Contracts.Data.Services.Models;

namespace Pds.DocumentExchange.Data.Services.Mapster
{
    /// <summary>
    /// Class to extend Mapster TypeAdapterConfig to add mappings.
    /// </summary>
    public static class TypeAdapterConfigExtensions
    {
        /// <summary>
        /// Adds mappings to the TypeAdapterConfig.
        /// </summary>
        /// <param name="config">The TypeAdapter config.</param>
        /// <returns>TypeAdapterConfig.</returns>
        public static TypeAdapterConfig Configure(this TypeAdapterConfig config)
        {
            TypeAdapterConfig.GlobalSettings.AllowImplicitSourceInheritance = true;
            config.Default.PreserveReference(true);
            config.Default.AddDestinationTransform(DestinationTransform.EmptyCollectionIfNull);

            config.ForType<DataModel.Contract, ServiceModel.Contract>();

            config.ForType<DataModel.ContractContent, ServiceModel.ContractContent>();
            config.ForType<DataModel.Contract, ServiceModel.ContractReminderItem>();

            config.ForType<ServiceModel.CreateContractRequestDocument, DataModel.ContractContent>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.IdNavigation);

            config.ForType<ServiceModel.CreateContractCode, DataModel.ContractFundingStreamPeriodCode>()
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.ContractId)
                .Ignore(dest => dest.Contract);

            config.ForType<ServiceModel.CreateContractRequest, DataModel.Contract>()
                .Ignore(dest => dest.ContractData)
                .Ignore(dest => dest.Id)
                .Ignore(dest => dest.Status)
                .Ignore(dest => dest.SignedBy)
                .Ignore(dest => dest.SignedOn)
                .Ignore(dest => dest.SignedByDisplayName)
                .Ignore(dest => dest.CreatedAt)
                .Ignore(dest => dest.LastUpdatedAt)
                .Ignore(dest => dest.EmailReminder)
                .Ignore(dest => dest.WasManuallyApproved)
                .Ignore(dest => dest.LastEmailReminderSent)
                .Ignore(dest => dest.HasNotificationBeenRead)
                .Ignore(dest => dest.NotificationReadBy)
                .Ignore(dest => dest.NotificationReadAt);

            config.NewConfig<UpdatedContractStatusResponse, ContractNotification>()
                .Map(dest => dest.Status, src => src.NewStatus);

            return config;
        }
    }
}