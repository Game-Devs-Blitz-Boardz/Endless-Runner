using UnityEngine;

public class Player : MonoBehaviour
{

    public float dodgeSpeed;
    float xInput;

    public float maxX = 1.5f;

    void Start()
    {
        
    }

    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        transform.Translate(xInput * dodgeSpeed * Time.deltaTime, 0, 0);

        float limitedX = Mathf.Clamp(transform.position.x, -maxX, maxX);

        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);

    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            GameManager.instance.ReloadScene();
        }
    }
}
