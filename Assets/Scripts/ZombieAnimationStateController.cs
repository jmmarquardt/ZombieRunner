
using UnityEngine;

public class ZombieAnimationStateController : MonoBehaviour
{
    Animator _animator;

    void Awake() 
    {
        _animator = GetComponent<Animator>();    
    }
    
}
