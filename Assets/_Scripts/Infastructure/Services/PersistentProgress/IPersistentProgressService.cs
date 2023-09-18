using _Scripts.Data;

namespace _Scripts.Infastructure.Services.PersistentProgress {
    public interface IPersistentProgressService : IService{
        PlayerProgress Progress { get; set; }
    }
}