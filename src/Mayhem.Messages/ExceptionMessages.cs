using Mayhem.Util.Exceptions;
using System;

namespace Mayhem.Messages
{
    public class ExceptionMessages
    {
        public static InvalidOperationException AzureConfigurationRequiredException => new("Azure configuration is required.");
        public static InvalidOperationException AzureConfigurationHasNoKeysException(string sectionName) => new($"Azure configuration has no keys for {sectionName}.");
        public static InvalidOperationException MissingSectionConfigurationFileException(string sectionName) => new($"Missing section {sectionName} in configuration file/files.");

        public static InternalException TransactionException(Exception ex, string transactionName) => new($"Something went wrong with transaction {transactionName}.", ex);
        public static InternalException PublishException(Exception ex) => new($"Something went wrong with publish message.", ex);

        public static ArgumentException EmptyQueueMessageException => new($"Message has null or empty body.");

        public static NotFoundException CannotGenerateTokenException(string wallet) => new(ValidationMessages.CannotGenerateTokenMessage(wallet));

        public static Exception ContractNotFoundException => new("Contract not found.");
        public static Exception MissingConfigurationTypeException => new("Missing configuration type! Need to add.");
        public static Exception CannotGetDataException => new("Cannot get data.");
        public static Exception EnumOutOfRangeException(string message) => new($"Enum out of range - {message}.");
    }
}
