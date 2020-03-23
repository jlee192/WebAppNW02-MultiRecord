using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DBSystem.BLL;
using DBSystem.ENTITIES;

namespace WebApp.ExercisePages
{
    public partial class MultiRecordQueryWithDefaultGridView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
            if (!Page.IsPostBack)
            {
                BindList();
            }
        }
        protected void BindList()
        {
            try
            {
                Controller01 sysmgr = new Controller01();
                List<Entity01> info = null;
                info = sysmgr.List();
                info.Sort((x, y) => x.TeamName.CompareTo(y.TeamName));
                List01.DataSource = info;
                List01.DataTextField = nameof(Entity01.TeamName);
                List01.DataValueField = nameof(Entity01.TeamID);
                List01.DataBind();
                List01.Items.Insert(0, "select...");
            }
            catch (Exception ex)
            {
                MessageLabel.Text = ex.Message;
            }
        }
        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (List01.SelectedIndex == 0)
            {
                MessageLabel.Text = "Select a team to view details";
            }
            else
            {
                try
                {
                    Controller02 sysmgr = new Controller02();
                    List<Entity02> info = null;
                    info = sysmgr.FindByID(int.Parse(List01.SelectedValue));
                    info.Sort((x, y) => x.PlayerName.CompareTo(y.PlayerName));
                    List02.DataSource = info;
                    List02.DataBind();
                }
                catch (Exception ex)
                {
                    MessageLabel.Text = ex.Message;
                }
            }
        }
    }
}