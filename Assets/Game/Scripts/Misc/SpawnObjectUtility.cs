using UnityEngine;

public class SpawnObjectUtility : MonoBehaviour
{
    [SerializeField] private GameObject @object;

    public void Spawn()
    {
        Instantiate(@object, transform.position,Quaternion.identity);
    }
}
