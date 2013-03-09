using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using BookManageSystem.DAL;
using System.Windows.Forms;

namespace BookManageSystem.BLL
{
    class bllClass
    {
        DataTable dt;
        DataSet ds;
        public DataTable Query(string queryStr)
        {
            dalClass dcl = new dalClass();
            dt = dcl.GetClassbyStr(queryStr);
            return dt;
        }
        public void DeleteById(string id)
        {
            dalClass dcl = new dalClass();
            dcl.DeleteById(id);
        }
        public void InitCmb(ref ComboBox cmbadmissiondate, ref ComboBox cmbdepartment, ref ComboBox cmbdiscipline)
        {
            dalClass dc = new dalClass();
            DataTable dt1= dc.GetAdmissiondateByStr("");
            cmbadmissiondate.DataSource = dt1;
            cmbadmissiondate.DisplayMember = "admissiondate";
            cmbadmissiondate.ValueMember = "admissiondate";


            cmbdepartment.DataSource = dc.GetDepartmentByStr("");
            cmbdepartment.DisplayMember = "department";
            cmbdepartment.ValueMember = "department";

            cmbdiscipline.DataSource = dc.GetDisciplinetByStr("");
            cmbdiscipline.DisplayMember = "discipline";
            cmbdiscipline.ValueMember = "discipline";

        }
    }
}
