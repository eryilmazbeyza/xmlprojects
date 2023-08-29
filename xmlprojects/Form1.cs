using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace xmlprojects
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlElement root = xmlDocument.CreateElement("Tedarikciler");

            SqlConnection con = new SqlConnection("Server=.;Database=Northwind;Integrated Security=true;");
            SqlCommand command = new SqlCommand("select*from Tedarikciler", con);
            con.Open();
            SqlDataReader reader=command.ExecuteReader();
            while (reader.Read())
            {
                XmlElement tedarikci = xmlDocument.CreateElement("Tedarikci");
                XmlAttribute adres = xmlDocument.CreateAttribute("Adres");
                adres.Value = reader["Adres"].ToString();

                XmlAttribute sehir = xmlDocument.CreateAttribute("Sehir");
                sehir.Value = reader["Sehir"].ToString();

                XmlAttribute ulke = xmlDocument.CreateAttribute("Ulke");
                ulke.Value = reader["Ulke"].ToString();

                tedarikci.Attributes.Append(adres);
                tedarikci.Attributes.Append(sehir);
                tedarikci.Attributes.Append(ulke);
                root.AppendChild(tedarikci);

            }

            con.Close();
            xmlDocument.AppendChild(root);
            xmlDocument.Save("veri.xml");

          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("hello erybne");
        }
    }
}
