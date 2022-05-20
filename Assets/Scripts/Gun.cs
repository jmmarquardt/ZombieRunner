using UnityEngine;
using UnityEngine.Android;

public class Gun : MonoBehaviour
{
    [SerializeField] 
    Transform _firstPersonCamera;
    [SerializeField] [Range(25f, 200f)] 
    float _range = 100f;

    [SerializeField] [Range(0f, 100f)] float _damage = 20f;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        
        if (!Physics.Raycast(_firstPersonCamera.position, _firstPersonCamera.forward, out hit, _range)) return;
        
        Debug.Log($"Player1 just shot {hit.transform.name} with {name}");
        // TODO: Add hit effect 
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target == null) return;
        target.TakeDamage(_damage);
    }
}
