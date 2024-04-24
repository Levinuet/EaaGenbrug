using Core.Model;

namespace ServerAPI.Repositories
{
    public interface IAdRepository
    {
        //Tildeler item en unik id og tilføjer den.
        void AddItem(AdItem item);

        // Fjerner item, hvor item.Id = id. Hvis den ikke
        // findes sker ingenting
        void DeleteById(int id);

        AdItem[] GetAll();


        // Opdaterer element med Id = item.Id.
        void UpdateItem(AdItem item);
    }
}