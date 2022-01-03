using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   [Header("Character Physic")]
    public float moveSpeed,gravityModifier;
    
    public CharacterController charCon;

    private Vector3 moveInput;

    public Transform camTrans;

    public float mouseSensitivity;
    public bool InvertX;
    public bool invertY;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //simple character move
        //moveInput.x = Input.GetAxis("Horizontal")* moveSpeed * Time.deltaTime;
        //moveInput.z = Input.GetAxis("Vertical")* moveSpeed * Time.deltaTime;

        //Store y Velocity ; 
        float yStore = moveInput.y;

        Vector3 vertMove = transform.forward * Input.GetAxis("Vertical");
        Vector3 horiMove = transform.right * Input.GetAxis("Horizontal");

        moveInput = (horiMove + vertMove);
        moveInput.Normalize();
        moveInput = moveInput * moveSpeed;

        moveInput.y = yStore;
        moveInput.y += Physics.gravity.y * gravityModifier*Time.deltaTime ;

        if(charCon.isGrounded)
        {
            moveInput.y = Physics.gravity.y * gravityModifier * Time.deltaTime ;
        }
        

        charCon.Move(moveInput*Time.deltaTime);
        
        

        //Control The Camera Rotation
        Vector2 mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y") ) *mouseSensitivity;

        if (invertY)
        {
            mouseInput.y = -mouseInput.y;
        }
        if(InvertX)
        {
            mouseInput.x = -mouseInput.x;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);

      
        
        camTrans.rotation = Quaternion.Euler(camTrans.rotation.eulerAngles + new Vector3(-mouseInput.y, 0f, 0f));



    }
}
