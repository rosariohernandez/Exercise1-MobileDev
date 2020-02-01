using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetGrooming.Data;
using PetGrooming.Models;
using PetGrooming.Models.ViewModels;
using System.Diagnostics;

namespace PetGrooming.Controllers
{
    public class PetController : Controller
    {
    
 
         */
        private PetGroomingContext db = new PetGroomingContext();

        // List Pet
        public ActionResult List()
        {

            List<Pet> pets = db.Pets.SqlQuery("Select * from Pets").ToList();
            return View(pets);

        }

        // Show Pets
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Pet pet = db.Pets.SqlQuery("select * from pets where petid=@PetID", new SqlParameter("@PetID", id)).FirstOrDefault();
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }
        //Add Pets
        public ActionResult Add()
        {
            return View();
        }

        //THE [HttpPost] Means that this method will only be activated on a POST form submit to the URL /Pets/Add

        [HttpPost]
        public ActionResult Add(string PetName, Double PetWeight, String PetColor, int SpeciesID, string PetNotes)
        {
            //STEP 1: PULL DATA! The data is access as arguments to the method. Make sure the datatype is correct!
            //The variable name  MUST match the name attribute described in Views/Pet/Add.cshtml

            //Tests are very useul to determining if you are pulling data correctly!
            Debug.WriteLine("Want to create a pet with name " + PetName + " and weight " + PetWeight.ToString());

            //STEP 2: FORMAT QUERY! the query will look something like "insert into () values ()"...
            string query = "insert into pets (PetName, Weight, color, SpeciesID, Notes) values (@PetName,@PetWeight,@PetColor,@SpeciesID,@PetNotes)";
            SqlParameter[] sqlparams = new SqlParameter[5]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@PetName", PetName);
            sqlparams[1] = new SqlParameter("@PetWeight", PetWeight);
            sqlparams[2] = new SqlParameter("@PetColor", PetColor);
            sqlparams[3] = new SqlParameter("@SpeciesID", SpeciesID);
            sqlparams[4] = new SqlParameter("@PetNotes", PetNotes);

            db.Database.ExecuteSqlCommand(query, sqlparams);



            return RedirectToAction("List");
        }


        public ActionResult New()
        {

            public ActionResult Add(string PetName, Double PetWeight, String PetColor, int SpeciesID, string PetNotes)
            {
                string query = "insert into pets (PetName, Weight, color, SpeciesID, Notes) values (@PetName,@PetWeight,@PetColor,@SpeciesID,@PetNotes)";
                SqlParameter[] sqlparams = new SqlParameter[5];

                sqlparams[0] = new SqlParameter("@PetName", PetName);
                sqlparams[1] = new SqlParameter("@PetWeight", PetWeight);
                sqlparams[2] = new SqlParameter("@PetColor", PetColor);
                sqlparams[3] = new SqlParameter("@SpeciesID", SpeciesID);
                sqlparams[4] = new SqlParameter("@PetNotes", PetNotes);

                db.Database.ExecuteSqlCommand(query, sqlparams);


                List<Species> species = db.Species.SqlQuery("select * from Species").ToList();

                return View(Pet);
            }

            public ActionResult Update(int id)
            {
                // information about a specific pet
                Pet selectedpet = db.Pets.SqlQuery("select * from pets where petid = @id", new SqlParameter("@id", id)).FirstOrDefault();


                string query = "select * from species";
                Species selectedspecies = db.Species.SqlQuery(query).ToList();

                //create an instance of our ViewModel
                UpdatePet viewmodel = new UpdatePet();
                viewmodel.pet = selectedpet;
                viewmodel.species = selectedpet species;

                return View(viewmodel);
            }

        [HttpPost]
        public ActionResult Update(int PetID, string PetName, string PetColor, double PetWeight, string PetNotes)
        {

            Debug.WriteLine("I am trying to edit a pet's name to " + PetName + " and change the weight to " + PetWeight.ToString());
            string query = "update pets set PetName = '@PetName', Weight='@PetWeight', color='@PetColor', Notes='@PetNotes' where PetID=@id";
            SqlParameter[] parameters = new SqlParameter[5]; //5 pieces of info to pass through

            parameters[0] = new SqlParameter("@PetName", PetName);
            parameters[1] = new SqlParameter("@PetWeight", PetWeight);
            parameters[2] = new SqlParameter("@PetColor", PetColor);
            parameters[3] = new SqlParameter("@PetNotes", PetNotes);
            parameters[4] = new SqlParameter("@id", PetID);

            db.Database.ExecuteSqlCommand(query, parameters);


            return RedirectToAction("List");
        }

        // Delete Pet

        public ActionResult Delete(int, id)
        {
            Pet selectedpet = db.Pets.SqlQuery("select * from pets where petid = @id", new SqlParameter("@id", id)).FirstOrDefault();
            return View(selectedpet);

        }

        [HttpPost]
        public ActionResult Delete(int PetID, string DeleteSubmit)
        {
            string query = "delete from pets where petid =  @id";
            SqlParameter[] sqlparams = new SqlParameter[1];

            sqlparams[0] = new SqlParameter("@PetID", PetID);
            if (DeleteSubmit == "Do you want to delete this Pet?")
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
