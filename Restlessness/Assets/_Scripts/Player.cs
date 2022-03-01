using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;

    [SerializeField]
    private float _speed =3.5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject _muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _weaponAudio;

    [SerializeField]
    private int currentAmmo;
    private int maxAmmo = 50;

    private bool _isReLoading = false;

    private IU_Manager _uiManager;

    public bool hasCoin = false;
    
    [SerializeField]
    private GameObject _weapon;


    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        //Inicia la cantidad de balas
        currentAmmo = maxAmmo;
        _uiManager = GameObject.Find("Canvas").GetComponent<IU_Manager>();
        _uiManager.UpdateAmmo(currentAmmo);        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0) && currentAmmo > 0)
        { 
            
            Shoot();
        }
        else
        { 
            _muzzleFlash.SetActive(false);  
            _weaponAudio.Stop();
        }

        if(Input.GetKeyDown(KeyCode.R) && _isReLoading == false)
        {
            _isReLoading = true;
            StartCoroutine(Reload());
        }
        
        CalculateMovement();
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            Cursor.visible= true;
            Cursor.lockState = CursorLockMode.None;
        }
        
        if(hasCoin==true)
        {
            _uiManager.CollectCoin();
        }
        
        
    }

    void Shoot()
    {

        _muzzleFlash.SetActive(true);
        currentAmmo = currentAmmo - 1;
        _uiManager.UpdateAmmo(currentAmmo);
        if (_weaponAudio.isPlaying == false)
            {
            _weaponAudio.Play();
            }
        Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(rayOrigin, out hitInfo))
        {
            Debug.Log("Hit: " + hitInfo.transform.name);
            GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
            Destroy(hitMarker, 1F);
            //Check if we hit the create
            //Destroy Create Method
            Destructable create = hitInfo.transform.GetComponent<Destructable>();
            if(create!=null)
            {
                create.DestroyCreate();                
            }

        }
    }

    IEnumerator Reload()
    {
       yield return new WaitForSeconds (1f);
       currentAmmo = maxAmmo;
       _uiManager.UpdateAmmo(currentAmmo);
       _isReLoading = false;
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontalInput, 0, verticallInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        //Convertir el vector velocity en world space. Toma los valores de velocity en local space y pasalos a world space y nuevamente asignalos
        velocity = transform.transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }

    public void EnableWeapons()
    {
        _weapon.SetActive(true);        
    }

}
