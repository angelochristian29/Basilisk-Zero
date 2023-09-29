using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaEnter : MonoBehaviour
{
    [SerializeField] public string transitionAreaName;

    // Start is called before the first frame update
    private void Start()
    {
        if (transitionAreaName == PlayerController.GetInstance().transitionName) {
            PlayerController.GetInstance().transform.position = transform.position;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
