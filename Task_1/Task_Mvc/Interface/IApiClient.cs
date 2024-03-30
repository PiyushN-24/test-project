using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_Mvc.BaseEntity;

namespace Task_Mvc.Interface
{
    public interface IApiClient
    {
        Task<ApiResponse> GetAsync(string relativePath);
        Task<ApiResponse> PostAsync(string relativePath, object obj);
        Task<ApiResponse> DeleteAsync(string relativePath);
        ApiResponse PostSync(string relativePath, object obj);
    }
}
