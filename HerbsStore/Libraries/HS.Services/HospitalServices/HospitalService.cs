using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Hospitals;
using HerbsStore.Libraries.HS.Data.Repository;
using HerbsStore.Libraries.HS.Services.ImageServices;

namespace HerbsStore.Libraries.HS.Services.HospitalServices
{
    public class HospitalService : IHospitalService
    {
        private readonly IImageService _imageService;
        private readonly IRepository<Hospital> _hospitalRepo;

        public HospitalService(IRepository<Hospital> hospitalsRepo,
            IImageService imageService)
        {
            _hospitalRepo = hospitalsRepo;
            _imageService = imageService;
        }


        public long HospitalAdd(HospitalCrudVm vm)
        {
            var hospital = new Hospital
            {
                HospitalName = vm.HospitalName,
                Description = vm.Description,
                DieseaseName = vm.DiseaseName,
                Address = vm.HospitalAddress,
                ImageUrl = _imageService.UploadHospitalImage()
            };

            return _hospitalRepo.Insert(hospital);
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
                DiseaseName = hospital.DieseaseName,
                ImageUrl = string.IsNullOrEmpty(hospital.ImageUrl) ? "/images/default-image_100.png" : hospital.ImageUrl
            };

            return model;
        }
        public bool HospitalUpdate(HospitalCrudVm vm)
        {
            var hospital = _hospitalRepo.GetById(vm.Id);
            if (hospital == null) return false;
            hospital.HospitalName = vm.HospitalName;
            hospital.Description = vm.Description;
            hospital.DieseaseName = vm.DiseaseName;

            var updatedImageUrl = _imageService.UploadHospitalImage();
            if (!string.IsNullOrEmpty(updatedImageUrl))
                hospital.ImageUrl = updatedImageUrl;

            _hospitalRepo.Update(hospital);

            return true;
        }

        public void DeleteHospital(long hospitalId)
        {
            var hospital = _hospitalRepo.GetById(hospitalId);
            if (hospital == null) return;
            _hospitalRepo.Delete(hospital);
        }


        public List<HospitalCrudVm> GetHospitals()
        {
            var model = from hospital in _hospitalRepo.List()
                select new HospitalCrudVm
                {
                    Id = hospital.Id,
                    HospitalName = hospital.HospitalName,
                    Description = hospital.Description,
                    HospitalAddress = hospital.Address,
                    DiseaseName = hospital.DieseaseName,
                    ImageUrl = string.IsNullOrEmpty(hospital.ImageUrl) ? "/images/default-image_100.png" : hospital.ImageUrl

                };

            return model.ToList();
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
        [Required]
        public string DiseaseName { get; set; }
        public string ImageUrl { get; set; }
    }
}
