using UnityEngine;

public class CustomBullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _bulletRb;
    //Stats
    [SerializeField, Range(0f, 1f)]
    private float _bounciness;
    [SerializeField] private bool _useGravity;

    //Damage
   // [SerializeField] private float _explosionRange;

    //LifeTime
    [SerializeField] private int _maxCollisions;
    [SerializeField] private float _maxLifeTime;
    [SerializeField] private bool _explodeOnTouch = true;

    private int _collisions;
    private PhysicMaterial _physicMaterial;


    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        if(_collisions > _maxCollisions)
        {
            Explode();
        }

        _maxLifeTime -= Time.deltaTime;
        if(_maxLifeTime <= 0)
        {
            Explode();
        }

    }

    private void Explode()
    {
        Delay();
    }

    private void Delay()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_explodeOnTouch) Explode();


        _collisions++;

    }


    private void Setup()
    {
        _physicMaterial = new PhysicMaterial();
        _physicMaterial.bounciness = _bounciness;
        _physicMaterial.frictionCombine = PhysicMaterialCombine.Minimum;
        _physicMaterial.bounceCombine = PhysicMaterialCombine.Maximum;

        GetComponent<SphereCollider>().material = _physicMaterial;

        _bulletRb.useGravity = _useGravity;

    }
}
