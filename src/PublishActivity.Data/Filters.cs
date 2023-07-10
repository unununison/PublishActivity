using System.ComponentModel.DataAnnotations;

namespace PublishActivity.Data
{
	public sealed class Filters
	{
		public AbstractBase AbstractBase { get; set; }
		public string? UpperBoundImpactFactorYear { get; set; }

		public string? LowerBoundImpactFactorYear { get; set; }

		public string? UpperBoundAge { get; set; }

		public string? LowerBoundAge { get; set; }

		public string? UpperBoundYear { get; set; }

		public string? LowerBoundYear { get; set; }

		public bool IsImpactFactorSelected { get; set; }

		private int? _languageId;

		public int? LanguageId
		{
			get
			{
				return _languageId;
			}
			set
			{
				if (value == -1)
				{
					_languageId = null;
				}
				else
				{
					_languageId = value;
				}
			}
		}

		private int? _publicationTypeId;

		public int? PublicationTypeId
		{
			get
			{
				return _publicationTypeId;
			}
			set
			{
				if (value == -1)
				{
					_publicationTypeId = null;
				}
				else
				{
					_publicationTypeId = value;
				}
			}
		}

		public string? InputAuthor { get; set; }

		public string? PublishType { get; set; }

		public string? Issn { get; set; }

		public string? Isbn { get; set; }

		private int? _sprFormatInfoId;

		public int? SprFormatInfoId
		{
			get
			{
				return _sprFormatInfoId;
			}
			set
			{
				if (value == -1)
				{
					_sprFormatInfoId = null;
				}
				else
				{
					_sprFormatInfoId = value;
				}
			}
		}

		public string? OfficeDepartId { get; set; }

		public string? DifSovetId { get; set; }

		private int? idThematic;

		public int? IdThematic
		{
			get => idThematic;
			set
			{
				if (value == -1)
				{
					idThematic = null;
				}
				else
				{
					idThematic = value;
				}
			}
		}

		public string? LevelEdition { get; set; }
	}
}
