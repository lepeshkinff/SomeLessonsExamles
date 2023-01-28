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
		private readonly IUsersRepository repository;

		private const int _pageSize = 2;

		public MainForm(IUsersRepository repository)
		{
			InitializeComponent();
			this.repository = repository;
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			CreatePager();
			LoadUsersPage(0);
		}

		private void tabPage1_Click(object sender, EventArgs e)
		{

		}

		private void pagerLb_SelectedIndexChanged(object sender, EventArgs e)
		{
			var page = pagerLb.SelectedIndex;
			LoadUsersPage(page);
		}

		private void CreatePager()
		{
			var repo = repository as DbContextUserRepository;
			foreach (var page in repo.GetPages())
			{
				pagerLb.Items.Add(page.ToString());
			}				
			pagerLb.SelectedIndex = 0;
			pagerLb.SelectedIndexChanged += pagerLb_SelectedIndexChanged;
		}

		
		private void LoadUsersPage(int page)
		{
			bindingSource.DataSource = repository.GetUsers(page, _pageSize);

			// Resize the DataGridView columns to fit the newly loaded content.
			dataGridView1.AutoResizeColumns(
				 DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);

			dataGridView1.DataSource = bindingSource;
		}
	}
}