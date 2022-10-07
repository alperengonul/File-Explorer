using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace _19._10._2021_winpencere_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            List<DriveInfo> suruculer = DriveInfo.GetDrives().Where(s => s.IsReady == true).ToList();

            comboBox1.DataSource = suruculer;
            comboBox1.ValueMember = "Name";
            comboBox1.DisplayMember = "Name";

            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                string seciliSurucu = comboBox1.Items[comboBox1.SelectedIndex].ToString();
              
               var dizinler = Directory.GetDirectories(seciliSurucu);
                listBox1.Items.Clear();
                foreach (var item in dizinler)
                {
                    listBox1.Items.Add(item);
                }
            }
            
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();

            string seciliDizin = listBox1.SelectedItem.ToString();

            DirectoryInfo Dosya = new DirectoryInfo(seciliDizin);
            FileInfo[] ddosyalar = null;
            DirectoryInfo[] kklasorler = null;

            try
            {
                ddosyalar = Dosya.GetFiles();
                kklasorler = Dosya.GetDirectories();
            }
            catch (Exception)
            {

                MessageBox.Show("Dosya Yoluna Erişim Reddedildi!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                if (ddosyalar != null && kklasorler != null)
                {
                    for (int i = 0; i < kklasorler.Length; i++)
                    {
                        listBox2.Items.Add(kklasorler[i].ToString());
                        
                    }
                    for (int i = 0; i < ddosyalar.Length; i++)
                    {
                        listBox2.Items.Add(ddosyalar[i].ToString());
                    }
                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
