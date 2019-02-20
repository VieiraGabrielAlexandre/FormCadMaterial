using CadMaterial.Business;
using System;
using System.Collections;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CadMaterial
{
    public partial class FormMaterialEdit : Form
    {
        DataTable materialTable;
        DataTable processAreaTable, processAreaClassTable, processosPelaAreaClasseTable;
        
        String stringDeClassesParaQuery;

        Connection material;
        Connection processArea, processAreaClass, processosPelaAreaClasse; // uma conexão para material/process e uma table para material/process

        public FormMaterialEdit()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (txtClassMaterial.Text.Length > 1024)
                MessageBox.Show("O campo de classes não pode exceder 1024 caracteres.", "Tamanho excedido", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (cbProductAmProcess.Text.Length < 1) // Não existe classe com menos de 1 caracterer
                    MessageBox.Show(null, "Selecione uma classe para poder adicionar ao produto.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    if (txtClassMaterial.TextLength > 0) // Adiciona uma virgula caso já tenha algo e depois a classe
                        txtClassMaterial.AppendText(",");
                    txtClassMaterial.AppendText(cbProductAmProcess.Text.TrimEnd()); // Adiciona a classe selecionada no grupo AM_PROCESS_SP
                }
            }

        }

        private void cbAreaAmProcess_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarAreasEClasses();
        }

        private void cbProductAmProcess_SelectionChangeCommitted(object sender, EventArgs e)
        {
            carregarProcessosPelasClasses();

            
        }

        private void btnLoadedActivities_Click(object sender, EventArgs e)
        { 
            if (txtClassMaterial.Text.Length < 1 || txtClassMaterial.Text == "UNASSIGNED") // Se não houver nenhuma classe
                MessageBox.Show("Nenhuma classe foi detectada", "Nenhuma classe", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                if (txtClassMaterial.Text.Contains(",")) // Verifica se há alguma vírgula e formata para fazer consulta
                    stringDeClassesParaQuery = Regex.Replace(txtClassMaterial.Text.ToUpper(), @"\,", "','");
                else
                    stringDeClassesParaQuery = txtClassMaterial.Text.ToUpper();
                
                FormActivityStatus formActivityStatus = new FormActivityStatus(stringDeClassesParaQuery, 
                    txtMaterialID.Text);
                formActivityStatus.Show();
            }
        }

        private void txtMaterialID_KeyDown(object sender, KeyEventArgs e)
        {
            DataRow[] foundRows;
            if (e.KeyCode == Keys.Enter)
            {
                if (txtMaterialID.Text.Length < 1)
                    MessageBox.Show("O código digitado não existe.", "Nenhum código", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    try
                    { // Realiza uma busca na materialTable
                        foundRows = materialTable.Select("MATERIAL_ID = '" + txtMaterialID.Text + "'");

                        if (foundRows.Length > 0)
                        {
                            txtMaterialDesc.Text =  foundRows[0]["MATL_DESC"].ToString();
                            txtClassMaterial.Text = foundRows[0]["PRODUCT_CLASS"].ToString();
                        }
                        else
                            MessageBox.Show("Favor inserir um código válido.", "Nenhum código",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }
            }
        }

        private void carregarProcessosPelasClasses()
        {
            /*
             * Preencherá o combobox de processos de acordo com a classe e a área selecionada
             */
            if (!(cbProductAmProcess.Text.Length < 1))
            {
                this.cbProductAmProcess.Enabled = true;
                this.cbAreaAmProcess.Enabled = true;

                processosPelaAreaClasse = new Connection("AM_PROCESS_SP", "DISTINCT(PROCESS_ID), PROCESS_DESC ", " WHERE PROCESS_AREA = '"
                                            + cbAreaAmProcess.Text + "' AND PRODUCT_ID ='" + cbProductAmProcess.Text + "' ORDER BY PROCESS_ID"); // Carregar classes pela área na AM_PROCESS_SP

                processosPelaAreaClasseTable = processosPelaAreaClasse.loadDataTable();

                dgListaDeProcessos.DataSource = processosPelaAreaClasseTable;
            }
        }

        private void dgListaDeProcessos_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            activityCounter.Text = dgListaDeProcessos.RowCount + " atividades";
        }

        private void carregarAreasEClasses()
        {
            if (!(cbAreaAmProcess.Text.Length < 1)) // Carregar classes de acordo com o campo PROCESS_AREA (DISTINCT)
            {
                processAreaClass = new Connection("AM_PROCESS_SP", "DISTINCT(PRODUCT_ID)", " WHERE PROCESS_AREA = '" 
                                                + cbAreaAmProcess.Text + "'"); // Carregar classes pela área na AM_PROCESS_SP

                processAreaClassTable = processAreaClass.loadDataTable();

                this.cbProductAmProcess.DataSource = processAreaClassTable;
                this.cbProductAmProcess.DisplayMember = "PRODUCT_ID";

                carregarProcessosPelasClasses();
            }
        }

      

        private void FormMaterialEdit_Load(object sender, EventArgs e)
        {
            txtMaterialID.Select();
            txtMaterialID.Focus();


            material = new Connection("MM_MATERIAL_SP","TRIM(MATERIAL_ID) MATERIAL_ID, MATL_DESC, PRODUCT_CLASS "," ORDER BY MATERIAL_ID");

            processArea = new Connection("AM_PROCESS_SP","DISTINCT(PROCESS_AREA)"); // Carregar áreas pela AM_PROCESS_SP 
            
            processAreaTable      = processArea.loadDataTable();
            materialTable         = material.loadDataTable();

            this.cbAreaAmProcess.DataSource       = processAreaTable; // Atribui o novo dataTable
            this.cbCarregarMaterial.DataSource    = materialTable;

            this.cbCarregarMaterial.DisplayMember = "MATERIAL_ID"; // Escolher a coluna a carregar
            this.cbAreaAmProcess.DisplayMember    = "PROCESS_AREA";

            if (materialTable != null)
            {
                txtMaterialID.AutoCompleteCustomSource = GetAutoSourceCollectionFromTable(materialTable);
                txtMaterialID.AutoCompleteMode = AutoCompleteMode.Suggest;
            }


            carregarAreasEClasses(); // Função para carregar uma combobox com os valores de outra

        }

        private AutoCompleteStringCollection GetAutoSourceCollectionFromTable(DataTable table)
        {
            AutoCompleteStringCollection autoSourceCollection = new AutoCompleteStringCollection();

            foreach (DataRow row in table.Rows)
            {
                autoSourceCollection.Add(row[0].ToString()); //assuming required data is in first column
            }
            
            return autoSourceCollection;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Carrega os valores para os campos de acordo com as colunas do dataTable carregado do banco de dados

            txtMaterialID.Text    = materialTable.Rows[cbCarregarMaterial.SelectedIndex][materialTable.Columns["MATERIAL_ID"].Ordinal].ToString().TrimEnd();
            txtMaterialDesc.Text  = materialTable.Rows[cbCarregarMaterial.SelectedIndex][materialTable.Columns["MATL_DESC"].Ordinal].ToString();
            txtClassMaterial.Text = materialTable.Rows[cbCarregarMaterial.SelectedIndex][materialTable.Columns["PRODUCT_CLASS"].Ordinal].ToString();
        }
    }
}
