using UnityEngine;

public class Kameraidou : MonoBehaviour
{
    public float scrollSpeed = 10f;
    public float minX = -0f;
    public float maxX = 50f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        Vector3 newPos = transform.position + Vector3.right * horizontal * scrollSpeed * Time.deltaTime;
        // Vector3 newPos = transform.position + Vector3.right * -0.01f;
        newPos.x = Mathf.Clamp(newPos.x, minX, maxX);
        transform.position = newPos;
    }
}
