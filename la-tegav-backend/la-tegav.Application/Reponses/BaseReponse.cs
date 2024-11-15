using System.Text.Json.Serialization;

namespace la_tegav.Application.Reponses;

public class BaseReponse
{
    [JsonPropertyName("status")]
    public int Status { get; set; }

    [JsonPropertyName("messageDetail")]
    public string MessageDetail { get; set; } = string.Empty;

    public BaseReponse() { }

    public BaseReponse(int status, string messageDetail)
    {
        Status = status;
        MessageDetail = messageDetail;
    }
}