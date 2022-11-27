using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Underwater : MonoBehaviour
{
    public Material underwaterMaterial;
    public float underwaterLevel = 0.0f;

    private void Start()
    {
        underwaterMaterial.SetFloat("_Underwater", underwaterLevel);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            underwaterMaterial.SetFloat("_Underwater", 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        underwaterMaterial.SetFloat("_Underwater", 0f);
    }

#if UNITY_EDITOR
    private void OnDisable()
    {
        underwaterMaterial.SetFloat("_Underwater", 0f);
    }
#endif
}
