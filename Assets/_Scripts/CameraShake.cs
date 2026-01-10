using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    /**This is a script is copied from this website http://unitytipsandtricks.blogspot.com.au/2013/05/camera-shake.html
    and it perspective explanation, I'm not sure if I explain it 100% correctly*/


    [SerializeField]
    private bool shakeCamera;
    [SerializeField]
    private float duration;
    [SerializeField]
    private float magnitude;

    public bool ShakeCamera { get { return shakeCamera; } set { shakeCamera = value; } }

    void Start () {

        shakeCamera = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (shakeCamera)
        {
            shakeCamera = false;
            StartCoroutine(Shake());
        }
    }

    IEnumerator Shake()
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / duration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            // map value to [-1, 1]
            float x = Random.value * 2.0f - 1.0f;
            float z = Random.value * 2.0f - 1.0f;
            x *= magnitude * damper;
            z *= magnitude * damper;

            Camera.main.transform.position = new Vector3(x + originalCamPos.x, originalCamPos.y, z + originalCamPos.z);

            yield return null;
        }
        Camera.main.transform.position = originalCamPos;
    }
}
