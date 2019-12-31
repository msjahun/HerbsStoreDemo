using System.Collections.Generic;

namespace HerbsStore.Libraries.HS.Services.DiseaseServices
{
    public interface IDiseaseService
    {
        long DiseaseAdd(DiseaseCrudVm vm);
        DiseaseCrudVm GetDiseaseById(long id);
        bool DiseaseUpdate(DiseaseCrudVm vm);
        void DeleteDisease(long diseaseId);
        List<DiseaseCrudVm> GetDiseases();
        string FlattenDiseasesList(List<string> diseasesList);
    }
}