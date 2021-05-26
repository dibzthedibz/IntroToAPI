using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoda_Translator
{
    public class Contents
    {
        [JsonProperty("translated")]
        public string Translated { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("translation")]
        public string Translation { get; set; }
    }
}