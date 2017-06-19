using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPEncDec
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PoulateUploadedFiles();
            }
            
        }
        private void PoulateUploadedFiles()
        {
            DirectoryInfo di = new DirectoryInfo(Server.MapPath("~/UploadedFiles"));
            List<UploadFile> uploadedFiles = new List<UploadFile>();
            foreach (var files in di.GetFiles())
            {
                object file = null;
                uploadedFiles.Add
                    (
                    new UploadFile
                    {
                        Filename = file.Name,
                        FileExtension = Path.GetExtension(file.name),
                        FilePath = file.Fullname,
                        Size = (file.Length / 1024),
                        ICon = ""

                    }
                    );

            }
            DataList1.DataSource = uploadedFiles;
            DataList1.DataBind();
        }
        private string GetIconPath(string fileExtentior)
        {
            string Iconpath = "/Images";
            string ext = fileExtension.ToLower();
            switch (ext)
            {
                case ".txt":
                    Iconpath += "/txt.png";
                    break;
                case ".doc":
                case ".dcox":
                    Iconpath += "/word.png";
                    break;
                case ".xls":
                case ".xlsx":
                    Iconpath += "/xls.png";
                    break;
                case ".pdf":
                    Iconpath += "/pdf.png";
                    break;
                case ".rar":
                    Iconpath += "/rar.png";
                    break;
                case ".zip":
                case ".7z":
                    Iconpath += "/zip.png";
                    break;
                default:
                    break;
            }
            return Iconpath;
        }
        protected void btUpload_Click(object sender, EventArgs e)
        {
            // Add Code to upload file with Encryption
            byte[] file = new byte[FileUpload1.PostedFile.ContentLength];
            FileUpload1.PostedFile.InputStream.Read(file, 0, FileUpload1.PostedFile.ContentLength);

            string filename = FileUpload1.PostedFile.FileName;
            // key for encryption
            byte[] Key = Encoding.UTF8.GetBytes("asdf!@#$1234ASDF");
            try
            {
                string outputFile = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
                if (File.Exists(outputFile))
                {
                    // Show Already exist Message
                }
                else
                {
                    FileStream fs = new FileStream(outputFile, FileMode.Create);
                    RijndaelManaged rmCryp = new RijndaelManaged();
                    CryptoStream cs = new CryptoStream(fs, rmCryp.CreateEncryptor(Key, Key), CryptoStreamMode.Write);
                    foreach (var data in file)
                    {
                        cs.WriteByte((byte)data);
                    }
                    cs.Close();
                    fs.Close();
                }

                PopulateUploadedFiles();
            }
            catch
            {
                Response.Write("Encryption Failed! Please try again.");
            }
        }
    }

    internal class fileExtension
    {
        internal static string ToLower()
        {
            throw new NotImplementedException();
        }
    }
}        