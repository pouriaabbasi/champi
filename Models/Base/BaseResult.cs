using champi.Domain.Enum;

namespace champi.Models.Base
{
    public class BaseResult
    {
        public StatusCodeTypeKind Type { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}