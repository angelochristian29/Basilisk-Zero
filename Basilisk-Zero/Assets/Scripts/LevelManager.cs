using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;
    
    private Vector3 bottomLeftEdge;
    private Vector3 topRightEdge;

    // Start is called before the first frame update
    void Start()
    {
        SetBounds();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetBounds()
    {
        bottomLeftEdge = tilemap.localBounds.min + new Vector3(0f, 1f, 0f);
        topRightEdge = tilemap.localBounds.max + new Vector3(-0f, -1f, 0f);
        PlayerController.instance.SetLimit(bottomLeftEdge, topRightEdge);
    }
}
