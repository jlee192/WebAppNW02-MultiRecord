using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;
using System.Data.Entity.Validation;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core;

namespace WebApp.ExercisePages
{
    public partial class CRUDPage : System.Web.UI.Page
    {
        static string pagenum = "";
        static string pid = "";
        static string add = "";
        List<string> errormsgs = new List<string>();
        private static List<Entity02> Entity02List = new List<Entity02>();
        protected void Page_Load(object sender, EventArgs e)
        {
            Message.DataSource = null;
            Message.DataBind();
            if (!Page.IsPostBack)
            {
                pagenum = Request.QueryString["page"];
                pid = Request.QueryString["pid"];
                add = Request.QueryString["add"];
                //errormsgs.Add("The page you came from is: " + pagenum);
                //errormsgs.Add("You passed this PlayerID: " + pid);
                //errormsgs.Add("You passed this Add option: " + add);
                LoadMessageDisplay(errormsgs, "alert alert-info");
                //BindCategoryList();
                //BindSupplierList();
                BindTeamList();
                //BindGuardianList();
                if (string.IsNullOrEmpty(pid))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else if (add == "yes")
                {
                    //Discontinued.Enabled = false;
                }
                else
                {
                    Controller02 sysmgr = new Controller02();
                    Entity02 info = null;
                    info = sysmgr.FindByPKID(int.Parse(pid));
                    if (info == null)
                    {
                        errormsgs.Add("Player is no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        PlayerID.Text = info.PlayerID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        Age.Text = info.Age.ToString();
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber;
                    }
                }
            }
        }
        protected Exception GetInnerException(Exception ex)
        {
            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
            }
            return ex;
        }
        protected void LoadMessageDisplay(List<string> errormsglist, string cssclass)
        {
            Message.CssClass = cssclass;
            Message.DataSource = errormsglist;
            Message.DataBind();
        }
        //protected void BindCategoryList()
        //{
        //    try
        //    {
        //        Controller01 sysmgr = new Controller01();
        //        List<Entity01> info = null;
        //        info = sysmgr.List();
        //        info.Sort((x, y) => x.CategoryName.CompareTo(y.CategoryName));
        //        CategoryList.DataSource = info;
        //        CategoryList.DataTextField = nameof(Entity01.CategoryName);
        //        CategoryList.DataValueField = nameof(Entity01.CategoryID);
        //        CategoryList.DataBind();
        //        CategoryList.Items.Insert(0, "select...");

        //    }
        //    catch (Exception ex)
        //    {
        //        errormsgs.Add(GetInnerException(ex).ToString());
        //        LoadMessageDisplay(errormsgs, "alert alert-danger");
        //    }
        //}
        //protected void BindGuardianList()
        //{
        //    try
        //    {
        //        Controller03 sysmgr = new Controller03();
        //        List<Entity03> info = null;
        //        info = sysmgr.List();
        //        info.Sort((x, y) => x.GuardianName.CompareTo(y.GuardianName));
        //        GuardianList.DataSource = info;
        //        GuardianList.DataTextField = nameof(Entity03.GuardianName);
        //        GuardianList.DataValueField = nameof(Entity03.GuardianID);
        //        GuardianList.DataBind();
        //        GuardianList.Items.Insert(0, "select...");

