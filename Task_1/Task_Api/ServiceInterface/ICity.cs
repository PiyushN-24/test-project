using Task_Api.Entity;

namespace Task_Api.ServiceInterface
{
    public interface ICity
    {
        Task<long> CitySave(CityEntity cityEntity);

    }
}
