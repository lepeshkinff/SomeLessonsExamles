using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using CbIntegrator.Bussynes.Repositories;

namespace CbIntegrator.UI
{
	public partial class MainForm : Form
	{
		private BindingSource bindingSource = new BindingSource();		
		private readonly CurenciesRepository curenciesRepository;

		public MainForm(CurenciesRepository curenciesRepository)
		{
			InitializeComponent();
			this.curenciesRepository = curenciesRepository;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			bindingSource.DataSource = curenciesRepository.GetCurencies();

			// Resize the DataGridView columns to fit the newly loaded content.
			dataGridView1.AutoResizeColumns(
				 DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

			dataGridView1.DataSource = bindingSource;
		}
	}
}