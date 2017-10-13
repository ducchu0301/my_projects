using System; 
using System.IO; 
using System.Web;  
using gameShop.Common;

namespace POI.Modules
{
    public partial class uploader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        public void LoadImageLink()
        {
            if (Session["upload"] != null)
            {
                txtImages.Text = Session["upload"].ToString();
                ImgImages.ImageUrl = Session["upload"].ToString();
                ImgImages.Width = 100;
                ImgImages.Height = 100;
            }
        }
        public void delete_picture(string link)
        {
            try
            {
                string fileName = Server.MapPath(link);
                if ((System.IO.File.Exists(fileName)))
                {
                    System.IO.File.Delete(fileName);
                }

            }
            catch (Exception ms)
            {
                Console.WriteLine("{0} Exception caught.", ms);
            }
        }
        protected void btlTaiLen_Click(object sender, EventArgs e)
        {
            HttpPostedFile files = FileUploadHinhAnh.PostedFile;
            if (FileUploadHinhAnh.HasFile == false || files.ContentLength > 2000000)
            {
                WebMsgBox.Show("Invalid picture!");
            }
            else
            {
                string _fileExt = Path.GetExtension(FileUploadHinhAnh.FileName);
                if (_fileExt.ToLower() == ".gif" || _fileExt.ToLower() == ".png" || _fileExt.ToLower() == ".bmp" ||
                    _fileExt.ToLower() == ".jpeg" || _fileExt.ToLower() == ".jpg")
                {
                    try
                    {
                        string AdsFile = FileUploadHinhAnh.FileName + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + Path.GetExtension(FileUploadHinhAnh.FileName);
                        FileUploadHinhAnh.SaveAs(Request.PhysicalApplicationPath + "Images/" + Session["folder"] + "/" + AdsFile);
                        if (Session["upload"] != null)
                        {
                            delete_picture(Session["upload"].ToString());
                        }
                        Session["upload"] = "/Images/" + Session["folder"] + "/" + AdsFile;
                        WebMsgBox.Show("Upload successed!");
                        LoadImageLink();
                    }
                    catch
                    {
                        WebMsgBox.Show("Same name or don't choose picture!");
                    }
                }
                else
                {
                    WebMsgBox.Show("picture type not supported!");
                }
            }
        }
    }
}