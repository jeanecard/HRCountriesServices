using HRCountriesServicesSolution.Business;
using HRCountriesServicesSolution.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRCountriesServicesTests.BUSINESS.HRWebCamsTravel
{
    [TestClass]
    public class WebCamsTravelRestResponseAnalyserTest
    {
        static Webcam notActiveCam = new Webcam() { status = "not active" };
        static Webcam noLifeTimeCam = new Webcam() {  player = new Player() {  lifetime = null} };
        static Webcam noEmbeded = new Webcam() { player = new Player() { lifetime = new Lifetime() {  embed = String.Empty} } };
        static Webcam parisCam = new Webcam() { title = "ParisCam",   player = new Player() { lifetime = new Lifetime() { embed = "Embeded" } } };
        static WebCamsTravelRestResponseAnalyser analyser = new WebCamsTravelRestResponseAnalyser();

        [TestMethod]
        public void Test_WebCamsTravelRestResponseAnalyser_GetBestFittingWebCam_Return_Empty_When_Entry_Is_Null()
        {
            List<Webcam> retour = analyser.GetBestFittingWebCam(null);
            Assert.IsNotNull(retour);
            Assert.AreEqual(0, retour.Count);
        }
        [TestMethod]
        public void Test_WebCamsTravelRestResponseAnalyser_GetBestFittingWebCam_Return_Empty_When_Entry_Is_Empty()
        {
            List<Webcam> retour = analyser.GetBestFittingWebCam(new List<Webcam>());
            Assert.IsNotNull(retour);
            Assert.AreEqual(0, retour.Count);
        }
        [TestMethod]
        public void Test_WebCamsTravelRestResponseAnalyser_GetBestFittingWebCam_Return_Empty_When_Entry_Has_No_Cam_Active()
        {
            List<Webcam> list = new List<Webcam>();
            list.Add(notActiveCam);
            List<Webcam> retour = analyser.GetBestFittingWebCam(list);
            Assert.IsNotNull(retour);
            Assert.AreEqual(0, retour.Count);

        }
        [TestMethod]
        public void Test_WebCamsTravelRestResponseAnalyser_GetBestFittingWebCam_Return_Empty_When_Entry_Has_No_Lifetime_Cam()
        {
            List<Webcam> list = new List<Webcam>();
            list.Add(noLifeTimeCam);
            List<Webcam> retour = analyser.GetBestFittingWebCam(list);
            Assert.IsNotNull(retour);
            Assert.AreEqual(0, retour.Count);

        }
        public void Test_WebCamsTravelRestResponseAnalyser_GetBestFittingWebCam_Return_Empty_When_Entry_Has_No_Lifetime_Emeded()
        {
            List<Webcam> list = new List<Webcam>();
            list.Add(noEmbeded);
            List<Webcam> retour = analyser.GetBestFittingWebCam(list);
            Assert.IsNotNull(retour);
            Assert.AreEqual(0, retour.Count);

        }
        public void Test_WebCamsTravelRestResponseAnalyser_GetBestFittingWebCam_Return_Paris_When_Entry_Has_OnlyParis_OK()
        {
            List<Webcam> list = new List<Webcam>();
            list.Add(notActiveCam);
            list.Add(noLifeTimeCam);
            list.Add(noEmbeded);
            list.Add(parisCam);
            List<Webcam> retour = analyser.GetBestFittingWebCam(list);
            Assert.IsNotNull(retour);
            Assert.AreEqual(1, retour.Count);
        }
    }
}
