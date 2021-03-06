﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RestSharp;
using RestSharp.Deserializers;
using System.Xml;
using System.Xml.Linq;
using CBApi.Models.Responses;
using System.IO;

namespace Tests.CBApi.models {
    [TestClass]
    public class ResponseJobSearchTest {
        [TestMethod]
        [DeploymentItem("testdata\\ResponseJobSearch.xml")]
        public void DeserializationWorks_WhenPassedRightXML() {
            var xmlpath = Path.Combine(Environment.CurrentDirectory,"ResponseJobSearch.xml");
            var doc = XDocument.Load(xmlpath);

            var xml = new XmlDeserializer();
            var output = xml.Deserialize<ResponseJobSearch>(new RestResponse() { Content = doc.ToString() });

            Assert.IsNotNull(output);
            Assert.AreEqual(386163, output.TotalCount);
            Assert.AreEqual(15447, output.TotalPages);
            Assert.AreEqual(1, output.FirstItemIndex);
            Assert.AreEqual(25, output.LastItemIndex);

            Assert.IsNotNull(output.Results);
            Assert.AreEqual(25, output.Results.Count);

        }
    }
}
