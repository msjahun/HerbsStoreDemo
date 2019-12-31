using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HerbsStore.Libraries.HS.Core.Domain.Diseases
{
    public class Disease:BaseEntity
    {
        public Disease()
        {
            HospitalDiseases = new HashSet<HospitalDisease>();
            ProductDiseases = new HashSet<ProductDisease>();
        }

        public ICollection<HospitalDisease> HospitalDiseases{ get; set; }
        public ICollection<ProductDisease> ProductDiseases{ get; set; }
        public string DiseaseName { get; set; }
        public string DiseaseDescription { get; set; }
        public DateTime CreatedOn { get; set; }

    }
}
