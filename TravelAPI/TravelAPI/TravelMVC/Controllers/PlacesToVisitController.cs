using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TravelMVC.Models;

namespace TravelMVC.Controllers
{
    public class PlacesToVisitController : Controller
    {
        // GET: PlacesToVisit
        Uri baseAddress = new Uri("https://localhost:44391/api");
        HttpClient client;
        public PlacesToVisitController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            List<PlacesToVisit> l = new List<PlacesToVisit>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/PlacesToVisit").Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<List<PlacesToVisit>>(Data);
            }
            return View(l);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PlacesToVisit model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseAddress + "/PlacesToVisit", Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            PlacesToVisit l = new PlacesToVisit();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/PlacesToVisit/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<PlacesToVisit>(Data);
            }
            return View(l);
        }
        [HttpPost]
        public ActionResult Edit(PlacesToVisit model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseAddress + "/PlacesToVisit/" + model.PlaceId, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            PlacesToVisit l = new PlacesToVisit();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/PlacesToVisit/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<PlacesToVisit>(Data);


            }
            return View(l);
        }


    }
}