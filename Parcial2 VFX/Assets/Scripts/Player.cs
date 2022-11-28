using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Camera _cam;
    float _distance = 5f;
    [SerializeField] Vector3 offesRay;

    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
         Debug.DrawRay(_cam.transform.position + offesRay, _cam.transform.forward * _distance, Color.green);
        if(Input.GetButtonDown("Fire1"))
             ShootRaycast();

    }

    private void ShootRaycast()
    {
        RaycastHit hitInfo;
        Physics.Raycast(_cam.transform.position + offesRay, _cam.transform.forward, out hitInfo, _distance);
        if (hitInfo.transform == null) return;
        Debug.Log(hitInfo.transform.name);
        if(hitInfo.transform.GetComponent<IInteracteable>()!=null)
            hitInfo.transform.GetComponent<IInteracteable>().Interact();
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        if(_cam!=null)
            Gizmos.DrawLine(_cam.transform.position,_cam.transform.forward*_distance);

    }
}