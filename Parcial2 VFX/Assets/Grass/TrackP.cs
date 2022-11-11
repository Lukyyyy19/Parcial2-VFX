using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackP : MonoBehaviour
{
    Material _mat;
    [SerializeField] Transform _player;
    TreeInstance[] trees;
    Terrain terrain;
    void Start()
    {
        _mat = GetComponent<Renderer>().material;
        // terrain = GetComponent<Terrain>();
        // trees = terrain.terrainData.treeInstances;
    }

    void Update()
    {
        Vector3 _trackerPos = _player.position;

        _mat.SetVector("_trackerPos", _trackerPos);


    }
}
