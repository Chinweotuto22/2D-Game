using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Duration of the shake effect
    public float shakeDuration = 0.5f;
    // Intensity of the shake effect
    public float shakeMagnitude = 0.2f;

    private Vector3 initialPosition;

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    public void Shake()
    {
        StartCoroutine(ShakeCoroutine());
    }

    private IEnumerator ShakeCoroutine()
    {
        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // Move the camera randomly within a small range (shakeMagnitude)
            Vector3 randomPoint = initialPosition + Random.insideUnitSphere * shakeMagnitude;
            randomPoint.z = initialPosition.z; // Ensure the camera stays in its original Z position

            transform.localPosition = randomPoint;

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Reset camera to its initial position
        transform.localPosition = initialPosition;
    }
}
