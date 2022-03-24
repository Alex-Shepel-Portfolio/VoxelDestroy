using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class Destruction : MonoBehaviour
{
    [SerializeField] private Voxel _meshVoxel;

    private float _cubWidth, _cubHeight, _cubDepth;

    [SerializeField] private float _cubeScale;

    private void VoxelParameter()
    {
        _cubWidth = transform.localScale.x;
        _cubHeight = transform.localScale.y;
        _cubDepth = transform.localScale.z;

        _meshVoxel.gameObject.GetComponent<MeshRenderer>().material = gameObject.GetComponent<MeshRenderer>().material; 

        _meshVoxel.gameObject.GetComponent<Transform>().localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);
    }

    public void CreateCube(MeshCombine meshCombine)
    {
       
        VoxelParameter();

        for (float x = 0; x < _cubWidth; x+= _cubeScale)
        {
            for (float y = 0; y < _cubHeight; y += _cubeScale)
            {
                for (float z = 0; z < _cubDepth; z += _cubeScale)
                {

                    Vector3 vec = transform.position -  new Vector3(transform.localScale.x * 0.5f , transform.localScale.y * 0.5f, transform.localScale.z * 0.5f);
                    Voxel voxel = Instantiate(_meshVoxel, vec + new Vector3(x, y, z),Quaternion.identity, transform.parent);
                    meshCombine.AddObjToCombine(voxel);

                    voxel.GetComponent<MeshRenderer>().enabled = false;
                }
            }
        }
        meshCombine.CombineMeshes();
        gameObject.GetComponent<MeshRenderer>().enabled = false;
    }
}
