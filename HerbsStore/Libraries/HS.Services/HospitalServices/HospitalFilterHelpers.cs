using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Core.Domain.Hospitals;

namespace HerbsStore.Libraries.HS.Services.HospitalServices
{
    public class HospitalFilterHelpers
    {
     

        public static List<Hospital> SearchHospitalName(List<Hospital> hospitals, string searchHospitalName)
        {

            if (string.IsNullOrEmpty(searchHospitalName))
                return hospitals;
            if (hospitals == null) return null;

            var hospitalList= from hos in hospitals
                where hos.HospitalName.ToLower().Contains(searchHospitalName.ToLower())
                select hos;

            return hospitalList.ToList();
        }

        public static List<Hospital> DiseaseType(List<Hospital> hospitals, List<HospitalDisease> hospitalDiseases, int diseaseId)
        {

            if (diseaseId == 0)//show all
                return hospitals;

            var hospitalDisease = from hosDisease in hospitalDiseases
                where hosDisease.DiseaseId == diseaseId
                select hosDisease;

            var hospitalList = from hosp in hospitals
                join hd in hospitalDisease on hosp.Id equals hd.HospitalId
                select hosp;
            return hospitalList.ToList();

        }
    }
}
