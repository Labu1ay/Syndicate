using _Scripts.Data;

namespace _Scripts.Infastructure.Services.SaveLoad {
    public interface ISaveLoadService : IService { 
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}