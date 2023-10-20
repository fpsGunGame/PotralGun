using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float jumpPower;
    public bool isGround;
    public float lookSensitivity; 

    public float cameraRotationLimit;  
    private float currentCameraRotationX;

    public Camera theCamera; 
    private Rigidbody myRigid;

    public GameObject portalGun;

    float time;
    void Start() 
    {
        myRigid = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(0, 0, 0);
        time = 0f;
        isGround = true;
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        if (time > 0.5f) {
            CameraRotation();
            CharacterRotation();
        } else 
            time += Time.deltaTime;
    }

    private void Move()
    {
        float _moveDirX = Input.GetAxisRaw("Horizontal");  
        float _moveDirZ = Input.GetAxisRaw("Vertical");  
        Vector3 _moveHorizontal = transform.right * _moveDirX; 
        Vector3 _moveVertical = transform.forward * _moveDirZ; 

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed; 

        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    private void Jump() 
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround) {
            myRigid.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
            isGround = false;
        }
    }

    private void CameraRotation()  
    {
        float _xRotation = Input.GetAxisRaw("Mouse Y"); 
        float _cameraRotationX = _xRotation * lookSensitivity;
        
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
        portalGun.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);
    }

    private void CharacterRotation()
    {
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _characterRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_characterRotationY));
    }

    private void OnCollisionEnter(Collision other) 
    {
        if (other.collider.CompareTag("floor") || other.collider.CompareTag("WallOne")) {
            isGround =true;
        }
    }
}