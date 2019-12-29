using System.Collections.Generic;

namespace HerbsStore.Libraries.HS.Services.FeedbackServices
{
    public interface IFeedbackService
    {
        long FeedBackAdd(FeedbackCrudVm feedbackVm);
        bool FeedBackUpdate(FeedbackCrudVm feedbackVm);
        void DeleteFeedBack(long feedbackId);
        List<FeedbackCrudVm> GetFeedBack();
    }
}