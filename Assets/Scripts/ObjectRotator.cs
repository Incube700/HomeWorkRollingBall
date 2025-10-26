using System;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
    { 
        [SerializeField] private float _rotateSpeed = 180f;
        [SerializeField] private Vector3 _axis = Vector3.up;

        private void Update()
        {
            transform.Rotate(_axis, _rotateSpeed * Time.deltaTime, Space.World);
        }
    }
