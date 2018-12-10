using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using System.Net.Mail;
using System.Net;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CheckListTiDesktop
{
    public partial class Form1 : Form
    {
        private const string IE_DRIVER_PATH = @"c:\web";

        public ArrayList sistemas = new ArrayList();
        public ArrayList rotas = new ArrayList();
        public ArrayList rotasNomes = new ArrayList();
        public List<String> Status = new List<String>();

        public Boolean CheckNet;
        public Boolean CheckNeo;
        public Boolean CheckClaro;
        public Boolean CheckTotal;
        public Boolean CheckOlos;
        public Boolean CheckQualidade;
        public Boolean CheckIntersicNet;
        public Boolean CheckIntersicClaro;

        public String ScreenDirectory;

        public ArrayList rotaStatus = new ArrayList();
        public ArrayList sistemaStatus = new ArrayList();

        SqlConnection conn = new SqlConnection("Data Source=WOCC25;Initial Catalog=db_checklist;Persist Security Info=True;User ID=ti;Password=T0psecretw");

        CheckedListBox checklistTi = new CheckedListBox();
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
            sistemas.Add("Webmail Net");
            sistemas.Add("Webmail Claro");
            sistemas.Add("Neo");
            sistemas.Add("Total Ip");
            sistemas.Add("Olos");
            sistemas.Add("Qualidade");
            sistemas.Add("Proxy");
            sistemas.Add("São José");
            sistemas.Add("Intersic Net");
            sistemas.Add("Intersic Claro");

            rotasNomes.Add("Best Voice");
            rotas.Add("200.201.195.35");
            rotasNomes.Add("CTZ_GSM");
            rotas.Add("187.60.48.200");
            rotasNomes.Add("CTZ_Teleco");
            rotas.Add("187.60.48.200");
            rotasNomes.Add("EBT_SIP");
            rotas.Add("189.52.91.71");
            rotasNomes.Add("IPCORP");
            rotas.Add("177.38.216.61");
            rotasNomes.Add("ROTA_PONTAL");
            rotas.Add("200.143.169.171");
            rotasNomes.Add("VONEX");
            rotas.Add("177.53.16.48");


            checklistTi.Location = new System.Drawing.Point(10, 15);
            checklistTi.Size = new System.Drawing.Size(510, 190);

            this.Controls.Add(checklistTi);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void button1_Click(object sender, EventArgs e)
        {
            var driver = new InternetExplorerDriver(IE_DRIVER_PATH);
            driver.Manage().Window.Maximize();


            // Acesso NET Web Mail
            try
            {
                CheckNet = false;

                driver.Url = "http://172.21.0.25/webmail_net/";

                driver.FindElement(By.Id("element_1")).SendKeys("pedro@wocc.com.br");
                driver.FindElement(By.Id("data_vencimento")).SendKeys("14/06/2018");

                driver.FindElement(By.Id("saveForm")).Submit();

                String ValidaNet = driver.FindElement(By.TagName("h1")).Text;

                if (ValidaNet == "Email enviado com sucesso!")
                {
                    CheckNet = true;
                }
                else
                {
                    CheckNet = false;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\webmail_net.png";

                var net = driver.GetScreenshot();
                net.SaveAsFile(ScreenDirectory);
            } catch { }
            //

            // Acesso Claro Web Mail
            try {

            CheckClaro = false;

            driver.Url = "http://172.21.0.25/webmail_claro/";

            driver.FindElement(By.Id("element_1")).SendKeys("pedro@wocc.com.br");
            driver.FindElement(By.Id("data_vencimento")).SendKeys("14/06/2018");

            driver.FindElement(By.Id("saveForm")).Submit();

            String ValidaClaro = driver.FindElement(By.TagName("h1")).Text;

            if (ValidaClaro == "Email enviado com sucesso!")
            {
                CheckClaro = true;
            } else
            {
                CheckClaro = false;
            }


            ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\webmail_claro.png";
            var claro = driver.GetScreenshot();
            claro.SaveAsFile(ScreenDirectory);
            } catch { }
            //


            // Acesso NEO
            try
            {
                CheckNeo = false;

                driver.Url = "http://172.21.0.10/";

                driver.FindElement(By.Name("usuario")).SendKeys("samuel_ti");
                driver.FindElement(By.Name("senha")).SendKeys("38780872");

                driver.FindElement(By.Name("btConfirma")).Submit();

                if (driver.Url == "http://172.21.0.10/index2.asp")
                {
                    CheckNeo = true;
                }
                else
                {
                    CheckNeo = false;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\NEO.png";

                var Neo = driver.GetScreenshot();
                Neo.SaveAsFile(ScreenDirectory);
            } catch { }
            //

            // Acesso TOTALIP
            try
            {
                CheckTotal = false;

                driver.Url = "http://172.21.0.123/";

                String ValidaTotal = driver.FindElement(By.ClassName("btn-primary")).Text;

                if (ValidaTotal == "Entrar")
                {
                    CheckTotal = true;
                }
                else
                {
                    CheckTotal = false;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\TotalIP.png";

                var Totalip = driver.GetScreenshot();
                Totalip.SaveAsFile(ScreenDirectory);
            } catch { }
            //

            // Acesso Olos
            try
            {
                CheckOlos = false;

                driver.Url = "http://172.21.0.233/olos/Login.aspx?logout=true";

                driver.FindElement(By.Name("User")).SendKeys("SUPORTE_TI");
                driver.FindElement(By.Name("Password")).SendKeys("SUPORTE_TI");

                driver.FindElement(By.Name("Button1")).Submit();

                driver.FindElement(By.Id("ctl00_A1")).Click();

                driver.FindElement(By.Name("User")).SendKeys("SUPORTE_TI");
                driver.FindElement(By.Name("Password")).SendKeys("SUPORTE_TI");

                driver.FindElement(By.Name("Button1")).Submit();

                String ValidaOlos = driver.FindElement(By.Id("ctl00_labelStartPage")).Text;

                

                if (ValidaOlos == "Página Inicial")
                {
                    CheckOlos = true;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\Olos.png";

                var Olos = driver.GetScreenshot();
                Olos.SaveAsFile(ScreenDirectory);
            } catch { }
            //

            // Acesso Qualidade
            try {
                CheckQualidade = false;

                driver.Url = "http://winover.2clix.com.br/";

                String ValidaQualidade = driver.FindElement(By.ClassName("btn-success")).Text;

                if(ValidaQualidade == "Entrar")
                {
                    CheckQualidade = true;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\Qualidade.png";

                var Qualidade = driver.GetScreenshot();
                Qualidade.SaveAsFile(ScreenDirectory);
            } catch { }

            //


            // Acesso Intersic Net
            try {
                CheckIntersicNet = false;

                driver.Url = "https://nettv.mfmti.com.br/lang_portbr/";

                driver.SwitchTo().Frame("geral");
                driver.FindElement(By.Name("user")).SendKeys("MWINT8000214");
                driver.FindElement(By.Name("passwd")).SendKeys("WOCC2020");

                driver.FindElement(By.Name("entrar")).Submit();

                String ValidaIntersicNet = driver.FindElement(By.TagName("b")).Text;

            

                if (ValidaIntersicNet == "NET SERVIÇOS")
                {
                    CheckIntersicNet = true;
                }
                else
                {
                    CheckIntersicNet = false;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\IntersicNet.png";

                var IntersicNet = driver.GetScreenshot();
                IntersicNet.SaveAsFile(ScreenDirectory);

            
                driver.FindElement(By.XPath("//*[@id='XXMENU']/table/tbody/tr[15]/td/a")).Click();
            } catch { }
            //

            // Acesso Intersic Claro
            try
            {
                CheckIntersicClaro = false;
                driver.Url = "https://claro.mfmti.com.br/lang_portbr/";

                driver.SwitchTo().Frame("geral");
                driver.FindElement(By.Name("user")).SendKeys("MWINT8000214R");
                driver.FindElement(By.Name("passwd")).SendKeys("WOCC2019");

                driver.FindElement(By.Name("entrar")).Submit();

                String ValidaIntersicClaro = driver.FindElement(By.TagName("b")).Text;

                

                if (ValidaIntersicClaro == "Claro Matriz")
                {
                    CheckIntersicClaro = true;
                }
                else
                {
                    CheckIntersicClaro = false;
                }

                ScreenDirectory = "\\\\172.21.0.6\\winover$\\TI\\Screen\\IntersicNet.png";

                var IntersicClaro = driver.GetScreenshot();
                IntersicClaro.SaveAsFile(ScreenDirectory);


                driver.FindElement(By.XPath("//*[@id='XXMENU']/table/tbody/tr[15]/td/a")).Click();
            } catch { }
            //

            // Pingar Servidores e Proxy

            //-// Ping Proxy
            try { 
                Ping pingProxy = new Ping();
                PingReply pingresult = pingProxy.Send("172.21.0.39");
                String RespostaPing = pingresult.RoundtripTime.ToString();
                if (pingresult.Status.ToString() == "Success")
                {       
                    checklistTi.Items.Add(sistemas[6] + " | Tempo de resposta: " + RespostaPing, CheckState.Checked);
                    sistemaStatus.Add("Ok" + sistemas[6].ToString() + " | Tempo de resposta: " + RespostaPing);
                }


                Ping pingProxySJC = new Ping();
                PingReply pingresultSJC = pingProxySJC.Send("172.21.0.39");
                String RespostaPingSJC = pingresultSJC.RoundtripTime.ToString();
                if (pingresult.Status.ToString() == "Success")
                {
                    checklistTi.Items.Add(sistemas[7] + " | Tempo de resposta: " + RespostaPingSJC, CheckState.Indeterminate);
                    sistemaStatus.Add("Ok" + sistemas[7].ToString() + " | Tempo de resposta: " + RespostaPingSJC);
                    MessageBox.Show(sistemaStatus[2].ToString());
                } else
                {
                    checklistTi.Items.Add(sistemas[7] + " | Tempo de resposta: " + RespostaPingSJC, CheckState.Unchecked);
                    sistemaStatus.Add("Ok" + sistemas[7].ToString() + " | Tempo de resposta: " + RespostaPingSJC);
                }
            }
            catch { }
            //-//

            //-// Ping Proxy Rotas
            try
            {
                for (int i = 0; i < rotas.Count; i++)
                {
                    Ping pingRota = new Ping();
                    PingReply pingresultRota = pingRota.Send(rotas[i].ToString());
                    String pingResult = pingresultRota.RoundtripTime.ToString();
                    if (pingresultRota.Status.ToString() == "Success")
                    {
                        checklistTi.Items.Add(rotasNomes[i] + ": " + rotas[i] + " | Tempo de resposta: " + pingResult, CheckState.Indeterminate);
                        rotaStatus.Add("Ok" + rotas[i].ToString() + " | Tempo de resposta: " + pingResult);
                    }
                    else
                    {
                        checklistTi.Items.Add(rotasNomes[i] + ": " + rotas[i] + " | Tempo de resposta: " + pingResult, CheckState.Unchecked);
                        rotaStatus.Add(rotasNomes[i].ToString() + " | Tempo de resposta: " + pingResult);
                    }
                }
            }catch { }
            //-//
            
            
            // Validação Se estão Ok os sistemas.
            if (CheckNet == true)
            {
                //sistemaStatus.Add("Ok" + sistemas[0].ToString());
                checklistTi.Items.Add(sistemas[0], CheckState.Indeterminate);
                string sql = "INSERT INTO dbo.checklist values (" + 1 + "," + "'" + sistemas[0].ToString() +"'" + "," + "null" + "," +" GETDATE())";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.CommandType = CommandType.Text;
                conn.Open();

                try
                {
                    int i = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.ToString());
                }
                finally
                {
                    conn.Close();
                }


            } else
            {
                sistemaStatus.Add("Fail" + sistemas[0].ToString());
                checklistTi.Items.Add(sistemas[0], CheckState.Unchecked);
            }

            if (CheckClaro  == true)
            {
                sistemaStatus.Add("Ok" + sistemas[1].ToString());
                checklistTi.Items.Add(sistemas[1], CheckState.Indeterminate);
            } else
            {
                sistemaStatus.Add("Fail" + sistemas[1].ToString());
                checklistTi.Items.Add(sistemas[1], CheckState.Unchecked);
            }

            if (CheckNeo == true)
            {
                sistemaStatus.Add("Ok" + sistemas[2].ToString());
                checklistTi.Items.Add(sistemas[2], CheckState.Indeterminate);
            }
            else
            {
                sistemaStatus.Add("Fail" + sistemas[2].ToString());
                checklistTi.Items.Add(sistemas[2], CheckState.Unchecked);
            }

            if (CheckTotal == true)
            {
                sistemaStatus.Add("Ok" + sistemas[3].ToString());
                checklistTi.Items.Add(sistemas[3], CheckState.Indeterminate);
            }
            else
            {
                sistemaStatus.Add("Fail" + sistemas[3].ToString());
                checklistTi.Items.Add(sistemas[3], CheckState.Unchecked);
            }

            if (CheckOlos == true)
            {
                sistemaStatus.Add("Ok" + sistemas[4].ToString());
                checklistTi.Items.Add(sistemas[4], CheckState.Indeterminate);
            }
            else
            {
                sistemaStatus.Add("Fail" + sistemas[4].ToString());
                checklistTi.Items.Add(sistemas[4], CheckState.Unchecked);
            }

            if (CheckQualidade == true)
            {
                sistemaStatus.Add("Ok" + sistemas[5].ToString());
                checklistTi.Items.Add(sistemas[5], CheckState.Indeterminate);
            }
            else
            {
                sistemaStatus.Add("Fail" + sistemas[5].ToString());
                checklistTi.Items.Add(sistemas[5], CheckState.Unchecked);
            }

            if (CheckIntersicNet == true)
            {
                sistemaStatus.Add("Ok" + sistemas[8].ToString());
                checklistTi.Items.Add(sistemas[8], CheckState.Indeterminate);
            }
            else
            {
                sistemaStatus.Add("Fail" + sistemas[8].ToString());
                checklistTi.Items.Add(sistemas[8], CheckState.Unchecked);
            }

            if (CheckIntersicClaro == true)
            {
                sistemaStatus.Add("Ok" + sistemas[9].ToString());
                checklistTi.Items.Add(sistemas[9], CheckState.Indeterminate);
                
            }
            else
            {
                sistemaStatus.Add("Fail" + sistemas[9].ToString());
                checklistTi.Items.Add(sistemas[9], CheckState.Unchecked);
            }

            MessageBox.Show("Checklist Finalizado");

            //
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Email novaForm = new Email(rotas, sistemas, rotasNomes, sistemaStatus, rotaStatus);
            //novaForm.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
