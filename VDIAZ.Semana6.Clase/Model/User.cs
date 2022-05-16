using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace VDIAZ.Semana6.Clase.Model
{
    public class User
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("birthDate")]
        public String BirthDate { get; set; }
        
        [JsonProperty("email")]
        public String Email { get; set; }
        
        [JsonProperty("gender")]
        public String Gender { get; set; }
        
        [JsonProperty("name")]
        public String Name { get; set; }
        
        [JsonProperty("height")]
        public double Height { get; set; }
        
        [JsonProperty("weight")]
        public double Weight { get; set; }
        
    }
}
