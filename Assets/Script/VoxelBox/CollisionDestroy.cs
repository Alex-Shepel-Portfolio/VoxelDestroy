using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{

    //entered voxel 
    private Collider[] hitColliders;


    [SerializeField] private float _blastRadius, _explosionPower;
    [SerializeField] private LayerMask _explosionLayer;
   
    private Vector3 _direction;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<Voxel>() != null)
        {

            _direction = transform.forward;
            
            Destroy(collision.contacts[0].point);
            
        }
    }

    private void Destroy(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, _blastRadius, _explosionLayer);

        foreach (Collider HitCol in hitColliders)
        {

            HitCol.gameObject.GetComponent<Voxel>().DestroyVoxel(_direction);
            Rigidbody rigidbody = HitCol.attachedRigidbody;
            rigidbody.AddExplosionForce(_explosionPower, transform.position, _blastRadius, 1f, ForceMode.Impulse);
        }
        hitColliders = null;
    }
}
