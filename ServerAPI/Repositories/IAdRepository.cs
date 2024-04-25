using Core.Model;

namespace ServerAPI.Repositories
{
    public interface IAdRepository
    {
        void AddAd(Ad ad);

        void DeleteById(int id);

        Ad[] GetAll();

        void PurchaseAd (Ad ad);

        void UpdateAd(Ad ad);
    }
}