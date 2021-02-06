using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectiveTrigger : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI objectiveText;
    
    private void OnTriggerEnter(Collider other)
    {
        Objective objective = Objective.Instance;
        objectiveText.text = objective.GetCurrentObjective();
        print("cplloded");
        Destroy(gameObject);
    }
}
