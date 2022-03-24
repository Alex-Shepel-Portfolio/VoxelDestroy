using System.Collections.Generic;
using UnityEngine;

public abstract class Pool : MonoBehaviour
{
    protected void CreatePool(List<PoolObject> pool, int minCapas)
    {
        pool = new List<PoolObject>(minCapas);

        for (int i = 0; i < minCapas; i++)
        {

          //  CreateElement();
        }

    }

    //protected PoolObject CreateElement(bool isActiveByDefault = false)
    //{

    //    var createObject = Instantiate(_prefab, _container);
    //    createObject.gameObject.SetActive(isActiveByDefault);

    //    createObject.gameObject.GetComponent<Transform>().localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);
    //    createObject.gameObject.GetComponent<MeshRenderer>().material = _material;

    //    _pool.Add(createObject);
    //    return createObject;
    //}

    //public bool TryGetElement(out PoolObject element)
    //{
    //    foreach (var item in _pool)
    //    {
    //        if (item.gameObject.activeInHierarchy == false)
    //        {

    //            item.gameObject.GetComponent<Transform>().localScale = new Vector3(_cubeScale, _cubeScale, _cubeScale);
    //            item.gameObject.GetComponent<MeshRenderer>().material = _material;
    //            element = item;
    //            item.gameObject.SetActive(true);

    //            return true;
    //        }
    //    }

    //    element = null;
    //    return false;
    //}

    //public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    //{
    //    var element = GetFreeElement(position);
    //    element.transform.rotation = rotation;
    //    return element;

    //}

    //public PoolObject GetFreeElement(Vector3 position)
    //{
    //    var element = GetFreeElement();
    //    element.transform.position = position;

    //    return element;
    //}

    //public PoolObject GetFreeElement()
    //{
    //    if (TryGetElement(out var element))
    //    {
    //        return element;
    //    }
    //    if (_autoExpad)
    //    {
    //        return CreateElement(true);
    //    }
    //    if (_pool.Count < _maxCapas)
    //    {
    //        return CreateElement(true);
    //    }

    //    throw new Exception(message: "pool is  over!");
    //}

}

