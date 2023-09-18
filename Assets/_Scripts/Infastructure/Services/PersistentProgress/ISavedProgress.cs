using _Scripts.Data;

namespace _Scripts.Infastructure.Services.PersistentProgress {
    public interface ISavedProgressReader {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : ISavedProgressReader {
        void UpdateProgress(PlayerProgress progress);
    }
}