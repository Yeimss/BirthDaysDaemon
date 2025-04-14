using System.Net;
using System.Net.Mail;
using System.Text;

public class GmailService
{
    public void EnviarInvitacion(string from, string to, string motivo)
    {
        var startTime = DateTime.Now.AddHours(1);
        var endTime = startTime.AddHours(1);

        string ical = $@"
BEGIN:VCALENDAR
PRODID:-//TuApp//Calendario//ES
VERSION:2.0
METHOD:REQUEST
BEGIN:VEVENT
DTSTART:{startTime.ToUniversalTime():yyyyMMddTHHmmssZ}
DTEND:{endTime.ToUniversalTime():yyyyMMddTHHmmssZ}
DTSTAMP:{DateTime.UtcNow:yyyyMMddTHHmmssZ}
ORGANIZER;CN=Tu Nombre:mailto:{from}
ATTENDEE;CN=Destinatario;RSVP=TRUE:mailto:{to}
SUMMARY:Reunión de prueba
LOCATION:Virtual
DESCRIPTION:Probando envío de invitación desde C#
SEQUENCE:0
STATUS:CONFIRMED
TRANSP:OPAQUE
UID:{Guid.NewGuid()}
END:VEVENT
END:VCALENDAR";

        var correo = new MailMessage();
        correo.From = new MailAddress(from);
        correo.To.Add(to);
        correo.Subject = motivo;
        correo.Body = "Hola, te envío esta invitación para una reunión.";
        correo.IsBodyHtml = false;

        var calendarBytes = Encoding.UTF8.GetBytes(ical);
        var calendarStream = new MemoryStream(calendarBytes);
        var calendarAttachment = new Attachment(calendarStream, "invite.ics", "text/calendar");

        correo.Attachments.Add(calendarAttachment);

        var smtp = new SmtpClient("smtp.gmail.com")
        {
            Port = 587,
            Credentials = new NetworkCredential(from, "tu_contraseña_de_aplicación"),
            EnableSsl = true
        };

        smtp.Send(correo);
    }
}
