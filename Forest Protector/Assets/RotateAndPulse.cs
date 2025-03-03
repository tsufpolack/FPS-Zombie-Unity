using UnityEngine;

public class RotateAndPulse : MonoBehaviour
{
    // Drag and drop the GameObject and Light in the Inspector
    public GameObject targetObject;
    public Light pointLight;

    // Rotation speed in degrees per second
    public float rotationSpeed = 360f;

    // Pulse speed
    public float pulseSpeed = 2f;

    // Intensity range
    private float minIntensity = 10f;
    private float maxIntensity = 20f;

    private void Update()
    {
        // Rotate the GameObject around its X-axis
        if (targetObject != null)
        {
            targetObject.transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
        }

        // Pulse the light intensity
        if (pointLight != null)
        {
            float intensity = Mathf.Lerp(minIntensity, maxIntensity, Mathf.PingPong(Time.time * pulseSpeed, 1));
            pointLight.intensity = intensity;
        }
    }
}
