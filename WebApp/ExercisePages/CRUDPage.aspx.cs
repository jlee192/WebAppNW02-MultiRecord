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
                BindGuardianList();
                BindTeamList();
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
                        errormsgs.Add("Record is no longer on file.");
                        LoadMessageDisplay(errormsgs, "alert alert-info");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        ID.Text = info.PlayerID.ToString();
                        FirstName.Text = info.FirstName;
                        LastName.Text = info.LastName;
                        GuardianList.SelectedValue = info.GuardianID.ToString();
                        TeamList.SelectedValue = info.TeamID.ToString();
                        Age.Text = info.Age.ToString();
                        Gender.Text = info.Gender;
                        AlbertaHealthCareNumber.Text = info.AlbertaHealthCareNumber;
                        MedicalAlertDetails.Text =
                            info.MedicalAlertDetails == null ? "" : info.MedicalAlertDetails;
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
        protected void BindGuardianList()
        {
            try
            {
                Controller03 sysmgr = new Controller03();
                List<Entity03> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.GuardianName.CompareTo(y.GuardianName));
                GuardianList.DataSource = info;
                GuardianList.DataTextField = nameof(Entity03.GuardianName);
                GuardianList.DataValueField = nameof(Entity03.GuardianID);
                GuardianList.DataBind();
                GuardianList.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                errormsgs.Add(GetInnerException(ex).ToString());
                LoadMessageDisplay(errormsgs, "alert alert-danger");
            }
        }
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
        protected void Validation(object sender, EventArgs e)
        {
            // First name validation:
            if (string.IsNullOrEmpty(FirstName.Text))
            {
                errormsgs.Add("First name is required");
            }
            else
            {
                if (FirstName.Text.Length > 50)
                {
                    errormsgs.Add("First name is limited to 50 characters");
                }
            }
            // Last name validation:
            if (string.IsNullOrEmpty(LastName.Text))
            {
                errormsgs.Add("Last name is required");
            }
            else
            {
                if (LastName.Text.Length > 50)
                {
                    errormsgs.Add("Last name is limited to 50 characters");
                }
            }
            // Guardian validation:
            if (GuardianList.SelectedIndex == 0)
            {
                errormsgs.Add("Guardian is required");
            }
            // Team validation:
            if (TeamList.SelectedIndex == 0)
            {
                errormsgs.Add("Guardian is required");
            }
            // Age validation: 
            if (string.IsNullOrEmpty(Age.Text))
            {
                errormsgs.Add("Age is required");
            }
            else 
            {
                if (int.Parse(Age.Text) < 6 || int.Parse(Age.Text) > 14)
                {
                    errormsgs.Add("Age must be between 6 and 14 inclusive");
                }
            }
            // Gender validation:
            if (string.IsNullOrEmpty(Gender.Text))
            {
                errormsgs.Add("Gender is required");
            }
            else
            {
                if (Gender.Text.Length > 1)
                {
                    errormsgs.Add("Gender is limited to 1 character");
                }
                else
                {
                    if (!Gender.Text.Equals("M", StringComparison.OrdinalIgnoreCase) &&
                    !Gender.Text.Equals("F", StringComparison.OrdinalIgnoreCase))
                    {
                        errormsgs.Add("Please enter 'M' for male; 'F' for female");
                    }
                }
            }
            // Alberta Health Care Number Validation:
            if (string.IsNullOrEmpty(AlbertaHealthCareNumber.Text))
            {
                errormsgs.Add("Alberta Health Care Number is required");
            }
            else
            {
                if (AlbertaHealthCareNumber.Text.Length > 10)
                {
                    errormsgs.Add("Alberta Health Care Numbers are limited to 10 digits");
                }
                else if (AlbertaHealthCareNumber.Text.Length < 10 && AlbertaHealthCareNumber.Text.Length > 0)
                {
                    errormsgs.Add("Alberta Health Care Numbers are missing digit(s)");
                }
                // need more validation
                // First digit starts with 1-9
            }
            // Medical Alert Details Validation:
            if (MedicalAlertDetails.Text.Length > 250)
            {
                errormsgs.Add("Medical details must be less than 250 characters");
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
            ID.Text = "";
            FirstName.Text = "";
            LastName.Text = "";
            GuardianList.ClearSelection();
            TeamList.ClearSelection();
            Age.Text = "";
            Gender.Text = "";
            AlbertaHealthCareNumber.Text = "";
            MedicalAlertDetails.Text = "";
        }
        protected void Add_Click(object sender, EventArgs e)
        {
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    Entity02 player = new Entity02();
                    player.FirstName = FirstName.Text;
                    player.LastName = LastName.Text;
                    player.GuardianID = int.Parse(GuardianList.SelectedValue);
                    player.TeamID = int.Parse(TeamList.SelectedValue);
                    player.Age = int.Parse(Age.Text);
                    player.Gender = Gender.Text;
                    player.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                    if (string.IsNullOrEmpty(MedicalAlertDetails.Text))
                    {
                        player.MedicalAlertDetails = null;
                    }
                    else
                    {
                        player.MedicalAlertDetails = MedicalAlertDetails.Text;
                    }
                    //item.Discontinued = false;
                    int newID = sysmgr.Add(player);
                    ID.Text = newID.ToString();
                    errormsgs.Add("Player has been added");
                    LoadMessageDisplay(errormsgs, "alert alert-success");
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
            int id = 0;
            if (string.IsNullOrEmpty(ID.Text))
            {
                errormsgs.Add("Search for a player to update");
            }
            else if (!int.TryParse(ID.Text, out id))
            {
                errormsgs.Add("Id is invalid");
            }
            Validation(sender, e);
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    Entity02 player = new Entity02();
                    player.PlayerID = int.Parse(ID.Text);
                    player.FirstName = FirstName.Text;
                    player.LastName = LastName.Text;
                    player.GuardianID = int.Parse(GuardianList.SelectedValue);
                    player.TeamID = int.Parse(TeamList.SelectedValue);
                    player.Age = int.Parse(Age.Text);
                    player.Gender = Gender.Text;
                    player.AlbertaHealthCareNumber = AlbertaHealthCareNumber.Text;
                    if (string.IsNullOrEmpty(MedicalAlertDetails.Text))
                    {
                        player.MedicalAlertDetails = null;
                    }
                    else
                    {
                        player.MedicalAlertDetails = MedicalAlertDetails.Text;
                    }
                    //item.Discontinued = Discontinued.Checked;
                    int rowsaffected = sysmgr.Update(player);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Player has been updated");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                    }
                    else
                    {
                        errormsgs.Add("Player was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }
                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
        protected void Delete_Click(object sender, EventArgs e)
        {
            int id = 0;
            if (string.IsNullOrEmpty(ID.Text))
            {
                errormsgs.Add("Search for a player to delete");
            }
            else if (!int.TryParse(ID.Text, out id))
            {
                errormsgs.Add("Id is invalid");
            }
            if (errormsgs.Count > 0)
            {
                LoadMessageDisplay(errormsgs, "alert alert-info");
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    int rowsaffected = sysmgr.Delete(id);
                    if (rowsaffected > 0)
                    {
                        errormsgs.Add("Player has been deleted");
                        LoadMessageDisplay(errormsgs, "alert alert-success");
                        Clear_Click(sender, e);
                    }
                    else
                    {
                        errormsgs.Add("Player was not found");
                        LoadMessageDisplay(errormsgs, "alert alert-warning");
                    }

                }
                catch (Exception ex)
                {
                    errormsgs.Add(GetInnerException(ex).ToString());
                    LoadMessageDisplay(errormsgs, "alert alert-danger");
                }
            }
        }
    }
}