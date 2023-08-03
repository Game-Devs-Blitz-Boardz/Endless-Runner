using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed;

    void Update()
    {
        transform.Translate(0, 0, -speed * Time.deltaTime);

        if (transform.position.z < -10f) {
            GameManager.instance.ScoreUp();
            Destroy(gameObject);
        }

    }



}
