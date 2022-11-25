using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowShader : MonoBehaviour
{
    float _snowCounter = 5;
    [SerializeField]float _minSnow;
    [SerializeField]float _maxSnow;
    [SerializeField]float _timeScale;
    // Update is called once per frame
    void Update()
    {
       _snowCounter =  Mathf.Clamp(_snowCounter,_minSnow,_maxSnow);
        _snowCounter-=Time.deltaTime * _timeScale;
        Debug.Log(_snowCounter);
        Shader.SetGlobalFloat("_SnowSlider",_snowCounter);
    }
}
