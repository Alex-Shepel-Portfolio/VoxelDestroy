using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class VoxelBox : MonoBehaviour
{

   [SerializeField] private Destruction _desroyedBox;
   [SerializeField] private MeshCombine _meshCombine;
    private MeshCombine meshCombine;
    private void Awake()
    {
        meshCombine = Instantiate(_meshCombine, Vector3.zero, Quaternion.identity, transform);
    }

    private void Start()
    {
        SetMeterial();
        _desroyedBox.CreateCube(meshCombine);
    }

    public void DestroyVoxel(Voxel destroed)
    {
        meshCombine.RemoveObjToCombine(destroed);
    }

    private void SetMeterial()
    {
        meshCombine.GetComponent<MeshRenderer>().material = _desroyedBox.GetComponent<MeshRenderer>().material;
        
    }

}
