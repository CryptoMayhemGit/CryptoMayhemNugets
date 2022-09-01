namespace Mayhem.Util.Exceptions
{
    public class ValidationMessage
    {
        public ValidationMessage(string fieldName, string message, params object[] messageParams)
        {
            FieldName = fieldName;
            Message = message;
            Params = messageParams;
        }

        public string FieldName { get; set; }

        public string Message { get; set; }

        public object[] Params { get; set; }

        public override string ToString()
        {
            return $"{FieldName}: {string.Format(Message, Params)}";
        }
    }
}
