using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunExtended : MonoBehaviour
{
    //Gun stats
    [SerializeField, Range(0.1f, 3f)] private float _timeBetweenShooting, _reloadTime, _timeBetweenShoots;
    [SerializeField, Range(35f, 200f)] private float _bullSpeed = 35f;
    [SerializeField, Range(0f, 200f)] private float _upwardForce;
    [SerializeField, Range(0f, 10f)] private float _spread;
    [SerializeField, Range(1, 300)] private int _magazineSize;
    [SerializeField, Range(1, 10)] private int _bulletsPerTap;

    private int _bulletsLeft, _bulletsShot;

   //bools 
   [SerializeField] private bool _autoShoting;
    private bool _shooting, _readyToShoot, _reloading;

    //Reference
    [SerializeField] private Transform _shootPoint;

    //bullet
    [SerializeField] private CustomBullet _bullPref;

    //Grafics
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private TextMeshProUGUI _ammunitionDisplay;


  private Camera _camMain;

    private Animator _anim;

    private bool aloowInvoke = true;
    private void Awake()
    {
        _bulletsLeft = _magazineSize;
        _readyToShoot = true;
    }

    private void Start()
    {

        _camMain = Camera.main;
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        MyInput();
        if(_ammunitionDisplay != null)
        {
            _ammunitionDisplay.SetText(_bulletsLeft / _bulletsPerTap + "/" + " " + _magazineSize/_bulletsPerTap);
        }
    }

    private void MyInput()
    {
        if (_autoShoting)
            _shooting = Input.GetKey(KeyCode.Mouse0);
        else
            _shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) &&_bulletsLeft < _magazineSize && !_reloading)
        {
            Reload();
           
        }

        if(_readyToShoot && _shooting && !_reloading && _bulletsLeft <=0) Reload();

        //Shoot
        if (_readyToShoot && _shooting && !_reloading && _bulletsLeft > 0)
        {
            _bulletsShot = 0;
            Shoot();
        }
    }

    private void Shoot()
    {
        _readyToShoot = false;

        

        Ray ray = _camMain.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        Vector3 targetPoint;
        if(Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
        }
        else
        {
            targetPoint = ray.GetPoint(75);
        }

        Vector3 directionWithoutSpread = targetPoint - _shootPoint.position;

        //Calculate spread
        float x = Random.Range(-_spread, _spread);
        float y = Random.Range(-_spread, _spread);

        Vector3 directionWithtSpread = directionWithoutSpread + new Vector3(x, y, 0f);


        GameObject currentbullet = (GameObject)Instantiate(_bullPref.gameObject, _shootPoint.position, Quaternion.identity);
        currentbullet.transform.forward = directionWithtSpread.normalized; 

        //currentbullet.GetComponent<Rigidbody>().velocity = directionWithtSpread.normalized * _bullSpeed;
        currentbullet.GetComponent<Rigidbody>().AddForce(directionWithtSpread.normalized * _bullSpeed, ForceMode.Impulse);
        currentbullet.GetComponent<Rigidbody>().AddForce(_camMain.transform.up * _upwardForce, ForceMode.Impulse);

        if(_muzzleFlash != null)
        {
            _muzzleFlash.SetActive(true);
            //Instantiate(_muzzleFlash, _shootPoint.position, Quaternion.identity);

        }

        _bulletsLeft--;
        _bulletsShot++;

        if(aloowInvoke)
       
        {
            Invoke("ResetShot", _timeBetweenShooting);
            aloowInvoke = false;
        }

        if(_bulletsShot < _bulletsPerTap && _bulletsLeft  > 0)
        {
            Invoke("Shoot", _timeBetweenShoots);
        }
    }

    private void ResetShot()
    {
        _muzzleFlash.SetActive(false);
        _readyToShoot = true;
        aloowInvoke = true;
    }

    private void Reload()
    {
        _anim.SetTrigger("Reload");
        _reloading = true;
        Invoke("ReloadFineshed", _reloadTime);
    }

    private void ReloadFineshed()
    {
        _bulletsLeft = _magazineSize;
        _reloading = false;
    }

}

