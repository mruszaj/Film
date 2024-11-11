using Film3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace Film3.Controllers
{
    public class FIlmController : Controller
    {
        private static IList<Film> films = new List<Film>
        {
            new Film(){Id =1, Name="Film1", Description = "opis1", Price=4 },
            new Film(){Id =2, Name="Film2", Description = "opis2", Price=5 },
            new Film(){Id =3, Name="Film3", Description = "opis3", Price=6 }
        };
        // GET: FIlmController
        public ActionResult Index()
        {
            return View(films);
        }

        // GET: FIlmController/Details/5
        public ActionResult Details(int id)
        {
            return View(films.FirstOrDefault(x => x.Id == id));
        }

        // GET: FIlmController/Create
        public ActionResult Create()
        {
            return View(new Film());
        }

        // POST: FIlmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Film film)
        {
            film.Id = films.Count + 1;
          films.Add(film);
          return RedirectToAction(nameof(Index));
          
        }

        // GET: FIlmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: FIlmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
               
                              
                foreach (var item in films)
                {
                    if (item.Id.Equals(id))
                    {
                        item.Name = collection["Name"];
                        item.Description = collection["Description"];
                        item.Price = Int32.Parse(collection["Price"]);
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FIlmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FIlmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                films = films.Where(u => u.Id != id).ToList();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
