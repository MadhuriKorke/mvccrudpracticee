using Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.ClassesFolder
{
    public class BALUSER
    {
       MSSQL DBHelper=new MSSQL();
       
        public async Task<DataSet> Showcountry()
        {
            Dictionary<string, string> Param = new Dictionary<string, string>();
            Param.Add("@flag", "fetchcountry");
            DataSet ds = new DataSet();
            ds = await DBHelper.ExecuteStoreProcedureReturnDS("mvcdata", Param);
            return ds;
        }

        public async Task<DataSet> showstate(USER obj)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@flag", "fetchstate");
            Param.Add("@countryid", obj.countryid.ToString());
            DataSet dss = new DataSet();
            dss = await DBHelper.ExecuteStoreProcedureReturnDS("mvcdata", Param);
            return dss;

        }

        public async Task<DataSet> showcity(USER objj)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@flag", "fetchcity");
            Param.Add("@stateid", objj.stateid.ToString());
            DataSet dss = new DataSet();
            dss = await DBHelper.ExecuteStoreProcedureReturnDS("mvcdata", Param);
            return dss;
        }

        public async Task<DataSet> viewlist()
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@flag", "viewlist");
            DataSet ds = new DataSet();
            ds = await DBHelper.ExecuteStoreProcedureReturnDS("mvcdata", Param);
            return ds;

        }

        public async Task save(USER obj)
        {
            Dictionary<String, String> Param = new Dictionary<String, String>();
            Param.Add("@flag", "save");
            Param.Add("@Name", obj.Name.ToString());
            Param.Add("@Address", obj.Address.ToString());
            Param.Add("@Email", obj.Email.ToString());
            Param.Add("@Phone", obj.Phone.ToString());
            Param.Add("@Gender", obj.gender.ToString());
            Param.Add("@Cityid", obj.cityid.ToString());
            await DBHelper.ExecuteStoreProcedure("mvcdata", Param);

        }
    }
}
