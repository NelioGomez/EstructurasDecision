namespace ControlRegistroEstacionamiento
{
    public partial class frmEstacionamiento : Form
    {
        string dia;
        public frmEstacionamiento()
        {
            InitializeComponent();
        }

        private void frmEstacionamiento_Load(object sender, EventArgs e)
        {
            // Mostrando la fecha actaul
            lblFecha.Text = DateTime.Now.ToShortDateString();

            // Determinar el dia
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            dia = fecha.ToString("dddd");

            double costo = 0;
            
            switch(dia)
            {
                case "domingo": costo = 2; break;
                case "lunes": 
                case "martes":
                case "miercoles": 
                case "jueves": 
                    costo = 4; break;
                case "viernes": 
                case "sabado": 
                    costo = 7; break;
            }
            lblCosto.Text = costo.ToString("0.00");
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Capturadno los datos del formulario
            string placa = txtPlaca.Text;
            double costo = double.Parse(lblCosto.Text);
            DateTime fecha = DateTime.Parse(lblFecha.Text);
            DateTime HoraInicio = DateTime.Parse(txtHoraInicio.Text);
            DateTime HoraFin = DateTime.Parse(txtHoraFin.Text);

            // Calcular horas
            TimeSpan hora = HoraFin - HoraInicio;

            // calcular el importe
            double importe = costo * (hora.TotalHours);

            ListViewItem fila = new ListViewItem(placa);
            fila.SubItems.Add(fecha.ToString("d"));
            fila.SubItems.Add(HoraInicio.ToString("t"));
            fila.SubItems.Add(HoraFin.ToString("t"));
            fila.SubItems.Add(hora.TotalHours.ToString());
            fila.SubItems.Add(costo.ToString("C"));
            fila.SubItems.Add(importe.ToString("C"));
            lvRegistro.Items.Add(fila);

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            txtPlaca.Clear();
            txtHoraInicio.Clear();
            txtHoraFin.Clear();
            txtPlaca.Focus();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Estas seguro que desea salir?",
                                             "Estacionamiento",
                                             MessageBoxButtons.YesNo,
                                             MessageBoxIcon.Question);
            if (r == DialogResult.Yes)
                this.Close();
        }
    }
}