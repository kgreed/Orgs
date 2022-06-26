using DevExpress.Persistent.Base;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

namespace Orgs.Module.BusinessObjects
{
    public class CustomerFilter : IFilter
    {
        public CustomerFilter(){
            Name = "";
        }

        [VisibleInDetailView(true)]
        public string Name { get; set; }


        public IFilter ReadFromFile()
        {
            if (!File.Exists(settingsFile)) return null;
            var text = File.ReadAllText(settingsFile);
            var f = JsonConvert.DeserializeObject<CustomerFilter>(text);
            return f;
        }
        private const string settingsFile = "c:\\jobtalktemp\\customerfilter.json";
        public void SaveToFile()
        {
            File.WriteAllText(settingsFile, JsonConvert.SerializeObject(this));
        }

        public void Reset()
        {
            Name = "";
        }
    }
}
