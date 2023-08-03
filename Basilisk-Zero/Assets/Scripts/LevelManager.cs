using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    //public GameObject floor;
    
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SceneSwitch());
        
        
        SetBounds();
    }

    // Update is called once per frame
    void Update()
    {
        SetBounds();
    }

    private void SetBounds()
    {
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(0f, 1f, 0f);
        topRightEdge = tilemap.localBounds.max + new Vector3(-0f, -1f, 0f);
        PlayerController.instance.SetLimit(bottomLeftEdge, topRightEdge);
    }
    /*IEnumerator SceneSwitch()
    {
        yield return new WaitForEndOfFrame();

        floor = GameObject.Find("Floor");
        tilemap = floor.GetComponentInChildren<Tilemap>();
    }*/
}
