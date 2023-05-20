using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace wahong_demoWebForm1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        //public List<UserModel> users = new List<UserModel>() { new UserModel() { id = 1, name = "ttt", age = 1, birthday = "2020/11/11" } };

        public List<UserModel> users 
        {
            get
            {
                if (Session["ValList"] == null)
                {
                    Session["ValList"] = new List<UserModel>();
                }

                return (List<UserModel>)Session["ValList"];
            }
            set
            {
                if (value == null)
                {
                    Session.Remove("ValList");
                }
                else
                {
                    Session["ValList"] = value;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadGrid();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int.TryParse(TextBox4.Text, out int id);
            var _user = users.SingleOrDefault(x => x.id == id);

            if (_user == null)
            {
                int maxid = 0;
                if (users.Count > 0)
                {
                    maxid = users.Max(x => x.id);
                }
                maxid++;

                UserModel user = new UserModel()
                {
                    id = maxid,
                    name = TextBox1.Text,
                    age = int.Parse(TextBox2.Text),
                    birthday = TextBox3.Text,
                };
                users.Add(user);
            }
            else
            {
                _user.name = TextBox1.Text;
                _user.age = int.Parse(TextBox2.Text);
                _user.birthday = TextBox3.Text;

            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";

            Button1.Text = "創建帳號";

            LoadGrid();
        }

        protected void edit_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow gRow = btn.NamingContainer as GridViewRow;
            int? pkID = (int?)GridView1.DataKeys[gRow.RowIndex]["id"];

            var _user = users.SingleOrDefault(x => x.id == pkID);

            TextBox1.Text = _user.name;
            TextBox2.Text = _user.age.ToString();
            TextBox3.Text = _user.birthday;
            TextBox4.Text = _user.id.ToString();

            Button1.Text = "修改帳號";
        }

        protected void del_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            GridViewRow gRow = btn.NamingContainer as GridViewRow;
            int? pkID = (int?)GridView1.DataKeys[gRow.RowIndex]["id"];

            var _user = users.SingleOrDefault(x => x.id == pkID);

            users.Remove(_user);

            LoadGrid();
        }

        public void LoadGrid()
        {
            GridView1.DataSource = users;
            GridView1.DataBind();
        }
    }

    public class UserModel
    {
        public int id { get; set; }
        [DisplayName("姓名")]
        public string name { get; set; }
        [DisplayName("年齡")]
        public int age { get; set; }
        [DisplayName("生日")]
        public string birthday { get; set; }

    }
}