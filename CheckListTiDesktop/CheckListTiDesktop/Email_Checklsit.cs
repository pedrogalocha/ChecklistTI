using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckListTiDesktop
{
    public partial class Email : Form
    {
        Form1 newForm = new Form1();

        public List<String> RotasI = new List<String>();
        public List<String> RotasN = new List<String>();
        public List<String> Sistemas = new List<String>();

        public const String SmtpServer = "smtp.office365.com";
        public const int SmtpPort = 587;
        public const string FromAddress = "pedro.galocha@wocc.com.br";
        public const string Password = "631542aW1";

        public static void SendMail(string toAdress, string subject, string body)
        {
            var client = new SmtpClient(SmtpServer, SmtpPort)
            {
                Credentials = new NetworkCredential(FromAddress, Password),
                EnableSsl = true
            };
            MailMessage message = new MailMessage();
            message.To.Add("pedrogalocha@gmail.com");
            foreach(var item in toAdress.Split(new[] {";"}, StringSplitOptions.RemoveEmptyEntries))
            {
                message.To.Add(item);
            }
            message.IsBodyHtml = true;
            message.From = new MailAddress(FromAddress);
            message.Body = "<h1> Checklist </h1> " +
                "<table style'width:100%'>" +
                "<tr>" +
                "<th>Status</th>" +
                "<th>Sitema/Rotas</th>" +
                "<th>Ping</th>" +
                "</tr>" +
                "<tr>" +
                "<td> OK </td>" +
                "<td>  OK </td>" +
                "<td> 2 ms </td>" +
                "</tr>" +
                "</table>";
            message.Subject = "Teste";
            try
            {
                client.Send(message);
            }
            catch (Exception E)
            {
                throw;
            }
            MessageBox.Show("Email Enviado com sucesso");
        }

        public Email(ArrayList rota, ArrayList sistemas, ArrayList rotaN, ArrayList statusSistema, ArrayList statusRota)
        {
          InitializeComponent();

            for (int i = 0; i < rota.Count; i++)
            {
                RotasI.Add(rota[i].ToString());
                RotasN.Add(rotaN[i].ToString());
                //Sistemas.Add(statusRota[i].ToString());
                Ping pingRota = new Ping();
                PingReply pingresultRota = pingRota.Send(rota[i].ToString());
                String pingResult = pingresultRota.RoundtripTime.ToString();
                MessageBox.Show(RotasN[i]);
                MessageBox.Show(RotasI[i]);
            }

        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        public void inputTo_TextChanged(object sender, EventArgs e)
        {
            String to = "pedrogalocha@gmail.com";
            inputTo.Text = to;
           
        }

        private void btn_send_Click(object sender, EventArgs e)
        {
            SendMail("pedro.galocha@wocc.com.br ; ti@wocc.com.br","teste","teste");
           
        }

        private void inputTo_Leave(object sender, EventArgs e)
        {
            String to = "pedrogalocha@gmail.com";
            inputTo.Text = to;
        }
    }
}
