using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float lifeTime;


    private void Start()
    {
        StartCoroutine(Destroy());
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.GetComponent<CollisionDestroy>() == null)
            Destroy(this.gameObject);
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(lifeTime);
        Destroy(gameObject);
    }

}
