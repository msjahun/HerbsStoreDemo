using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerbsStore.Libraries.HS.Core.Domain.Hospitals
{
    public class Hospital : BaseEntity
    {
        public string HospitalName { get; set; }
        public string Description { get; set; }
        public string DieseaseName { get; set; }
    }
}
