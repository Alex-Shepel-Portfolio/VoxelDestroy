using System.Collections.Generic;
using UnityEngine;
using System;


//For dinamic creation VOXELBOX
//NOT USING NOW!

public class PoolVoxel : MonoBehaviour
{
  
    //pool Object
    [SerializeField] private PoolObject _prefab;

    [Space(10)] [SerializeField] private Transform _container;
    [SerializeField] private int _minCapas, _maxCapas;

    //dinamic or Static pool
    [Space(10)] [SerializeField] private bool _autoExpad;

    

    //pool List
    private List<PoolObject> _pool;

    private float _cubeScale;
    private Material _material;

    private void OnValidate()
    {
        if (_autoExpad) _maxCapas = Int32.MaxValue;
    }

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        _pool = new List<PoolObject>(_minCapas);

        for (int i = 0; i < _minCapas; i++)
        {
            
            CreateElement();
        }
        
    }

    public void Setings(float cubeScale, Material material)
    {
        _cubeScale = cubeScale;
        _material = material;
       

    }

    private PoolObject CreateElement(bool isActiveByDefault = false)
    {
        
        var createObject = Instantiate(_prefab, _container);
        createObject.gameObject.SetActive(isActiveByDefault);

        createObject.gameObject.GetComponent<Transform>().localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);
        createObject.gameObject.GetComponent<MeshRenderer>().material = _material;

        _pool.Add(createObject);
        return createObject;
    }

    public bool TryGetElement(out PoolObject element)
    {
        foreach (var item in _pool)
        {
            if (item.gameObject.activeInHierarchy == false)
            {
                
                item.gameObject.GetComponent<Transform>().localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);
                item.gameObject.GetComponent<MeshRenderer>().material = _material;
                element = item;
                item.gameObject.SetActive(true);
                
                return true;
            }
        }

        element = null;
        return false;
    }

    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;

    }

    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;

        return element;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }
        if (_autoExpad)
        {
            return CreateElement(true);
        }
        if (_pool.Count < _maxCapas)
        {
            return CreateElement(true);
        }

        throw new Exception(message: "pool is  over!");
    }

}

