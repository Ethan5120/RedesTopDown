using Photon.Pun;
using UnityEngine;

public class CharacterMovement : MonoBehaviourPun
{
    CharacterController controller;

    [SerializeField] float pSpeed = 1;


    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            float x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");


            Vector3 dir = new Vector3(x, -1f, z);
            if(dir.magnitude > 0)
            {
                dir.Normalize();
                controller.Move(dir * pSpeed * Time.deltaTime);
            }
        }
        
    }


}
