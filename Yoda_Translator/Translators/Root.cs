using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoda_Translator.Translators
{
    public class Root
    {
        [JsonProperty("success")]
        public Success Success { get; set; }

        [JsonProperty("contents")]
        public Contents Contents { get; set; }
    }
}
