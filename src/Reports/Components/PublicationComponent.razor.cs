using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using PublishActivity.Data.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reports.Components
{
	public partial class PublicationComponent
	{
		[Inject]
		public IDbContextFactory<BasePpsContext> _dbContextFactory { get; set; }

		[Parameter]
		public StructuralPart StructuralPart { get; set; }

		private IEnumerable<AuthorPubl> _authorPubls;

		protected override async Task OnInitializedAsync()
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			_authorPubls = context.AuthorPubls.Include(x => x.StructuralPartIdPartNavigation).ThenInclude(x => x.EditionIdEdtNavigation).Include(x => x.AuthorU).Where(x => StructuralPart.IdPart == x.StructuralPartIdPart).ToList();
			await base.OnInitializedAsync();
		}
	}
}
