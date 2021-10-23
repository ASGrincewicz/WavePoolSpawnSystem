// Aaron Grincewicz ASGrincewicz@icloud.com 10/18/2021
using UnityEngine;
namespace Grincewicz.SpawnSystem
{
    public class Cube : MonoBehaviour
    {
        public int lifespan = 3;
        public float speed = 2f;
        public Vector3 moveDirection;
        private Transform _transform;
        private float _deltaTime;
        private void Start()
        {
            _transform = transform;
            Invoke(nameof(DeactivateObject), lifespan) ;
        }

        private void Update()
        {
            _deltaTime = Time.deltaTime;
            _transform.Translate(moveDirection * (speed * _deltaTime));
        }

        private void DeactivateObject()
        {
            gameObject.SetActive(false);
        }
    }
}