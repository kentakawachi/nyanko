using UnityEngine;

public class Tensi : MonoBehaviour
{
    public float floatSpeed = 1f;
    public float horizontalAmplitude = 0.5f;
    public float horizontalFrequency = 1f;
    private float initialX;
    private float elapsedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       initialX = transform.position.x;
       elapsedTime = 0f;  
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        float newY = transform.position.y + floatSpeed * Time.deltaTime;
        float offsetX = Mathf.Sin(elapsedTime * horizontalFrequency) * horizontalAmplitude;
        float newX = initialX + offsetX;
        transform.position = new Vector3(newX, newY, transform.position.z);

        if (!IsVisibleFrom(Camera.main))
        {
            Destroy(gameObject);
        }
    }
     bool IsVisibleFrom(Camera camera)
    {
        Vector3 screenPoint = camera.WorldToViewportPoint(transform.position);
        return screenPoint.y <= 1.1f;
    }
}
