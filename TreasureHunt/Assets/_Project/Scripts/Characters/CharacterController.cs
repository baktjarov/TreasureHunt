/*using UnityEngine;

namespace Characters
{
    public class CharacterController : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Animator _animator;

        private MouseController _mouseController;

        private void Awake()
        {
            _mouseController = FindObjectOfType<MouseController>();
        }

        private void Update()
        {
            AnimateMovement();
        }

        private void AnimateMovement()
        {
            if (_mouseController._isMoving == true)
            {
                _animator.SetFloat("Forward", _mouseController._magnitude);
            }
            else
            {
                _animator.SetFloat("Forward", 0);
            }

        }
    }
}*/