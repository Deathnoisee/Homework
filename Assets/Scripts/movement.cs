using System.Runtime.CompilerServices;
using Unity.Cinemachine;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class movement : MonoBehaviour, IDataPersistence
{


    float horizontalMove = 0f;
    public float runSpeed = 40f;
    public bool jump = false;
    public bool crouch = false;
    float verticalMove = 0f;

    public CharacterController2D controller;

    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        if (Input.GetButtonDown("Jump") ) 
        {
            jump = true;
        }
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

        
    }




    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    
    }

    


    
    public void LoadData(GameData data)
    {
        Debug.Log("LoadData called with position: " + data.playerPosition);
        this.transform.position = data.playerPosition;
    }
    public void SaveData(ref GameData data)
    {
        Debug.Log("SaveData called with position: " + this.transform.position);
        data.playerPosition = this.transform.position;
    }

}



