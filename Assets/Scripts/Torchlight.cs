///<summary>
///Script that handles the functionality of the torchlight
///</summary>
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchlight : MonoBehaviour, ISaveable
{
    float intensityDecay = 0.1f;
    float angleDecay = 1f;
    public float minAngle = 40;
    Light light;
    public AudioClip clip;
    
    private void Start()
    {
        light = GetComponent<Light>();
        light.enabled = false;
        StartCoroutine(DecreaseLightAngle());
        StartCoroutine(DecreaseLightIntensity());
    }

    private void Update()
    {
        ToggleLight();
    }

    /// <summary>
    /// Toggle the torchlight on and off based on input
    /// </summary>
    private void ToggleLight()
    {
        if(Input.GetKeyDown("f") || Mathf.Round(Input.GetAxisRaw("Torch")) > 0)
        {
            AudioSource.PlayClipAtPoint(clip, gameObject.transform.position);
            if(light.enabled)
            {
                light.enabled = false;
                angleDecay = 0.0f;
                intensityDecay = 0.0f;
            }
            else
            {
                light.enabled = true;
                angleDecay = 0.5f;
                intensityDecay = 0.1f;
            }
        }
    }

    /// <summary>
    /// Decrease the light angle over time
    /// </summary>
    IEnumerator DecreaseLightAngle()
    {
        while(light.spotAngle >= minAngle)
        {
            light.spotAngle -= angleDecay * Time.deltaTime;
            yield return new WaitForSeconds(10);
        }
    }

    /// <summary>
    /// Decrease the light intensity over time
    /// </summary>
    IEnumerator DecreaseLightIntensity()
    {
        while(light.intensity >= -1)
        {
            light.intensity -= intensityDecay * Time.deltaTime;
            yield return new WaitForSeconds(10);

        }
    }

    public void ResetLightAngle(float restoreAmount)
    {
        light.spotAngle = restoreAmount;
    }

    public void ResetLightIntensity(float intensityAmount)
    {
        light.intensity = intensityAmount;
    }

    public object CaptureState()
    {
        return $"{light.intensity} {light.spotAngle}";
    }

    public void RestoreState(object state)
    {
        string result = (string)state;
        string[] lightValues = result.Split(' ');
        light.intensity = float.Parse(lightValues[0]);
        light.spotAngle = float.Parse(lightValues[1]);
    }
}
