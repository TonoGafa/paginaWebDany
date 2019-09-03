 public string enviarCorreoRegistrado( string destinatario, string cuerpo, string titulo, string correo2, string correo3, string correo4, string rutaArchivo)
        {
            if (destinatario != "" || correo2 != "" || correo3 != "" || correo4 != "")
            {
                try
                {
                    message.Attachments.Clear();
                    message.To.Clear();
                    message.CC.Clear();
                    string vbCrLf = System.Environment.NewLine;

                    cuerpoMasFirma = cuerpo + vbCrLf + vbCrLf + vbCrLf + vbCrLf + "----------Correo enviado automáticamente por el sistema SIA----------" + vbCrLf + vbCrLf + "    ---------------Favor de no contestar a esta dirección----------------";
                    MailAddress adrs = new MailAddress("sia@grupohemac.com.mx");
                    message.From = adrs;
                    if (destinatario != "")
                    {
                        message.To.Add(destinatario);
                    }
                    if (correo2 != "")
                    {
                        message.To.Add(correo2);
                    }
                    if (correo3 != "")
                    {
                        message.To.Add(correo3);
                    }
                    if (correo4 != "")
                    {
                        message.To.Add(correo4);
                    }
                    message.CC.Add("sia@grupohemac.com.mx");
                    message.Body = cuerpoMasFirma;
                    titulo = "SIA  " + titulo;
                    message.Subject = titulo;
                    message.Priority = MailPriority.High;
                    if (rutaArchivo != "")
                    {
                        Attachment archivo = new Attachment(rutaArchivo );
                        message.Attachments.Add(archivo);
                    }
                    smtp.EnableSsl = false;
                    smtp.Port = 587;
                    smtp.Host = "smtp.alestraune.net.mx";
                    System.Net.NetworkCredential credenciales = new System.Net.NetworkCredential("sia@grupohemac.com.mx", "19fTg23$*");
                    smtp.Credentials = credenciales;
                    smtp.Send(message);
                    return "Enviado";
                }
                catch (Exception ex)
                {
                    return ex.Message ;
                }
            }else
            {
                return "Sin direcciones de envío";
            }
        }