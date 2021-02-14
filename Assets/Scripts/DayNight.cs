using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] Material afternoonSkybox;
    [SerializeField] Material nightSkybox;
    Light light;
    float lightMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        lightMultiplier = 0.003f;
    }

    // Update is called once per frame
    void Update()
    {
        if(light.intensity > 0.3f)
        {
            light.intensity -= lightMultiplier;
        }
        UpdateSkybox(light.intensity);
    }

    void UpdateSkybox(float intensity)
    {
        if(intensity > 0.5)
        {
            RenderSettings.skybox = afternoonSkybox;
        }
        else
        {
            RenderSettings.skybox = nightSkybox;
        }
    }
}
