using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using QLBanHang.Object;
using System.Windows.Forms;

namespace QLBanHang.Model
{
    class SendMailMob
    {
        ConnectToSQL con = new ConnectToSQL();
        SqlCommand cmd = new SqlCommand();

        public bool SendMail(string matkhaumoi, string mailCC)
        {
          //  DataTable dt = new DataTable();
            
            try
            {

            // danh sách được phân cách bằng đấu " ; "
            string danhsachCC = "thanhanngo1998@gmail.com;ltntuyen29@gmail.com";
                string danhsachBCC = mailCC;

                SmtpClient mailclient = new SmtpClient("smtp.gmail.com", 587);
                mailclient.EnableSsl = true;
                mailclient.Credentials = new NetworkCredential("hodoanthanhngoan2511@gmail.com", "0868233996ngoan");

                MailMessage message = new MailMessage("hodoanthanhngoan151@gmail.com", "hodoanthanhngoan151@gmail.com");
                message.Subject = " Mật khẩu đăng nhập QLCH đã đổi";
                message.Body = "Mật khẩu mới của bạn là : "+matkhaumoi;

                //Nếu có nhập Cc
                if (danhsachCC != "")
                {
                    //Cắt chuỗi Cc bằng dấu ";"
                    string[] cc = danhsachCC.Split(';');

                    foreach (var _cc in cc)
                    {
                        message.CC.Add(_cc.ToString());
                    }
                }

                //Nếu có nhập Bcc
                if (danhsachBCC != "")
                {
                    //Cắt chuỗi Bcc bằng dấu ";"
                    string[] bcc = danhsachBCC.Split(';');

                    foreach (var _bcc in bcc)
                    {
                        message.Bcc.Add(_bcc.ToString());
                    }
                }

            mailclient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
