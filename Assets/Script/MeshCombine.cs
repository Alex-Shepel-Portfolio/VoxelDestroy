using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class MeshCombine : MonoBehaviour
{
    [SerializeField] private List<Voxel> _combineObjects = new List<Voxel>();
    [SerializeField] private MeshFilter _targetMeshFilter;

    public void AddObjToCombine(Voxel voxel)
    {
   
        _combineObjects.Add(voxel);
    }
    public void CombineMeshes()
    {
        var combines = new CombineInstance[_combineObjects.Count];
        for (int i = 0; i < _combineObjects.Count; i++)
        {
            combines[i].mesh = _combineObjects[i].GetComponent<MeshFilter>().sharedMesh;
            combines[i].transform = _combineObjects[i].transform.localToWorldMatrix;
        }

        var mesh = new Mesh();
        mesh.CombineMeshes(combines);
        _targetMeshFilter.mesh = mesh;

    }

    public void RemoveObjToCombine(Voxel voxel)
    {
        _combineObjects.Remove(voxel);
        CombineMeshes();
    }

}
