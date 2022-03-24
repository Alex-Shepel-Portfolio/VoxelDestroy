using UnityEngine;

public class Gun : MonoBehaviour
{


    //Gun stats
    [SerializeField,Range(0.1f,1.5f)] private float _timeBetweenShooting;
    [SerializeField, Range(1, 4)] private int _range;
    [SerializeField, Range(35f, 200f)] private float _bullSpeed = 35f;                                                  
    //bools 
    [SerializeField] private bool _autoShoting; 
    private bool shooting, readyToShoot;

    //Reference
    [SerializeField] private Transform _shootPoint;

    //bullet
    [SerializeField] private Bullet _bullPref;

    private Camera _camMain;

    private void Awake()
    {
        readyToShoot = true;
    }

    private void Start()
    {
        _camMain = Camera.main;
    }
    private void Update()
    {
        MyInput();

    }

    private void MyInput()
    {
        if(_autoShoting)
        shooting = Input.GetKey(KeyCode.Mouse0);
        else
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

        //Shoot
        if (readyToShoot && shooting)
        {

            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //instalise bullet
        for (int i = 0; i < _range; i++)
        {
            GameObject bullet = (GameObject)Instantiate(_bullPref.gameObject, _shootPoint.position , Quaternion.identity);
            bullet.gameObject.GetComponent<Rigidbody>().velocity = _camMain.transform.forward * _bullSpeed;
        }
        
        Invoke("ResetShot", _timeBetweenShooting);

    }

    private void ResetShot()
    {
        readyToShoot = true;
    }


}
