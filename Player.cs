using UnityEngine;

public class Player : MonoBehaviour
{

    public float dodgeSpeed;
    float xInput;

    public float maxX = 1.5f;

    void Update()
    {

        xInput = Input.GetAxis("Horizontal");
        
        TouchInput();

        transform.Translate(xInput * dodgeSpeed * Time.deltaTime, 0, 0);

        float limitedX = Mathf.Clamp(transform.position.x, -maxX, maxX);

        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);

    }

    void TouchInput() {
        if (Input.GetMouseButton(0)) {
            Vector3 touchPos = Input.mousePosition;
            float middle = Screen.width / 2;
            if (touchPos.x < middle) {
                xInput = -1;
            } else if (touchPos.x > middle) {
                xInput = 1;
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            GameManager.instance.ReloadScene();
        }
    }
}
