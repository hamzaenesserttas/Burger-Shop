using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Vector2 moveInput; 
    private Vector2 lookInput;
    public Transform playerBody; 
    public Transform playerCamera;
    public float mouseSensitivity = 100f; 
    public float moveSpeed = 3f; 
    private float xRotation = 0f; 

    

    void Update()
    {
        Vector3 move = playerBody.transform.right * moveInput.x + playerBody.transform.forward * moveInput.y;
        playerBody.Translate(move * Time.deltaTime * moveSpeed, Space.World); 

        // Bakış işlemlerini uyguluyorum kamerayı yukarı aşağı objeyi sola sağa döndürüyor.
        HandleLook();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    
    public void OnJump(InputValue Button)
    {
        Rigidbody rb = playerBody.GetComponent<Rigidbody>();

        // Eğer karakter yerin üzerindeyse zıplama uygula
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }

    public void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    private void HandleLook()
    {
        // Sağa-Sola hareket (Yaw): Player'ı döndür
        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);

        // Yukarı-Aşağı hareket (Pitch): Kamerayı döndür
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Kameranın yukarı-aşağı sınırını belirle
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
    private bool IsGrounded()
    {
        // Karakterin altına doğru bir ray (ışın) göndererek zemine temas kontrolü
        return Physics.Raycast(playerBody.position, Vector3.down, 1.1f);
    }

}
