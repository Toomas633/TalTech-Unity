﻿using Zinnia.Tracking.Follow;
using Zinnia.Tracking.Follow.Operation.Extraction;

namespace Test.Zinnia.Tracking.Follow.Operation.Extraction
{
    using NUnit.Framework;
    using Test.Zinnia.Utility.Mock;
    using UnityEngine;

    public class ObjectFollowerEventDataSourceExtractorTest
    {
        private GameObject containingObject;
        private ObjectFollowerEventDataSourceExtractor subject;

        [SetUp]
        public void SetUp()
        {
            containingObject = new GameObject("ObjectFollowerEventDataSourceExtractorTest");
            subject = containingObject.AddComponent<ObjectFollowerEventDataSourceExtractor>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(containingObject);
        }

        [Test]
        public void Extract()
        {
            GameObject source = new GameObject();

            UnityEventListenerMock extractedMock = new UnityEventListenerMock();
            subject.Extracted.AddListener(extractedMock.Listen);

            ObjectFollower.EventData eventData = new ObjectFollower.EventData
            {
                EventSource = source
            };

            Assert.IsFalse(extractedMock.Received);
            Assert.IsNull(subject.Result);

            subject.Extract(eventData);

            Assert.IsTrue(extractedMock.Received);
            Assert.AreEqual(subject.Result, source);

            Object.DestroyImmediate(source);
        }
    }
}