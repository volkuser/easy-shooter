using UnityEngine;

public class Rotation : MonoBehaviour
{
    [SerializeField] private Transform Body;
    [SerializeField] private Transform Weapon;

    [SerializeField] private float sensivity;
    private float xRotation = 45f;

    private void Start() => Cursor.lockState = CursorLockMode.Locked;

    private void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        Body.Rotate(Vector3.up * mouseX);
        
        Vector3 weaponPosition = transform.position;
        weaponPosition.y -= 0.3f;
        weaponPosition.x += 0.1f;
        Weapon.SetPositionAndRotation(weaponPosition, transform.rotation);
    }
}
