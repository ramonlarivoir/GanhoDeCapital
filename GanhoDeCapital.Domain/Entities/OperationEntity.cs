using Newtonsoft.Json;

namespace GanhoDeCapital.Domain.Entities
{
    public class OperationEntity
    {
        [JsonProperty("operation")]
        public string Operation { get; set; }

        [JsonProperty("unit-cost")]
        public decimal UnitCost { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
