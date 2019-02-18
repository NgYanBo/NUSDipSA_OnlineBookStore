using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team10BookShop
{
    public partial class Browsing : System.Web.UI.Page
    {
        int catid;
        int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!IsPostBack)
            {
                using (MyBooks mb = new MyBooks())
                {
                    DataList1.DataSource = mb.Books.ToList<Book>();
                    DataList1.DataBind();
                }
            }
        }

        protected void CategoryDL_TextChanged(object sender, EventArgs e)
        {
        }

        protected void SearchBtn_Click(object sender, EventArgs e)
        {
            using (MyBooks mb = new MyBooks())
            {
                if (DetailsDL.Text != null && SearchTxt.Text != null && CategoryDL.SelectedValue != null)
                {
                    switch (DetailsDL.SelectedItem.ToString())
                    {
                        case "Author":

                            catid = mb.Categories.Where(x => x.Name == CategoryDL.SelectedValue).Select(x => x.CategoryID).First();
                            var q = from x in mb.Books where x.Author.Contains(SearchTxt.Text) && x.CategoryID == catid select x;
                            if (q.Count() != 0)
                            {
                                DataList1.DataSource = q.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                        case "Title":
                            catid = mb.Categories.Where(x => x.Name == CategoryDL.SelectedValue).Select(x => x.CategoryID).First();
                            var q1 = from x in mb.Books where x.Title.Contains(SearchTxt.Text) && x.CategoryID == catid select x;
                            if (q1.Count() != 0)
                            {
                                DataList1.DataSource = q1.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                        case "ISBN":
                            catid = mb.Categories.Where(x => x.Name == CategoryDL.SelectedValue).Select(x => x.CategoryID).First();
                            var q2 = from x in mb.Books where x.ISBN == (SearchTxt.Text) && x.CategoryID == catid select x;
                            if (q2.Count() != 0)
                            {
                                DataList1.DataSource = q2.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                        default:
                            Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            break;
                    }
                }
                else if (DetailsDL.SelectedValue != null && SearchTxt.Text == null && CategoryDL.SelectedValue != null)
                {
                    switch (CategoryDL.SelectedItem.ToString())
                    {
                        case "children":
                            catid = mb.Categories.Select(x => x.CategoryID).First();
                            var q1 = from x in mb.Books where x.CategoryID == catid select x;
                            if (q1.Count() != 0)
                            {
                                DataList1.DataSource = q1.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                        case "technical":
                            catid = mb.Categories.Select(x => x.CategoryID).First();
                            var q = from x in mb.Books where x.CategoryID == catid select x;
                            if (q.Count() != 0)
                            {
                                DataList1.DataSource = q.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                        case "finance":
                            catid = mb.Categories.Select(x => x.CategoryID).First();
                            var q2 = from x in mb.Books where x.CategoryID == catid select x;
                            if (q2.Count() != 0)
                            {
                                DataList1.DataSource = q2.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                        case "non-fiction":
                            catid = mb.Categories.Select(x => x.CategoryID).First();
                            var q3 = from x in mb.Books where x.CategoryID == catid select x;
                            if (q3.Count() != 0)
                            {
                                DataList1.DataSource = q3.ToList();
                                DataList1.DataBind();
                            }
                            else
                            {
                                Response.Write("<script>confirm('Record Does Not Exist !!')</script>");
                            }
                            break;
                    }
                }
            }
        }
        protected void CategoryDL_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //using (MyBooks mb = new MyBooks())
            //{
            //    int t = (int)Session["id"];
            //    int s = DataList1.SelectedIndex;
            //    //id = mb.Books.Where(x => x.BookID.Equals(s)).First().BookID;
            //    t = s;
            //    Label1.Text = t.ToString();
            //    Session["id"] = t;

            //}
        }

        protected void DetailButton_Click(object sender, EventArgs e)
        {
            //int t = (int)Session["id"];
            //int s = (int)DataList1.SelectedValue;
            //id = mb.Books.Where(x => x.BookID.Equals(s)).First().BookID;
            //t = s;
            //Label1.Text = s.ToString();
            //Session["id"] = t;
            //DataList1_ItemCommand(sender, e);
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Console.WriteLine("test" + e.CommandName);


            if (e.CommandName == "Details")
            {
                Control control;
                control = e.Item.FindControl("BookIDLabel");
                int bookID = Convert.ToInt32(((Label)control).Text);
                Book b = BusinessLogic.getBookByID(bookID);
                Session["id"] = b.BookID;
                Response.Redirect("BookDetails.aspx");
            }
        }

        protected void AllBooksBtn_Click(object sender, EventArgs e)
        {
            using (MyBooks mb = new MyBooks())
            {
                var q = from x in mb.Books select x;
                DataList1.DataSource = q.ToList();
                DataList1.DataBind();
            }
        }
    }
}