using System.Collections.Generic;

namespace Mayhem.Queue.Dto
{
    public class TransferQueueMessage
    {
        public List<TransferQueueDto> Dtos;
    }

    public class TransferQueueDto
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Value { get; set; }
    }
}
