using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voxel : MonoBehaviour
{
    private Rigidbody _voxeRb;

    [SerializeField] private float _lifeTime;
    private VoxelBox _meshCombine;

    void Start()
    {
        _voxeRb = GetComponent<Rigidbody>();
        _meshCombine = transform.parent.GetComponent<VoxelBox>();
    }

    public void DestroyVoxel(Vector3 directionExplosion)
    {

        if (_voxeRb.isKinematic)
        {
            
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            _meshCombine.DestroyVoxel(this);
            _voxeRb.mass = 30;
            _voxeRb.isKinematic = false;
            _voxeRb.velocity = directionExplosion * 5;
            StartCoroutine(Destroy());
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(_lifeTime);
        Destroy(gameObject);    
    }
}

