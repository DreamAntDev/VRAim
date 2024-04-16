using System.Collections.Generic;
using NUnit.Framework;
using UnityEditorInternal;
using UnityEngine;

namespace Tests
{
    public class Tests_TargetInfo
    {
        private ITargetInfo _targetInfo;

        [Test]
        public void Angle_RespawnCountTwoRandomAngle_Floats()
        {
            _targetInfo = new TargetInfo();
            List<float> expectedValues = new List<float> { 0, 180, 360 };
            CollectionAssert.Contains(expectedValues, _targetInfo.GetTargetAngle(2));
        }

        [Test]
        public void Angle_RespawnCountFourRandomAngle_Floats()
        {
            _targetInfo = new TargetInfo();

            List<float> expectedValues = new List<float> { 0, 90, 180, 270, 360 };
            CollectionAssert.Contains(expectedValues, _targetInfo.GetTargetAngle(4));
        }

        [Test]
        public void Angle_RespawnCountEightRandomAngle_Floats()
        {
            _targetInfo = new TargetInfo();
            List<float> expectedValues = new List<float> { 0, 45, 90, 135, 180, 225, 270, 315, 360 };
            CollectionAssert.Contains(expectedValues, _targetInfo.GetTargetAngle(8));
        }

        [Test]
        public void Angle_RespawnCountSixteenRandomAngle_Floats()
        {
            _targetInfo = new TargetInfo();

            List<float> expectedValues = new List<float>
            {
                0, 22.5f, 45, 67.5f, 90, 112.5f, 135, 157.5f, 180, 202.5f, 225, 247.5f, 270, 292.5f, 315, 337.5f, 360
            };
            CollectionAssert.Contains(expectedValues, _targetInfo.GetTargetAngle(16));
        }
    }
}

