using UnityEngine;

public class KeyboardMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float speed = 4f;

    void Update()
    {
        if (GameManager.isInputEnabled)
        {
            ControlMovement();
        }
    }

    void ControlMovement()
    {
        float keyboardX = Input.GetAxis("Horizontal");
        float keyboardZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * keyboardX + transform.forward * keyboardZ;
        characterController.Move(move * speed * Time.deltaTime);

        transform.position = new Vector3(transform.position.x, 1.08f, transform.position.z);
    }
}