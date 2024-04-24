using Core.Model;

namespace ServerAPI.Repositories
{
    public interface IAdRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(Ad item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        Ad[] GetAll();


        // Opdaterer element med Id = item.Id.
        void UpdateItem(Ad item);
        Ad GetById(int id);
        
        void PurchaseAd(Ad item);
    }
}