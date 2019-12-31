using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;

namespace HerbsStore.Libraries.HS.Core.Domain.Hospitals
{
    public class Hospital : BaseEntity
    {

        public Hospital()
        {
            HospitalDiseases = new HashSet<HospitalDisease>();
        }

        public ICollection<HospitalDisease> HospitalDiseases { get; set; }
        public string HospitalName { get; set; }
        public string Description { get; set; }
        public string DieseaseName { get; set; }

        public string Address { get; set; }
        public string ImageUrl { get; set; }

    }
}
