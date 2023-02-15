using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 5f;

    void Update()
    {
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * keyboardX + transform.forward * keyboardZ;
        characterController.Move(move * speed * Time.deltaTime);
    }
}