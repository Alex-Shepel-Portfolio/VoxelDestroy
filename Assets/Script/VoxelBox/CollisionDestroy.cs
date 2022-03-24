using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{

    //entered voxel 
    private Collider[] hitColliders;


    [SerializeField] private float blastRadius, explosionPower;
    [SerializeField] private LayerMask explosionLayer;
   
    private Vector3 direction;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Voxel>() != null)
        {

            direction = transform.forward;
            
            Destroy(collision.contacts[0].point);
            
        }
    }

    private void Destroy(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayer);

        foreach (Collider HitCol in hitColliders)
        {

            HitCol.gameObject.GetComponent<Voxel>().DestroyVoxel(direction);
            Rigidbody rigidbody = HitCol.attachedRigidbody;
            rigidbody.AddExplosionForce(explosionPower, transform.position, blastRadius / 10, 1f, ForceMode.Impulse);
        }
        hitColliders = null;
    }
}
