using UnityEngine;

static internal class factory {
    public static GameObject Instantiate(string path, Vector3 at) {
        var prefab = Resources.Load<GameObject>(path);//"Grim Reaper"
        return Object.Instantiate(prefab, at, Quaternion.identity);
    }
}