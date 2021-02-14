using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    [SerializeField] Material [] Materials;
    public Light light;
    // Start is called before the first frame update
    void Start()
    {
        light = gameObject.GetComponent<Light>();
        print(gameObject.GetComponent<Light>().intensity);
    }

    // Update is called once per frame
    void Update()
    {
        if(light.intensity > 0.3f)
        {
            light.intensity -= 0.01f;
        }
    }
}
