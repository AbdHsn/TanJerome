using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using SystemDrawing = System.Drawing;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography; //[NOTE: Ramdome value generator]
using System.Text;
using ZXing;
using ZXing.QrCode;
using ZXing.CoreCompat.System.Drawing;

namespace CommonLogics
{
    public class CommonFunctions
    {
        string error = "";

        #region "Image Functions"       
        public bool SaveImage(IFormFile actualImage, string imageName, string savePath, string imageExtension, int height = 0, int width = 0)
        {
            try
            {
                SystemDrawing.Image img = SystemDrawing.Image.FromStream(actualImage.OpenReadStream(), true, true);
                if (height == 0 && width == 0)
                {
                    height = img.Height;
                    width = img.Width;
                }
                //[NOTE: Convert FileType into ImageType]

                //[NOTE: Create Directory]
                // string fullPath = Path.Combine(webRootPath, dbImgPath);
                Directory.CreateDirectory(savePath);

                //[NOTE: Creating empty canvas]
                var draw_NewImage = new SystemDrawing.Bitmap(width, height);

                //[NOTE: Drawing image inside empty canvas]
                using (var g = SystemDrawing.Graphics.FromImage(draw_NewImage))
                {
                    g.DrawImage(img, 0, 0, width, height);
                    draw_NewImage.Save(savePath + imageName + imageExtension);
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
        }


        #endregion "Image Functions"

        #region "File Functions"
        public bool SaveFile(IFormFile actualFile, string fileName, string savePath, string extention)
        {
            try
            {
                //[NOTE: Create Directory]
                // string fullPath = Path.Combine(savePath, dp);
                Directory.CreateDirectory(savePath);

                // var saveFullPath = fullPath + Id + "." + extention;

                //[NOTE: upload file]
                using (var stream = new FileStream(savePath + fileName + extention, FileMode.Create))
                {
                    actualFile.CopyTo(stream);
                    return true;
                }
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }
        }

        public bool DeleteStaticFile(string filePath)
        {
            try
            {
                if ((File.Exists(filePath)))
                {
                    File.SetAttributes(filePath, FileAttributes.Normal);
                    File.Delete(filePath);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                error = ex.ToString();
                return false;
            }

        }

        #endregion "File Functions"

        #region "RandomValue Generator Functions" 
        public string GenerateRandomKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }


        #endregion "RandomValue Generator Functions" 

        #region "Email Functions"
        public bool SendEmail(string senderName, string senderMail, string senderPassword, string receiverName, string receiverMail, string subject, string msgBody, string smtpServer, int smtpPort, bool ssl, string wwwRootPath = "")
        {
            try
            {
                //Instantiate mimmessage
                //var msg = new MimeMessage();
                //msg.From.Add(new MailboxAddress(senderName, senderMail));
                //msg.To.Add(new MailboxAddress(receiverName, receiverMail));
                //msg.Subject = subject;


                //var builder = new BodyBuilder();
                //using (StreamReader sourceReader = System.IO.File.OpenText(""))
                //{
                //    builder.HtmlBody = sourceReader.ReadToEnd();
                //}

                //    msg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                //    {
                //        Content = msgBody
                //    };
                ////[NOTE:Configure smtp and Send Mail]
                //using (var client = new SmtpClient())
                //{
                //    client.Connect(smtpServer, smtpPort, ssl);
                //    client.Authenticate(senderMail, senderPassword);
                //    client.Send(msg);
                //    client.Disconnect(true);
                //}

                /////
                using (var mailMessage = new MailMessage())
                using (var client = new SmtpClient(smtpServer, smtpPort))
                {
                    // configure the client and send the message
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential(senderMail, senderPassword);
                    client.EnableSsl = true;

                    string path = Path.Combine(wwwRootPath, "StaticFiles/EmailTempletes/EmailTemplete.html");

                    string body = string.Empty;
                    using (StreamReader reader = new StreamReader(path))
                    {
                        body = reader.ReadToEnd();
                    }
                    body = body.Replace("{{heading}}", "QS Ecommerce");
                    body = body.Replace("{{content}}", "We are highly request you to active your account, please click on active button to active your account. Thank you.");
                    body = body.Replace("{{activeUrl}}", msgBody);
                    body = body.Replace("{{companyName}}", "QS Ecommerce.co");

                    // configure the mail message
                    mailMessage.From = new MailAddress(senderMail);
                    mailMessage.To.Insert(0, new MailAddress(receiverMail));
                    mailMessage.Subject = "For testing....";
                    mailMessage.Body = body;
                    mailMessage.IsBodyHtml = true;

                    client.Send(mailMessage);
                }
                /////


                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion "Email Functions"

        #region "Encrypt and Decrypt Functions"

        #endregion"Encrypt and Decrypt Functions"

        #region "Token Generate For Login"
        public string GenerateJWTToken(string securityKey, string issuer, string audience, List<Claim> listClaim)
        {
            //symmetric security key
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF32.GetBytes(securityKey));

            //generate token
            var token = new JwtSecurityToken(
                    issuer: issuer,
                    audience: audience,
                    claims: listClaim,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256)
                );
            token.SigningKey = symmetricSecurityKey;
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion"Token Generate For Login"

        #region Generate QrCode
        public byte[] CreateQrCode(string content)
        {
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new QrCodeEncodingOptions
                {
                    Height = 500,
                    Width = 500,
                    Margin = 1
                }
            };

            var qrCodeImage = writer.Write(content); // BOOM!!

            using (var stream = new MemoryStream())
            {
                qrCodeImage.Save(stream, SystemDrawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
        #endregion
    }
}
