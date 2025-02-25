using UnityEngine;

public class Fire : MonoBehaviour
{
    public float range = 100f;
    public Camera cam;
    public float fireRate = 0.5f; // Taxa de tiro em segundos (ex: 0.5 = 2 tiros por segundo)
    public PlayerScriptableObject playerData;
    private float nextFireTime = 0f; // Tempo para o próximo tiro
    public GameObject weaponPistol; 
    public GameObject weaponSub;
    private AudioSource audio;
    void Start()
    {
        fireRate = playerData.fireRate;
        if (cam == null)
        {
            cam = Camera.main;
            if (cam == null)
            {
                Debug.LogError("Câmera não atribuída e não encontrada!");
                enabled = false;
                return;
            }
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFireTime)
        {
            FireRaycast();
            nextFireTime = Time.time + fireRate; // Define o tempo para o próximo tiro
        }
        SetWeapon();
    }

    void SetWeapon(){
        switch (fireRate)
        {
            case 0:
                weaponPistol.SetActive(false);
                weaponSub.SetActive(false);
                break;
            case 0.5f:
                weaponPistol.SetActive(true);
                weaponSub.SetActive(false);
                audio = weaponPistol.GetComponent<AudioSource>();
                break;
            default:
                weaponPistol.SetActive(false);
                weaponSub.SetActive(true);
                audio = weaponSub.GetComponent<AudioSource>();
                break;
        }
    }

    void FireRaycast()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, range))
        {
            GameObject target = hit.collider.gameObject;

            if (target.CompareTag("Enemy"))
            {
                audio.Play();
                Destroy(target,2f);
                Debug.Log("Inimigo atingido e destruído!");
                playerData.points += 100;
            }
            else
            {
                Debug.Log("Objeto atingido: " + target.name);
            }
        }
        else
        {
            Debug.Log("Nenhum objeto atingido.");
        }
    }
}