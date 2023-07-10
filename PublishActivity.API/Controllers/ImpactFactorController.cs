using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublishActivity.Data.Models;
using PublishActivity.Services.Services.Interfaces;
using Reports.Exceptions;
using System.Net;
using System.Text;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace PublishActivity.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ImpactFactorController : ControllerBase
	{
		private readonly IImpactFactorService _impactFactorService;
		private readonly IDbContextFactory<BasePpsContext> _dbContextFactory;

		public ImpactFactorController(IImpactFactorService impactFactorService, IDbContextFactory<BasePpsContext> dbContextFactory)
		{
			_impactFactorService = impactFactorService;
			_dbContextFactory = dbContextFactory;
		}

		[HttpGet("get/{issn}")]
		public async Task<ActionResult> GetImpactFactor(string issn)
		{
			var impactFactor = await _impactFactorService.FindAsync(issn);
			return impactFactor is { } ? Ok(impactFactor) : StatusCode(404);
		}

		[HttpPost("update/{issn}")]
		public async Task<ActionResult> UpdateImpactFactor(string issn)
		{
			await using var context = await _dbContextFactory.CreateDbContextAsync();
			var editions = context.Editions.Where(x => x.Issn == issn).ToList();

			if (!editions.Any())
			{
				return StatusCode(404);
			}

			var impactFactors = await _impactFactorService.FindAsync(issn);

			if (impactFactors is null)
			{
				return StatusCode(404);
			}

			foreach (var edition in editions)
			{
				try
				{

					await _impactFactorService.UpdateImpactFactorAsync(edition.IdEdt, impactFactors);
				}
				catch
				{
					return StatusCode(400, edition);
				}
			}

			return StatusCode(200);
		}
	}
}

