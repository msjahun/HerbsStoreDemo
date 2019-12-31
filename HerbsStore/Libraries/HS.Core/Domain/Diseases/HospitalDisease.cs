using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Hospitals;
using HerbsStore.Libraries.HS.Core.Domain.Products;

namespace HerbsStore.Libraries.HS.Core.Domain.Diseases
{
    public class HospitalDisease : BaseEntity
    {

        public long HospitalId { get; set; }
        public Hospital Hospital{ get; set; }
        public long DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
