using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] Transform _firstPersonCamera;
    [SerializeField] float _range = 100f;

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
        Debug.Log($"Player1 just shot {hit.transform.name} with {name}");
    }
}
