using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using HerbsStore.Libraries.HS.Core.Domain.Feedback;
using HerbsStore.Libraries.HS.Data.Repository;

namespace HerbsStore.Libraries.HS.Services.FeedbackServices
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepository<Feedback> _feedbackRepo;

        public FeedbackService(IRepository<Feedback> feedbackRepo)
        {
            _feedbackRepo = feedbackRepo;
        }

        public long FeedBackAdd(FeedbackCrudVm feedbackVm)
        {
            var feedback = new Feedback
            {
                Email = feedbackVm.Email,
                Message = feedbackVm.Message,
                Subject = feedbackVm.Subject,
                Name = feedbackVm.Name
            };

          return _feedbackRepo.Insert(feedback);
        }

        public bool FeedBackUpdate(FeedbackCrudVm feedbackVm)
        {
            throw new NotImplementedException();
        }

        public void DeleteFeedBack(long feedbackId)
        {
            var feedback = _feedbackRepo.GetById(feedbackId);
            if (feedback == null) return;
            _feedbackRepo.Delete(feedback);
        }


        public List<FeedbackCrudVm> GetFeedBack()
        {
            var model = from f in _feedbackRepo.List()
                select new FeedbackCrudVm
                {
                    Message = f.Message,
                    Subject = f.Subject,
                    Email = f.Email,
                    Name = f.Name,
                    Id = f.Id,
                    Created = f.CreatedOn.ToString(CultureInfo.InvariantCulture)
                };

            return model.ToList();
        }
    }

    public class FeedbackCrudVm
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public long Id { get; set; }
        public string Created { get; internal set; }
    }
}
