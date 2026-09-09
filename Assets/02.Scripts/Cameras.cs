using System.Collections.Generic;
using UnityEngine;

namespace _02.Scripts
{
    public class Cameras
    {
        private static Camera _camera;      // 캐싱
        private static float _shakeX = 0;
        private static float _shakeY = 0;
        private static float _time = 0.5f;
        private static float _timer = 0f;
        private static bool _isShaking = false;
        public static void StartShake()
        {
            _camera = Camera.main;
            _timer = 0f;
            _isShaking = true;
        }
        public static void CameraShake()
        {
            if (!_isShaking) return;

            if (_timer < _time)
            {
                _shakeX = UnityEngine.Random.Range(-0.2f, 0.2f);
                _shakeY = UnityEngine.Random.Range(-0.2f, 0.2f);
                _camera.transform.position = new Vector3(_shakeX, _shakeY, _camera.transform.position.z);
                _timer += Time.deltaTime;
                return;
            }

            _camera.transform.position = new Vector3(0, 0, _camera.transform.position.z);
            _timer = 0;
            _isShaking = false;
        }
    }
}