using Newtonsoft.Json;

namespace DesafioNoesis_BDD_API.Helpers
{
    public class Avaliacoes
    {
        [JsonProperty("Source")]
        public string Fonte { get; set; }

        [JsonProperty("Value")]
        public string Valor { get; set; }
    }
}
