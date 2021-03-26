using QRCoder;
using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace SeeSharpersCinema.Models
{
    public class EmailService
    {
        private const String cinemaEmail = "SeeSharpersCinema@gmail.com";
        private const String cinemaEmailPw = "SeeSharpersCinema1!";
        private const String emailClient = "smtp.gmail.com";

        /// <summary>
        /// Send email to customer with generated QR code
        /// </summary>
        public void email_send()
        {
            SeeSharpersCinema.Models.Order.Ticket ticket = new SeeSharpersCinema.Models.Order.Ticket();
            Guid guid = Guid.NewGuid();
            String qrCodew = ticket.GetQr();

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(guid.ToString(), QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);
            Byte[] bytee;

            using (MemoryStream stream = new MemoryStream())
            {
                qrCodeImage.Save("D:\\Avans\\Temp\\QRCode_" + guid + ".png");
                bytee = stream.ToArray();
            }

            string emailBody = @"<html>
                      <body>
                      <p>Beste (Customer),</p>
                      <p>Thank you for your letter of yesterday inviting me to come for an interview on Friday afternoon, 5th July, at 2:30.
                              I shall be happy to be there as requested and will bring my diploma and other papers with me.</p>
                      <p>Met vriendelijke groet,<br>-SeeSharpersCinema</br></p>
                      </body>
                      </html>
                     ";

            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(cinemaEmail);
                mail.To.Add("SeeSharpersCinema@gmail.com");
                mail.Subject = "Thank you " + "(name)" + " for ordering a ticket for movie " + "(moviename)";
                mail.Body = emailBody;
                mail.IsBodyHtml = true;
                mail.Attachments.Add(new Attachment("D:/Avans/Temp/QRCode_" + guid + ".png"));

                using (SmtpClient smtp = new SmtpClient(emailClient, 587))
                {
                    smtp.Credentials = new NetworkCredential(cinemaEmail, cinemaEmailPw);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
            }
        }
    }
}