using System.ComponentModel;
using DevExpress.Data.Linq;
using LDSSM.Contracts.Entities;
using LDSSM.Contracts.Interfaces.IRepositories;
using LDSSM.Repository;

namespace LDSSM.WinForms
{
	public partial class Form1 : Form
	{
		public Form1(IUserRepository userRepository)
		{
			InitializeComponent();
			gridControl1.DataSource = userRepository.GetMultiple().ToList();
		}

		private void Form1_Load(object sender, EventArgs e) { }

		static IListSource CreateServerModeSource(IUserRepository repo)
		{
			var source = new EntityServerModeSource();
			source.ElementType = typeof(UserEntity);
			source.QueryableSource = repo.GetMultiple();
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

		static IListSource CreateInstantFeedbackSource(IUserRepository repo)
		{
			var source = new EntityInstantFeedbackSource();
			source.DesignTimeElementType = typeof(UserEntity);
			source.GetQueryable += (s, e) => e.QueryableSource = repo.GetMultiple();
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}
	}
}
