using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Shared.DomainModel.Entities;

namespace MovieMVCApp.Controllers
{
    public class MovieController : Controller
    {
        private string baseAddress = "https://localhost:44395/api/Movie/";

        public MovieController()
        {
            
        }

        // GET: Movie
        public async Task<IActionResult> Index()
        {
            HttpClient client = new(); //c#9

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, baseAddress);
            HttpResponseMessage response = await client.SendAsync(request);
            string jsonText = await response.Content.ReadAsStringAsync();


            List<Movie> movies = JsonConvert.DeserializeObject<List<Movie>>(jsonText);

            return View(movies);
        }

        // GET: Movie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string url = baseAddress + id.Value.ToString();

            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(jsonText);
            }

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movie/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Genre")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                string jsonText = JsonConvert.SerializeObject(movie);

                StringContent data = new StringContent(jsonText, Encoding.UTF8, "application/json");

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.PostAsync(baseAddress, data);
                    string result = await response.Content.ReadAsStringAsync();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string url = baseAddress + id.Value.ToString();

            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(jsonText);
            }

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Genre")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    string url = baseAddress + id;
                    string json = JsonConvert.SerializeObject(movie);

                    StringContent data = new StringContent(json, Encoding.UTF8, "application/json");

                    using(HttpClient client =new HttpClient())
                    {
                        var response = client.PutAsync(url, data);
                        string result = await response.Result.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception)
                {
                   
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            string url = baseAddress + id.Value.ToString();

            Movie movie = null;
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(url);
                string jsonText = await response.Content.ReadAsStringAsync();
                movie = JsonConvert.DeserializeObject<Movie>(jsonText);
            }

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string url = baseAddress + id.ToString();

            using (HttpClient client = new())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                string result = await response.Content.ReadAsStringAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        
    }
}
