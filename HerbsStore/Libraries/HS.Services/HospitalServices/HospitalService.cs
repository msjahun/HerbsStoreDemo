using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Diseases;
using HerbsStore.Libraries.HS.Core.Domain.Hospitals;
using HerbsStore.Libraries.HS.Data.Repository;
using HerbsStore.Libraries.HS.Services.DiseaseServices;
using HerbsStore.Libraries.HS.Services.ImageServices;

namespace HerbsStore.Libraries.HS.Services.HospitalServices
{
    public class HospitalService : IHospitalService
    {
        private readonly IImageService _imageService;
        private readonly IRepository<Hospital> _hospitalRepo;
        private readonly IRepository<HospitalDisease> _hospitalDiseaseRepo;
        private readonly IDiseaseService _diseaseService;
        private readonly IRepository<Disease> _diseaseRepo;

        public HospitalService(IRepository<Hospital> hospitalsRepo,
            IImageService imageService,
            IRepository<HospitalDisease> hospitalDiseaseRepo,
            IDiseaseService diseaseService,
            IRepository<Disease> diseaseRepo)
        {
            _hospitalRepo = hospitalsRepo;
            _imageService = imageService;
            _hospitalDiseaseRepo = hospitalDiseaseRepo;
            _diseaseService = diseaseService;
            _diseaseRepo = diseaseRepo;
        }


        public long HospitalAdd(HospitalCrudVm vm)
        {
            var hospital = new Hospital
            {
                HospitalName = vm.HospitalName,
                Description = vm.Description,
                Address = vm.HospitalAddress,
                ImageUrl = _imageService.UploadHospitalImage()
            };

            var hospitalId = _hospitalRepo.Insert(hospital);

            foreach (var item in vm.DiseaseListIds)
            {

                _hospitalDiseaseRepo.Insert(new HospitalDisease
                {
                    HospitalId = hospitalId,
                    DiseaseId = item
                });

            }

            return hospitalId;
        }

        public HospitalCrudVm GetHospitalById(long id)
        {
            var hospital = _hospitalRepo.GetById(id);
            if (hospital == null) return null;

            var model = new HospitalCrudVm
            {
                Id = hospital.Id,
                HospitalName = hospital.HospitalName,
                Description = hospital.Description,
                HospitalAddress = hospital.Address,
                DiseaseListIds = GetHospitalDiseasesids(hospital.Id) ,
                ImageUrl = string.IsNullOrEmpty(hospital.ImageUrl) ? "/images/default-image_100.png" : hospital.ImageUrl
            };

            return model;
        }


        public List<string> GetHospitalDiseasesByHospitalId(long id)
        {
            var hospital = _hospitalRepo.GetById(id);
            if (hospital == null) return null;

            var hospitalDisease = from d in _diseaseRepo.List()
                join hosDis in _hospitalDiseaseRepo.List() on d.Id equals hosDis.DiseaseId
                where hosDis.HospitalId== hospital.Id

                                  select d.DiseaseName;
            return hospitalDisease.ToList();

        }

        public List<long> GetHospitalDiseasesids(long id)
        {
            var hospital = _hospitalRepo.GetById(id);
            if (hospital == null) return null;

            var hospitalDisease = from d in _diseaseRepo.List()
                join hosDis in _hospitalDiseaseRepo.List() on d.Id equals hosDis.DiseaseId
                where hosDis.HospitalId == hospital.Id

                select d.Id;
            return hospitalDisease.ToList();

        }

        public bool HospitalUpdate(HospitalCrudVm vm)
        {
            var hospital = _hospitalRepo.GetById(vm.Id);
            if (hospital == null) return false;
            hospital.HospitalName = vm.HospitalName;
            hospital.Description = vm.Description;

            var updatedImageUrl = _imageService.UploadHospitalImage();
            if (!string.IsNullOrEmpty(updatedImageUrl))
                hospital.ImageUrl = updatedImageUrl;

            _hospitalRepo.Update(hospital);


            //take list of disease and clear existing and add new to list
            var hospitalDiseases = _hospitalDiseaseRepo.List().Where(c => c.HospitalId== hospital.Id).ToList();
            foreach (var item in hospitalDiseases)
            {
                _hospitalDiseaseRepo.Delete(item);
            }
            //^delete current ids

            if(vm.DiseaseListIds!=null)
            foreach (var item in vm.DiseaseListIds)
            {

                _hospitalDiseaseRepo.Insert(new HospitalDisease
                {
                    HospitalId = hospital.Id,
                    DiseaseId = item
                });

            }
            //^inserts new ids

            return true;
        }

        public void DeleteHospital(long hospitalId)
        {
            var hospital = _hospitalRepo.GetById(hospitalId);
            if (hospital == null) return;

            var hospitalDiseases = _hospitalDiseaseRepo.List().Where(c => c.HospitalId == hospital.Id).ToList();
            foreach (var item in hospitalDiseases)
            {
                _hospitalDiseaseRepo.Delete(item);
            }
            _hospitalRepo.Delete(hospital);
        }


        public List<HospitalCrudVm> GetHospitals(HospitalCrudVm vm)
        {
            //Filters are hospitalName and DiseaseType

            var hospitals = _hospitalRepo.List().ToList();
            var hospitalDiseases = _hospitalDiseaseRepo.List().ToList();
            hospitals = HospitalFilterHelpers.SearchHospitalName(hospitals, vm.HospitalName);
            hospitals = HospitalFilterHelpers.DiseaseType(hospitals, hospitalDiseases, vm.DiseaseId);

            var model = from hospital in hospitals
                select new HospitalCrudVm
                {
                    Id = hospital.Id,
                    HospitalName = hospital.HospitalName,
                    Description = hospital.Description,
                    HospitalAddress = hospital.Address,
                    DiseasesFlat = _diseaseService.FlattenDiseasesList(GetHospitalDiseasesByHospitalId(hospital.Id)),
                    ImageUrl = string.IsNullOrEmpty(hospital.ImageUrl) ? "/images/default-image_100.png" : hospital.ImageUrl,
                   

                };

            return model.ToList();
          
           
            //write the remaining filter code here
        }
    }

    public class HospitalCrudVm
    {
        public long Id { get; set; }
        [Required]
        public string HospitalName { get; set; }
        [Required]
        public string HospitalAddress { get; set; }
        [Required]
        public string Description { get; set; }
      
        public string DiseasesFlat { get; set; }
        public string ImageUrl { get; set; }


        public List<HospitalCrudVm> List { get; set; }
        public int DiseaseId { get; set; }
        public List<long> DiseaseListIds { get; set; }
    }
}
