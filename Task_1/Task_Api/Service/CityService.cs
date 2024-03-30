using AutoMapper;
using Task_Api.Entity;
using Task_Api.Interface;
using Task_Api.ServiceInterface;
using Task_Api.VMModel;

namespace Task_Api.Service
{
    public class CityService: ICityService
    {

        ICity _ICity;

        public CityService(ICity harne)
        {
            _ICity = harne;
        }

        public async Task<long> CitySave(VMCity vMCity)
        {
            CityEntity cityEntity = new CityEntity();

            var config = new MapperConfiguration(con =>
            {
                con.CreateMap<VMCity, CityEntity>();
            });
            IMapper map = config.CreateMapper();

            cityEntity = map.Map<VMCity, CityEntity>(vMCity);

            long rowdata = await _ICity.CitySave(cityEntity);
            return rowdata;
        }

    }
}
