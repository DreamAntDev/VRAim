using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class Tests_Timer
    {
        [Test]
        [TestCase(300.00, 280)]
        [TestCase(300.00, 299)]
        [TestCase(300.00, 300)]
        [TestCase(300.00, 1)]
        [TestCase(30.00, 25)]
        [TestCase(30.00, 30)]
        public void Timer_TimerWhileCountIfTrue_Bool(double baseTime, int applyTime)
        {
            double currentTime = baseTime - applyTime;
            
            TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
            string formattedTime = timeSpan.ToString(@"mm\:ss");

            Debug.Log($"{currentTime} = {formattedTime}");
            
            if (Mathf.Approximately((float)currentTime, 0))
            {
                Debug.Log("Timer End");
                Assert.IsTrue(currentTime == 0);
            }
        }
    }
}
