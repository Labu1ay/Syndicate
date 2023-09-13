using UnityEngine;

namespace _Scripts.Infastructure.AssetManagement {
    public interface IAssetProvider {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}