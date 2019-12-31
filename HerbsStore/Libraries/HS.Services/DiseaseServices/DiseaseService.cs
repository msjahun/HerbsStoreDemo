using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Data.Repository;

namespace HerbsStore.Libraries.HS.Services.DiseaseServices
{
    public class DiseaseService : IDiseaseService
    {
        private readonly IRepository<Disease> _diseaseRepo;

        public DiseaseService(IRepository<Disease> diseaseRepo)
        {
            _diseaseRepo = diseaseRepo;
        }

        public string FlattenDiseasesList(List<string> diseasesList)
        {

            if (diseasesList == null)
                return "";
            if (diseasesList.Count <= 0)
                return "";
            return string.Join(", ", diseasesList.ToArray());
        }


        public long DiseaseAdd(DiseaseCrudVm vm)
        {
            var disease = new Disease
            {
                DiseaseName = vm.DiseaseName,
                DiseaseDescription = vm.DiseaseDescription,
                CreatedOn = DateTime.Now
            };

            return _diseaseRepo.Insert(disease);
        }

        public DiseaseCrudVm GetDiseaseById(long id)
        {
            var disease = _diseaseRepo.GetById(id);
            if (disease == null) return null;

            var model = new DiseaseCrudVm
            {
                Id = disease.Id,
                DiseaseName = disease.DiseaseName,
                DiseaseDescription = disease.DiseaseDescription,
                
            };

            return model;
        }

        public bool DiseaseUpdate(DiseaseCrudVm vm)
        {
            var disease = _diseaseRepo.GetById(vm.Id);
            if (disease == null) return false;

            disease.DiseaseName = vm.DiseaseName;
            disease.DiseaseDescription = vm.DiseaseDescription;

            _diseaseRepo.Update(disease);
            return true;
        }

        public void DeleteDisease(long diseaseId)
        {
            var disease = _diseaseRepo.GetById(diseaseId);
            if (disease == null) return;

            _diseaseRepo.Delete(disease);
        }

        public List<DiseaseCrudVm> GetDiseases()
        {
            var model = from disease in _diseaseRepo.List()
                select new DiseaseCrudVm
                {
                    Id = disease.Id,
                    DiseaseName = disease.DiseaseName,
                    DiseaseDescription = disease.DiseaseDescription,
                    CreatedOn = disease.CreatedOn.ToString(CultureInfo.InvariantCulture)
                };

            return model.ToList();
        }
    }


    public class DiseaseCrudVm
    {
        public long Id { get; set; }

        [Required]
        public string DiseaseName { get; set; }
        [Required]
        public string DiseaseDescription { get; set; }
        public string CreatedOn { get; set; }
    }
}
