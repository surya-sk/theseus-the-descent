using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Handles changing from night to day (by simple reducing intensity of direction light)
/// </summary>
public class DayNight : MonoBehaviour, ISaveable
{
    [SerializeField] Material afternoonSkybox;
    [SerializeField] Material nightSkybox;
    Light light;
    [SerializeField]float lightMultiplier;

    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        StartCoroutine(ChangeTimeOfDay());
    }

    /// <summary>
    /// Updates the skybox depending on intensity
    /// </summary>
    void UpdateSkybox()
    {
        if(light.intensity > 0.5)
        {
            RenderSettings.skybox = afternoonSkybox;
        }
        else
        {
            RenderSettings.skybox = nightSkybox;
        }
    }

    /// <summary>
    /// Decreases the intensity every 10 seconds
    /// </summary>
    /// <returns></returns>
    IEnumerator ChangeTimeOfDay()
    {
        while(light.intensity > 0.2f)
        {
            light.intensity -= lightMultiplier;
            UpdateSkybox();

            yield return new WaitForSeconds(10);
        }
    }

    public object CaptureState()
    {
        return light.intensity;
    }

    public void RestoreState(object state)
    {
        if(light == null)
        {
            light = gameObject.GetComponent<Light>();
        }
        light.intensity = (float)state;
    }
}
