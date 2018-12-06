using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using WeMicroIt.Utils.JSONConverter.Interfaces;

namespace WeMicroIt.Utils.JSONConverter
{
    public class JSONConverter : IJSONConverter
    {
        private JsonSerializerSettings JSONSettings { get; set; }
        private Formatting JSONFormatter { get; set; }

        public JSONConverter()
        {
            JSONFormatter = Formatting.Indented;
        }

        public JsonSerializerSettings SetSettings(JsonSerializerSettings settings)
        {
            try
            {
                if (settings == null)
                {
                    settings = new JsonSerializerSettings();
                }
                JSONSettings = settings;
                return JSONSettings;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Formatting SetSettingsFormatting(Formatting format)
        {
            try
            {
                JSONFormatter = format;
                return format;
            }
            catch (Exception)
            {
                return format;
            }
        }

        public List<T> DeSerializeObjects<T>(string content)
        {
            return JsonConvert.DeserializeObject<List<T>>(content, JSONSettings);
        }

        public string SerializeObjects(object content)
        {
            return JsonConvert.SerializeObject(content,JSONFormatter, JSONSettings);
        }
    }
}
