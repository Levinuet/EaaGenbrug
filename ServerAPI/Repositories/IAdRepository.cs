using Core.Model;

namespace ServerAPI.Repositories
{
    public interface IAdRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddAd(Ad ad);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        Ad[] GetAll();

        void PurchaseAd (Ad ad);
        
        void ApproveAd (Ad ad);


        // Opdaterer element med Id = item.Id.
        void UpdateItem(Ad ad);
    }
}