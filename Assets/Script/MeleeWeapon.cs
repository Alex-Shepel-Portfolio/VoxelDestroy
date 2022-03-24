using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{

    private Animator _anim;

    private const float DOBLE_CLICK_TIME = 0.2f;
    private float _lastClickTime;

    private void Start()
    {
        _anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Atack();

        }
    }

    private void Atack()
    {
        float timeSinceLastClick = Time.time - _lastClickTime;

        if (timeSinceLastClick < DOBLE_CLICK_TIME)
            _anim.SetTrigger("Atack2");
        else
            _anim.SetTrigger("Atack1");

        _lastClickTime = Time.time;
    }

    
}
