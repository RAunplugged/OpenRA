using OpenRA.Graphics;

namespace OpenRA.Traits
{
	[Desc("Render this actor when creating the minimap while saving the map.")]
	public class RenderOnMapPreviewInfo : TraitInfo<RenderOnMapPreview>, Requires<IOccupySpaceInfo>
	{
		[Desc("Use this color to render the actor, instead of owner player color.")]
		public readonly HSLColor Color = new HSLColor();

		[Desc("Use this terrain color to render the actor, instead of owner player color.",
			"Overrides `Color` if both set.")]
		public readonly string Terrain = null;
	}

	public class RenderOnMapPreview { }
}