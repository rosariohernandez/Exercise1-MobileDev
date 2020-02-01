using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class SpeciesController : Controller
    {
        private PetGroomingContext db = new PetGroomingContext();
        // GET: Species
        public ActionResult Index()
        {
            return View();
        }


        // List Species  
        public ActionResult List()
        {

            List<Species> myspecies = db.Species.SqlQuery("Select * from species").ToList();

            return View(myspecies);
        }

        // Show Species
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Species species = db.Species.SqlQuery("select * from species where speciesid=@SpeciesID", new SqlParameter("@SpeciesID", id)).FirstOrDefault();
            if (species == null)
            {
                return HttpNotFound();
            }
            return View(species);
        }


        // Add Species
        public ActionResult Add()
        {
            return View();
        }

        // HttpPost Add Species
        [HttpPost]

        public ActionResult Add(string SpeciesName)
        {
            string query = "insert into species (SpeciesName) values (@SpeciesName)";
            SqlParameter[] sqlparams = new SqlParameter[1];
            SqlParameter[] params = new SqlParameter("@SpeciesName", SpeciesName);

            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }

        //Update Species
        public ActionResult Update(int id)
        {

            Pet selecedspecies = db.Species.SqlQuery("select * from species where speciesid = @id", new SqlParameter("@id", id)).FirstOrDefault();

            UpdateSpecies viewmodel = new UpdateSpecies();
            viewmodel.species = selectedpet species;

            return View(viewmodel);
        }

        // Http Update Species
        [HttpPost]
        public ActionResult Update(string SpeciesName)
        {

            string query = "update species set SpeciesName = '@SpeciesName' where SpeciesID=@id";
            SqlParameter parameters = new SqlParameter[1];

            SqlParameter parameters = new SqlParameter("@SpeciesName", SpeciesName);


            db.Database.ExecuteSqlCommand(query, parameters);

            //This action redirects the page back to a list of species
            return RedirectToAction("List");
        }

        // Delete Species

        public ActionResult Delete(int, id)
        {
            Pet selectedspecies = db.Species.SqlQuery("select * from species where speciesid = @id", new SqlParameter("@id", id)).FirstOrDefault();
            return View(selectedspecies);

        }

        [HttpPost]
        public ActionResult Delete(int SpeciesID, string DeleteSubmit)
        {
            string query = "delete from species where speciesid =  @id";
            SqlParameter[] sqlparams = new SqlParameter[1];

            sqlparams[0] = new SqlParameter("@SpeciesID", SpeciesID);
            if (DeleteSubmit == "Do you want to delete this species?")
            {
                db.Database.ExecuteSqlCommand(query, sqlparams);
            }

            //This action takes the page back to a list of pets
            return RedirectToAction("List");
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}