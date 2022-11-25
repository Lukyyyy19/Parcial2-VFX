using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float _movHor;
    float _movVer;
    [SerializeField] float _speed = 7.5f;
    Vector2 _sensibility;
    CharacterController _charController;
    Camera _cam;
    [SerializeField] Vector3 dir;
    void Start()
    {
        _charController = GetComponent<CharacterController>();
        _cam = Camera.main;
        _sensibility.x = 2;
        _sensibility.y = -2;
    }

    void Update()
    {
        _movHor = Input.GetAxis("Horizontal");
        _movVer = Input.GetAxis("Vertical");

        Gravity();
        dir = (transform.right * _movHor + transform.forward * _movVer) * Time.deltaTime * _speed;
        if (_charController.isGrounded)
        {
            _charController.Move(new Vector3(dir.x, -.05f, dir.z));
        }
        else
        {
            _charController.Move(new Vector3(dir.x, -9.8f, dir.z));
        }
        //var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        // transform.eulerAngles = new Vector3(transform.eulerAngles.x,mousePos.y*_speed,transform.eulerAngles.z)*Time.deltaTime;
        ArtificialUpdate();
    }

    void Gravity()
    {
        if (_charController.isGrounded)
        {
            Debug.Log("en el piso");
            float groundedGravity = -.05f;
            dir.y = groundedGravity;
        }
        else
        {
            Debug.Log("en el aire");
            float gravity = -9.8f;
            dir.y += gravity;
        }
    }
    public void ArtificialUpdate()
    {
        float hor = Input.GetAxis("Mouse X");
        float ver = Input.GetAxis("Mouse Y");

        if (hor != 0)
        {
            transform.Rotate(Vector3.up * hor * _sensibility.x);
        }

        if (ver != 0)
        {
            //_camera.Rotate(Vector3.left * ver * _sensibility.y);

            float angle = (_cam.transform.localEulerAngles.x + ver * _sensibility.y + 360) % 360; //esta funcion perite hacer que vaya desde 0 a 360

            if (angle > 180) { angle -= 360; }

            angle = Mathf.Clamp(angle, -80, 80); //funcion que permite poner un limite entre dos numeros

            _cam.transform.localEulerAngles = Vector3.right * angle;

        }
    }
}
