using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    public float speed;
    public float lifeTime;

    void Start()
    {
        Invoke("DestroyFireball", lifeTime);
    }


    void FixedUpdate()
    {
        MoveFoxedUpdate();
    }


    public void MoveFoxedUpdate()
    {
        transform.position += transform.forward * speed * Time.fixedDeltaTime;
    }

    public void OnCollisionEnter(Collision collision)
    {
        DestroyFireball();
    }


    public void DestroyFireball()
    {
        Destroy(gameObject);
    }
}
