using UnityEngine;

public class weapon : MonoBehaviour
{
    public Camera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseScreenPosition = Input.mousePosition;
        Vector3 mouseWorldPosition = cam.ScreenToWorldPoint(mouseScreenPosition);
        mouseWorldPosition.z = 0;

        Vector3 differenceVector = mouseWorldPosition - transform.position;
        float angle = Vector2.SignedAngle(Vector2.up, differenceVector);

        transform.rotation = Quaternion.Euler(0, 0, angle);


        
    }
}
