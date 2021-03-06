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

 
        public void Reset()
        {
            Name = "";
        }
    }
}
