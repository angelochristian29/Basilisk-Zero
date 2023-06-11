using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    public string transitionAreaName;
    // Start is called before the first frame update
    void Start()
    {
        if (transitionAreaName.CompareTo(PlayerController.instance.transitionName) == 0) {
            PlayerController.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