        //    }
        //    catch (Exception ex)
        //    {
        //        errormsgs.Add(GetInnerException(ex).ToString());
        //        LoadMessageDisplay(errormsgs, "alert alert-danger");
        //    }
        //}
        protected void BindTeamList()
        {
            try
            {
                Controller01 sysmgr = new Controller01();
                List<Entity01> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                TeamList.DataSource = info;
                TeamList.DataTextField = nameof(Entity01.TeamName);
                TeamList.DataValueField = nameof(Entity01.TeamID);
                TeamList.DataBind();
                TeamList.Items.Insert(0, "select...");

            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
        protected bool Validation(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errormsgs.Add("First Name is required");
            }
            if (string.IsNullOrEmpty(LastName.Text))
            {
                errormsgs.Add("Last Name is required");
            }
            //if (CategoryList.SelectedIndex == 0)
            //{
            //    errormsgs.Add("Category is required");
            //}
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Team is required");
            }
            if (string.IsNullOrEmpty(Age.Text))
            {
                errormsgs.Add("Age is required");
            }
            if (string.IsNullOrEmpty(AlbertaHealthCareNumber.Text))
            {
                errormsgs.Add("Alberta Health Care Number is required");
            }
            if (AlbertaHealthCareNumber.Text.Length > 10)
            {
                errormsgs.Add("Alberta Health Care Number must be 10 digits");
                // also need to make it so the first digit starts with 1-9
            }
            //double unitprice = 0;
            //if (!string.IsNullOrEmpty(UnitPrice.Text))
            //{
            //    if (double.TryParse(UnitPrice.Text, out unitprice))
            //    {
            //        if (unitprice < 0.00 || unitprice > 200.00)
            //        {
            //            errormsgs.Add("Unit Price must be between $0.00 and $200.00");
            //        }
            //    }
            //    else
            //    {
            //        errormsgs.Add("Unit Price must be a real number");
            //    }
            //}
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
                return false;
            }
            else
            {
                return true;
            }

        }
        protected void Back_Click(object sender, EventArgs e)
        {
            if (pagenum == "4")
            {
                Response.Redirect("08MultiRecordDropdownToSingleRecord.aspx");
            }
            else
            {
                Response.Redirect("~/Default.aspx");
            }
        }
        protected void Clear_Click(object sender, EventArgs e)
        {
            PlayerID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            //GuardianList.ClearSelection();
            TeamList.ClearSelection();
            Age.Text = "";
            AlbertaHealthCareNumber.Text = "";
            //Discontinued.Checked = false;
            //CategoryList.ClearSelection();
            //SupplierList.ClearSelection();
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            bool validdata = Validation(sender, e);
            if (validdata)
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    Entity02 item = new Entity02();
                    item.FirstName = FirstName.Text.Trim();
                    //if (CategoryList.SelectedIndex == 0)
                    //{
                    //    item.CategoryID = null;
                    //}
                    //else
                    //{
                    //    item.CategoryID = int.Parse(CategoryList.SelectedValue);
                    //}
                    //if (SupplierList.SelectedIndex == 0)
                    //{
                    //    item.SupplierID = null;
                    //}
                    //else
                    //{
                    //    item.SupplierID = int.Parse(SupplierList.SelectedValue);
                    //}
                    //item.QuantityPerUnit =
                    //    string.IsNullOrEmpty(QuantityPerUnit.Text) ? null : QuantityPerUnit.Text;
                    //if (string.IsNullOrEmpty(UnitPrice.Text))
                    //{
                    //    item.UnitPrice = null;
                    //}
                    //else
                    //{
                    //    item.UnitPrice = decimal.Parse(UnitPrice.Text);
                    //}
                    //if (string.IsNullOrEmpty(UnitsInStock.Text))
                    //{
                    //    item.UnitsInStock = null;
                    //}
                    //else
                    //{
                    //    item.UnitsInStock = Int16.Parse(UnitsInStock.Text);
                    //}
                    if (!string.IsNullOrEmpty(LastName.Text))
                    {
                        item.LastName = LastName.Text;
                    }
                    if (!string.IsNullOrEmpty(Age.Text))
                    {
                        item.Age = int.Parse(Age.Text);
                    }
                    if (!string.IsNullOrEmpty(AlbertaHealthCareNumber.Text))
                    {
                        item.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                    }
                    //if (string.IsNullOrEmpty(UnitsOnOrder.Text))
                    //{
                    //    item.UnitsOnOrder = null;
                    //}
                    //else
                    //{
                    //    item.UnitsOnOrder = Int16.Parse(UnitsOnOrder.Text);
                    //}
                    //if (string.IsNullOrEmpty(ReorderLevel.Text))
                    //{
                    //    item.ReorderLevel = null;
                    //}
                    //else
                    //{
                    //    item.ReorderLevel = Int16.Parse(ReorderLevel.Text);
                    //}
                    //item.Discontinued = false;
                    int newProductID = sysmgr.Add(item);
                    PlayerID.Text = newProductID.ToString();
                    errormsgs.Add("Player has been added");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
                    //BindProductList(); //by default, list will be at index 0
                    //ProductList.SelectedValue = ProductID.Text;
                }
                catch (DbUpdateException ex)
                {
                    UpdateException updateException = (UpdateException)ex.InnerException;
                    if (updateException.InnerException != null)
                    {
                        errormsgs.Add(updateException.InnerException.Message.ToString());
                    }
                    else
                    {
                        errormsgs.Add(updateException.Message);
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            errormsgs.Add(validationError.ErrorMessage);
                        }
                    }
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Update_Click(object sender, EventArgs e)
        {

        }
        protected void Discontinue_Click(object sender, EventArgs e)
        {

        }
        protected void Delete_Click(object sender, EventArgs e)
        {

        }
    }
}