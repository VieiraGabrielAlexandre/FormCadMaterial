using CadMaterial.Business;
using System;
using System.Data;
using System.Windows.Forms;

namespace CadMaterial
{


    public partial class FormActivityStatus : Form
    {
        DataTable processosStatusTable, areasStatusTable, unitStatusTable;
        Connection processosStatus, areasStatus, unitStatus;


        private String stringDeClasses; // Passa uma lista de classes previamente formatada

        private void cbAreaAmProcess_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarLinhasPorAreas();
            carregarProcessosPorClasses();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarProcessosPorClasses();
        }

        private void FormActivityStatus_Load(object sender, EventArgs e)
        {
            carregarProcessosPorClasses();
        }

        private void dgListaDeProcessos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            activityCounter.Text = dgListaDeProcessos.RowCount + " atividades";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Classes utilizadas: " + stringDeClasses);
        }

        public FormActivityStatus(String stringDeClasses, String materialID)
        {
            InitializeComponent();
            this.stringDeClasses = stringDeClasses;

            /* Carregar as áreas */
            areasStatus = new Connection("AM_PROCESS_SP", " DISTINCT(PROCESS_AREA) ",
                                        " WHERE PRODUCT_ID IN('" + stringDeClasses + "','ALL')"); // Carregar áreas que estão disponíveis

            areasStatusTable = areasStatus.loadDataTable();

            cbAreaAmProcess.DataSource = areasStatusTable;
            cbAreaAmProcess.DisplayMember = "PROCESS_AREA";

            /* Carregar as linhas */
            unitStatus = new Connection("AM_PROCESS_SP", " DISTINCT(UNIT_ID) ",
                                        " WHERE PRODUCT_ID IN('" + stringDeClasses + "','ALL')"
                                        + " AND PROCESS_AREA = 'BR SELAGEM' "); // Deixar dinamico

            unitStatusTable = unitStatus.loadDataTable();

            cbUnitAmProcess.DataSource = unitStatusTable;
            cbUnitAmProcess.DisplayMember = "UNIT_ID";



            this.Text = "Processos por Area/Classes - Produto " + materialID;
            this.groupBoxAmProcess.Text = "AM_PROCESS_SP - Produto " + materialID;

            carregarProcessosPorClasses();
        }

        private void carregarProcessosPorClasses()
        {
            processosStatus = new Connection("AM_PROCESS_SP", " PROCESS_ID, PROCESS_DESC, PRODUCT_ID, SEQUENCE_GROUP, PREREQ_GROUP ",
                                        " WHERE PRODUCT_ID IN('" + stringDeClasses + "','ALL') AND PROCESS_AREA = '"
                                           + cbAreaAmProcess.Text + "' " +
                                           "AND UNIT_ID = '" + cbUnitAmProcess.Text + "'"); // Carregar classes pela área na AM_PROCESS_SP

            processosStatusTable = processosStatus.loadDataTable();

            dgListaDeProcessos.DataSource = processosStatusTable;

        }

        private void carregarLinhasPorAreas()
        {
            /* Carregar as linhas por áreas */
            unitStatus = new Connection("AM_PROCESS_SP", " DISTINCT(UNIT_ID) ",
                                        " WHERE PRODUCT_ID IN('" + stringDeClasses + "','ALL')" +
                                        " AND PROCESS_AREA = '" 
                                        + cbAreaAmProcess.Text + "'");

            unitStatusTable = unitStatus.loadDataTable();

            cbUnitAmProcess.DataSource = unitStatusTable;
            cbUnitAmProcess.DisplayMember = "UNIT_ID";
        }
    }
}
