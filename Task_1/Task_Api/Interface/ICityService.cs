using Task_Api.VMModel;

namespace Task_Api.Interface
{
    public interface ICityService
    {
        Task<long> CitySave(VMCity vMCity);
    }
}
