using System.ComponentModel;
using DevExpress.Data.Linq;
using DevExpress.XtraBars;
using LDSSM.Contracts.Entities;
using LDSSM.Contracts.Interfaces.IRepositories;
using LDSSM.Repository;

namespace LDSSM.WinForms
{
	public partial class DXGridForm : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		private readonly LDSSMDbContext dbContext;
		private readonly IUserRepository userRepository;

		public DXGridForm(LDSSMDbContext dbContext, IUserRepository userRepository)
		{
			this.dbContext = dbContext;
			this.userRepository = userRepository;
			InitializeComponent();
		}

		private void DXGridForm_Load(object sender, EventArgs e) { }

		static IListSource CreateServerModeSource(LDSSMDbContext dbContext)
		{
			var source = new EntityServerModeSource();
			source.ElementType = typeof(UserEntity);
			source.QueryableSource = dbContext.Users;
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

		static IListSource CreateInstantFeedbackSource(LDSSMDbContext dbContext)
		{
			var source = new EntityInstantFeedbackSource();
			source.DesignTimeElementType = typeof(UserEntity);
			source.GetQueryable += (s, e) => e.QueryableSource = dbContext.Users;
			source.KeyExpression = nameof(UserEntity.Id);
			return source;
		}

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

		private void barToggleSwitchItem_CheckedChanged(
			object sender,
			DevExpress.XtraBars.ItemClickEventArgs e
		)
		{
			var checkItem = sender as DevExpress.XtraBars.BarToggleSwitchItem;
			if (!checkItem.Checked)
			{
				gridControl1.DataSource = null;
				return;
			}

			foreach (var link in ribbonPageGroup1.ItemLinks.OfType<BarToggleSwitchItemLink>())
			{
				var ci = link.Item as BarToggleSwitchItem;
				if (ci == checkItem)
					continue;
				ci.Checked = false;
			}
			//gridControl1.DataSource = dbContext.Users; // error, requires load
			//gridControl1.DataSource = userRepository.GetMultiple().Take(1_000).ToList(); // Too much GB if I load all data

			if (sender == barToggleSwitchItem1)
			{
				gridControl1.DataSource = CreateServerModeSource(dbContext);
			}
			else if (sender == barToggleSwitchItem2)
			{
				gridControl1.DataSource = CreateInstantFeedbackSource(dbContext);
			}
			else if (sender == barToggleSwitchItem3)
			{
				gridControl1.DataSource = CreateServerModeSource(userRepository);
			}
			else if (sender == barToggleSwitchItem4)
			{
				gridControl1.DataSource = CreateInstantFeedbackSource(userRepository);
			}
		}
	}
}
