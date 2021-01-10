using Newtonsoft.Json;
using System.Collections.Generic;

namespace DesafioNoesis_BDD_API.Helpers
{
    //classe utilizada para receber os valores da resposta json
    public class RespostaFilme
    {
        [JsonProperty("Title")]
        public string Titulo { get; set; }

        [JsonProperty("Year")]
        public string Ano { get; set; }

        [JsonProperty("Rated")]
        public string ClassificacaoIndicativa { get; set; }

        [JsonProperty("Released")]
        public string DataLancamento { get; set; }

        [JsonProperty("Runtime")]
        public string Duracao { get; set; }

        [JsonProperty("Genre")]
        public string Genero { get; set; }

        [JsonProperty("Director")]
        public string Diretor { get; set; }

        [JsonProperty("Writer")]
        public string Escritor { get; set; }

        [JsonProperty("Actors")]
        public string Atores { get; set; }

        [JsonProperty("Plot")]
        public string Plot { get; set; }

        [JsonProperty("Language")]
        public string Idioma { get; set; }

        [JsonProperty("Country")]
        public string Pais { get; set; }

        [JsonProperty("Awards")]
        public string Premios { get; set; }

        [JsonProperty("Poster")]
        public string Poster { get; set; }

        [JsonProperty("Ratings")]
        public List<Avaliacoes> Avaliacoes { get; set; }

        [JsonProperty("Metascore")]
        public string Metascore { get; set; }

        [JsonProperty("imdbRating")]
        public string AvaliacaoIMDB { get; set; }

        [JsonProperty("imdbVotes")]
        public string VotosIMDB { get; set; }

        [JsonProperty("imdbID")]
        public string IDIMBD { get; set; }

        [JsonProperty("Type")]
        public string Tipo { get; set; }

        [JsonProperty("DVD")]
        public string DVD { get; set; }

        [JsonProperty("BoxOffice")]
        public string BoxOffice { get; set; }

        [JsonProperty("Production")]
        public string Producao { get; set; }

        [JsonProperty("Website")]
        public string Site { get; set; }

        [JsonProperty("Response")]
        public string Response { get; set; }
    }
}
