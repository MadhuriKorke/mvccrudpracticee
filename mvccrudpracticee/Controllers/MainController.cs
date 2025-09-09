using ClassLibrary1.ClassesFolder;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace mvccrudpracticee.Controllers
{
    public class MainController : Controller
    {
        // GET: Main

        [HttpGet]
        public async Task<ActionResult> Create()
        {

            await showcountry();
            BALUSER balUser = new BALUSER();
            DataSet ds = new DataSet();
            ds = await balUser.viewlist();

            List<USER> users = new List<USER>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                USER obj = new USER();
                obj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                obj.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                obj.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                obj.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                obj.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                obj.city = ds.Tables[0].Rows[i]["city"].ToString();

                users.Add(obj);
            }

            USER objl = new USER();
            objl.users = users;

            return View(objl);
        }

        [HttpPost]
        public async Task<ActionResult> Create(USER obj)
        {
            BALUSER balUser = new BALUSER();
            BALUSER balUser1 = new BALUSER();
            DataSet ds = new DataSet();
            ds = await balUser.viewlist();

            List<USER> users1 = new List<USER>();

            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                USER obj1 = new USER();
                obj1.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["id"].ToString());
                obj1.Name = ds.Tables[0].Rows[i]["Name"].ToString();
                obj1.Address = ds.Tables[0].Rows[i]["Address"].ToString();
                obj1.Email = ds.Tables[0].Rows[i]["Email"].ToString();
                obj1.Phone = ds.Tables[0].Rows[i]["Phone"].ToString();
                obj1.city = ds.Tables[0].Rows[i]["city"].ToString();

                users1.Add(obj1);
            }

            USER objl = new USER();
            objl.users = users1;
            await balUser.save(obj);
            return RedirectToAction("Create");
        }


        public async Task showcountry()
        {
            BALUSER obj = new BALUSER();
            DataSet ds = new DataSet();
            ds = await obj.Showcountry();

            List<SelectListItem> list = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                list.Add(new SelectListItem
                {
                    Text = dr["Country"].ToString(),
                    Value = dr["countryid"].ToString()

                });
            }
            ViewBag.country = list;

        }


        public async Task<JsonResult> showstate(int countryid)
        {
            USER obj = new USER();
            obj.countryid = countryid;
            BALUSER objU = new BALUSER();
            DataSet ds = await objU.showstate(obj);

            var liststate = new List<SelectListItem>();

            foreach (DataRow drr in ds.Tables[0].Rows)
            {
                liststate.Add(new SelectListItem
                {
                    Text = drr["state"].ToString(),
                    Value = drr["stateid"].ToString()
                });
            }

            return Json(liststate, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> showcity(int stateid)   
        {
            USER objc = new USER { stateid = stateid };
            BALUSER objb = new BALUSER();
            DataSet ds = await objb.showcity(objc);

            var listcity = new List<SelectListItem>();

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                listcity.Add(new SelectListItem
                {
                    Text = dr["city"].ToString(),
                    Value = dr["cityid"].ToString()
                });
            }

            return Json(listcity, JsonRequestBehavior.AllowGet);
        }






    }
}