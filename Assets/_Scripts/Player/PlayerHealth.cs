using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private GameObject deadPrefab;
    [SerializeField]
    private CameraShake cameraShake;

    public void Hit()
    {
        Destroy(this.gameObject);
        cameraShake.ShakeCamera = true;
        
        GameObject prefabDeadFVX = Instantiate(deadPrefab, this.transform.position, Quaternion.identity) as GameObject;
        Destroy(prefabDeadFVX, 2);
    }
}
