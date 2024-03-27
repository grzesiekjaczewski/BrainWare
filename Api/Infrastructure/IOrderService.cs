using Api.Models;

namespace Api.Infrastructure
{
    public interface IOrderService
    {
        List<OldOrder> GetOrdersForCompany(int CompanyId);
    }
}
