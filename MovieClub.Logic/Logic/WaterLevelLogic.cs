using Water.Data;
using Water.Entities;
using Water.Entities.Dtos.WaterLevel;
using Water.Logic.Helpers;

namespace Water.Logic.Logic
{
    public class WaterLevelLogic
    {
        Repository<WaterLevel> repo;
        DtoProvider dtoProvider;

        public WaterLevelLogic(Repository<WaterLevel> repo, DtoProvider dtoProvider)
        {
            this.repo = repo;
            this.dtoProvider = dtoProvider;
        }

        public void AddWaterLevel(WaterLevelCreateUpdateDto dto)
        {
            WaterLevel wl = dtoProvider.Mapper.Map<WaterLevel>(dto);

            // Only save if there is no entry with the same date
            if (repo.GetAll().FirstOrDefault(x => x.Date == wl.Date) == null)
            {
                repo.Create(wl);
            }
            else
            {
                throw new ArgumentException("An entry with this date already exists!");
            }
        }

        public IEnumerable<WaterLevelShortViewDto> GetAllWaterLevels()
        {
            return repo.GetAll().Select(x =>
                dtoProvider.Mapper.Map<WaterLevelShortViewDto>(x)
            );
        }

        public void DeleteWaterLevel(string id)
        {
            repo.DeleteById(id);
        }

        public void UpdateWaterLevel(string id, WaterLevelCreateUpdateDto dto)
        {
            var old = repo.FindById(id);
            dtoProvider.Mapper.Map(dto, old);
            repo.Update(old);
        }

        public WaterLevelViewDto GetWaterLevel(string id)
        {
            var model = repo.FindById(id);
            return dtoProvider.Mapper.Map<WaterLevelViewDto>(model);
        }
    }
}
