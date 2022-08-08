using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReproductorVideo
{
    public partial class Form1 : Form
    {

        int vl = 50;
        public OpenFileDialog archivo = new OpenFileDialog();
        int play = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnVolumen_Click(object sender, EventArgs e)
        {
            macTrackBarVolumen.Visible = true;
        }

        private void macTrackBarVolumen_MouseLeave(object sender, EventArgs e)
        {
            macTrackBarVolumen.Visible = false;
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (play == 1)
            {
                AbrirMusica();
                play = 2;
            }
            else if (play == 2)
            {
                MediaPlay.Ctlcontrols.pause();
                tmSlider.Stop();

                btnPlay.BackgroundImage = Properties.Resources.punta_de_flecha_del_boton_de_reproduccion__2_;
                play = 3;
            }
            else if (play == 3)
            {
                MediaPlay.Ctlcontrols.play();
                tmSlider.Start();

                btnPlay.BackgroundImage = Properties.Resources.pause_button;
                play = 2;
            }

        }

        string ruta;
        public void AbrirMusica()
        {

            try
            {

                MediaPlay.URL = @"" + ruta;
                MediaPlay.Ctlcontrols.play();

                this.Visible = true;
                tmSlider.Start();

                macTrackBarDuracion.Enabled = true;

                btnPlay.BackgroundImage = Properties.Resources.pause_button;

            }
            catch
            {


            }
        }

        private void macTrackBarDuracion_ValueChanged(object sender, decimal value)
        {
            macTrackBarDuracion.Maximum = (int)MediaPlay.currentMedia.duration;

            if (macTrackBarDuracion.Value == (int)MediaPlay.Ctlcontrols.currentPosition)
            {

            }
            else
            {

                MediaPlay.Ctlcontrols.currentPosition = macTrackBarDuracion.Value;

            }
        }

        private void tmSlider_Tick(object sender, EventArgs e)
        {
            try
            {
                macTrackBarDuracion.Value = (int)MediaPlay.Ctlcontrols.currentPosition;
                label1.Text = MediaPlay.Ctlcontrols.currentPositionString;
                label2.Text = MediaPlay.currentMedia.durationString;
            }
            catch
            {


            }
        }

        private void btnL_Click(object sender, EventArgs e)
        {
            if ((macTrackBarDuracion.Value = macTrackBarDuracion.Value - 15) < 0)
            {
                macTrackBarDuracion.Value = 0;
            }
            else
            {
                macTrackBarDuracion.Value = macTrackBarDuracion.Value - 15;
            }
        }

        public void AbrirArchivo() // metodo para buscar el archivo multimedia para abrir
        {

            archivo.Filter = "Archivo files|*.mp3;*.mp4;.*;";
            DialogResult dres1 = archivo.ShowDialog();
            if (dres1 == DialogResult.Abort)
                return;
            if (dres1 == DialogResult.Cancel)
                return;
            ruta = archivo.FileName;
            label4.Text = archivo.SafeFileName;


        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AbrirArchivo();

                if (ruta != "")
                {
                    play = 2;
                    AbrirMusica();

                }
                else
                {

                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void macTrackBarVolumen_ValueChanged(object sender, decimal value)
        {
            MediaPlay.settings.volume = macTrackBarVolumen.Value;



            label3.Text = MediaPlay.settings.volume.ToString();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            macTrackBarDuracion.Value = macTrackBarDuracion.Value + 10;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label3.Text = (macTrackBarVolumen.Value = MediaPlay.settings.volume = vl).ToString();
            this.MediaPlay.uiMode = "none";
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
