using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 0.1f; // Hareket hýzý

    private void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float minZ = -9.2f; // Minimum z pozisyonu
                float maxZ = -1f; // Maksimum z pozisyonu                

                float newZ = Camera.main.transform.position.z + touch.deltaPosition.y * speed;
                newZ = Mathf.Clamp(newZ, minZ, maxZ);

                Vector3 newPosition = Camera.main.transform.position;
                newPosition.z = newZ;

                Camera.main.transform.position = newPosition;
                //Camera.main.transform.Translate(new Vector3(transform.position.x, transform.position.y, newPosition.z));
            }
        }
    }
}
