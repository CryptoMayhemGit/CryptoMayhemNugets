using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mayhem.Util.Classes
{
    public class ErrorResponse
    {
        public List<ErrorModel> Errors { get; }

        public ErrorResponse(params ErrorModel[] errors)
        {
            Errors = errors.ToList();
        }

        public override string ToString()
        {
            if (Errors.Any())
            {
                StringBuilder stringBuilder = new();
                foreach (ErrorModel error in Errors)
                {
                    stringBuilder.Append($"{error.FieldName} - {error.Message} ");
                }

                return stringBuilder.ToString();
            }

            return base.ToString();
        }
    }
}
