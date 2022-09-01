using Mayhem.Util.Classes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mayhem.Util.Exceptions
{
    public class NotFoundException : Exception
    {
        public ErrorResponse ErrorResponse => ValidationMessages.Any() ?
            new ErrorResponse(ValidationMessages.Select((vm) =>
                new ErrorModel(vm.FieldName, vm.Message)).ToArray()
            ) :
            null;

        public List<ValidationMessage> ValidationMessages { get; set; } = new List<ValidationMessage>();

        public NotFoundException()
        {
        }

        public NotFoundException(ValidationMessage validationMessage)
            : base(validationMessage.ToString())
        {
            ValidationMessages = new List<ValidationMessage> { validationMessage };
        }

        public NotFoundException(List<ValidationMessage> validationMessages)
            : base(string.Join(',', validationMessages.Select(vm => vm.ToString())))
        {
            ValidationMessages = validationMessages;
        }

        public NotFoundException(ValidationMessage validationMessage, Exception innerException)
            : base(string.Format(validationMessage.Message, validationMessage.Params), innerException)
        {
            ValidationMessages = new List<ValidationMessage> { validationMessage };
        }
    }
}
