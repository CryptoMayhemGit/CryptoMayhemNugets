namespace Mayhem.Util.Classes
{
    public class ErrorModel
    {
        public string FieldName { get; }

        public string Message { get; }

        public ErrorModel(string fieldName, string message)
        {
            FieldName = fieldName;
            Message = message;
        }
    }
}
