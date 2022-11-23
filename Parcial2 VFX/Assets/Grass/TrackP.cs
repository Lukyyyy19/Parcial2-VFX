using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackP : MonoBehaviour
{

    

    void Update()
    {
        Vector3 _trackerPos = transform.position;

        Shader.SetGlobalVector("_trackerPos", _trackerPos);


    }
}
