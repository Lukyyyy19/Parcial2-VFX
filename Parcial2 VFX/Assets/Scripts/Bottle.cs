using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottle : MonoBehaviour, IInteracteable
{
    [SerializeField] bool interact;
    [SerializeField]Vector3 v3;
    private float timeElapsed;
    [SerializeField] private float lerpDuration = 1f;
    private bool startTime;
    Rigidbody _rb;
    private void Start() {
        _rb = GetComponent<Rigidbody>();
    }
    public void Interact()
    {
        interact = true;
        _rb.isKinematic = true;

    }

    private void Update()
    {
        v3 = Input.mousePosition;
        v3.z = 1f;
        v3 = Camera.main.ScreenToWorldPoint(v3);
        if (startTime)
        {
            timeElapsed += Time.deltaTime;
            if (timeElapsed >= 1)
            {
                timeElapsed = 0;
            }
        }
    }

    private void OnMouseDrag()
    {
        if(interact){
            startTime = true;
            transform.position = Vector3.Lerp(transform.position, new Vector3(v3.x,v3.y-.25f,v3.z), timeElapsed / lerpDuration);
        }
    }
    private void OnMouseUp()
    {
        _rb.isKinematic = false;
        startTime = false;
        interact = false;

    }
}
