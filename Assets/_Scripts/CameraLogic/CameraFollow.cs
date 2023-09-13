using System;
using Unity.VisualScripting;
using UnityEngine;

namespace _Scripts.CameraLogic {
    public class CameraFollow : MonoBehaviour {
        public float RotationAngleX;
        public float Distance;
        public float OffsetY;
        
        [SerializeField] private Transform _following;

        private void LateUpdate() {
            if (_following == null) return;
            Quaternion rotation = Quaternion.Euler(RotationAngleX, 0, 0);
            
            Vector3 position = rotation * new Vector3(0, 0, -Distance) + FollowingPointPosition();

            transform.rotation = rotation;
            transform.position = position;
        }

        public void Follow(GameObject following) => _following = following.transform;

        private Vector3 FollowingPointPosition() {
            Vector3 _followingPosition = _following.position;
            _followingPosition.y += OffsetY;
            
            return _followingPosition;
        }
    }
}