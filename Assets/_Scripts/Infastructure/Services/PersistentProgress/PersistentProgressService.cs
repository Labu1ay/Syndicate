using _Scripts.Data;

namespace _Scripts.Infastructure.Services.PersistentProgress {
    public class PersistentProgressService : IPersistentProgressService {
        public PlayerProgress Progress { get; set; }
    }
}