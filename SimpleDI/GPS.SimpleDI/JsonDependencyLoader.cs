using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPS.SimpleDI
{
    public class JsonDependencyLoader : IDefinitionLoader<JsonInjectableBase>
    {
        internal string _json = @"
{
    'TypeNamespace': 'GPS.SimpleDI',
    'TypeName': 'GPS.SimpleDI.JsonInjectableBase',
    'Constructors': [
    ],
    'Methods' : [{   
            'Name': 'LoadInjectableDefinition',
            'ReturnType': 'IInjectable',
            'Parameters': [
                { 'Name': 'loader', 'TypeNamespace': 'GPS.SimpleDI', 'TypeName': 'JsonDependencyLoader' }
            ]
        }
    ]
}
";

        public JsonDependencyLoader()
        {
        }

        public JsonDependencyLoader(string json)
        {
            _json = json;
        }

        public JsonInjectableBase LoadDefintion()
        {
            return JsonConvert.DeserializeObject<JsonInjectableBase>(_json);
        }
    }
}
