using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TestAssignment
{
    public class Road : MonoBehaviour
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private Transform _plane;
        [SerializeField] private Transform _leftBorder;
        [SerializeField] private Transform _rightBorder;

        private readonly float bordersOffset = 0.07f;
        
        private void Awake()
        {
            var scale = _plane.localScale;
            scale.x = _gameSettings.RoadWidth * 2 / 10f;
            _plane.localScale = scale;
            
            var leftBorderPosition = _leftBorder.position;
            leftBorderPosition.x = -(_gameSettings.RoadWidth + bordersOffset);
            _leftBorder.position = leftBorderPosition;
            
            var rightBorderPosition = _rightBorder.position;
            rightBorderPosition.x = _gameSettings.RoadWidth + bordersOffset;
            _rightBorder.position = rightBorderPosition;
        }
    }
}
