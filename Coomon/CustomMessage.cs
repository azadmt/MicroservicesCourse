using System;
using System.Text;
using System.Text.Json;

namespace Common
{
    public class CustomMessage
    {
        public int Code { get; set; }
        public string Content { get; set; }

        public byte[] ToBytes() => Encoding.UTF8.GetBytes(this.ToJson());

        public string ToJson()
        {
            return JsonSerializer.Serialize(
                this,
                new JsonSerializerOptions { WriteIndented = true });
        }



        public static CustomMessage FromBytes(byte[] tradeAsBytes)
        {
            var message = Encoding.UTF8.GetString(tradeAsBytes) ?? string.Empty;
            return JsonSerializer.Deserialize<CustomMessage>(message) ??
                throw new Exception(
                    $"Deserialize Exceptin -from :{nameof(tradeAsBytes)} {tradeAsBytes.GetType().Name} - to :{typeof(CustomMessage).Name}");
        }
    }
}
