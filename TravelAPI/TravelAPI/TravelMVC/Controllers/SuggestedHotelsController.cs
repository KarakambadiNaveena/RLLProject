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
    public class SuggestedHotelsController : Controller
    {
        // GET: SuggestedHotels
        Uri baseAddress = new Uri("https://localhost:44391/api");
        HttpClient client;
        public SuggestedHotelsController()
        {
            client = new HttpClient();
            client.BaseAddress = baseAddress;
        }
        public ActionResult Index()
        {
            List<SuggestedHotels> l = new List<SuggestedHotels>();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/SuggestedHotels").Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<List<SuggestedHotels>>(Data);
            }
            return View(l);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(SuggestedHotels model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(baseAddress + "/SuggestedHotels", Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            SuggestedHotels l = new SuggestedHotels();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/SuggestedHotels/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<SuggestedHotels>(Data);
            }
            return View(l);
        }
        [HttpPost]
        public ActionResult Edit(SuggestedHotels model)
        {
            string data = JsonConvert.SerializeObject(model);
            StringContent Content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PutAsync(baseAddress + "/SuggestedHotels/" + model.HotelId, Content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            SuggestedHotels l = new SuggestedHotels();
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/SuggestedHotels/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                String Data = response.Content.ReadAsStringAsync().Result;
                l = JsonConvert.DeserializeObject<SuggestedHotels>(Data);


            }
            return View(l);
        }


    }
}