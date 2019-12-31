using System.Collections.Generic;

namespace HerbsStore.Libraries.HS.Services.HospitalServices
{
    public interface IHospitalService
    {
        long HospitalAdd(HospitalCrudVm hospitalVm);
        HospitalCrudVm GetHospitalById(long id);
        bool HospitalUpdate(HospitalCrudVm hospitalVm);
        void DeleteHospital(long hospitalId);
        List<HospitalCrudVm> GetHospitals(HospitalCrudVm vm);
    }
}