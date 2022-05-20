using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] 
    Transform _firstPersonCamera;
    [SerializeField] [Range(25f, 200f)] 
    float _range = 100f;

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
        Physics.Raycast(_firstPersonCamera.position, _firstPersonCamera.forward, out hit, _range);
        if (hit.transform)
            Debug.Log($"Player1 just shot {hit.transform.name} with {name}");
        
    }
}
