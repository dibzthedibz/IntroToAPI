using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoda_Translator.Translators
{
   
        public class Success
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
}
