using _Scripts.Infastructure.Services;
using UnityEngine;

namespace _Scripts.Infastructure.AssetManagement {
    public interface IAssets : IService {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}