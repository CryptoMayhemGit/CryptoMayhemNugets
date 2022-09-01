using System.Collections.Generic;
using System.Net;

namespace Mayhem.Util.Classes
{
    public class ActionDataResult<T>
    {
        public T Result { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
        public List<ErrorModel> Errors { get; set; }
    }
}
