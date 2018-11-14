#region Copyright & License Information
/*
 * Copyright 2007-2018 The OpenRA Developers (see AUTHORS)
 * This file is part of OpenRA, which is free software. It is made
 * available to you under the terms of the GNU General Public License
 * as published by the Free Software Foundation, either version 3 of
 * the License, or (at your option) any later version. For more
 * information, see COPYING.
 */
#endregion

using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using OpenRA.Graphics;
using OpenRA.Primitives;
using OpenRA.Traits;

namespace OpenRA.Mods.Common.Traits
{
	[Desc("Actors footprint is shown in map previews. Defaults to the owner's color unless Color or Terrain is set")]
	public class AppearsOnMapPreviewInfo : TraitInfo<AppearsOnMapPreview>, IMapPreviewSignatureInfo, Requires<IOccupySpaceInfo>
	{
		[Desc("Use this color to render the actor, instead of owner player color.")]
		public readonly HSLColor Color = default(HSLColor);

		[Desc("Use this terrain color to render the actor, instead of owner player color.",
			"Overrides `Color` if both set.")]
		public readonly string Terrain = null;

		void IMapPreviewSignatureInfo.PopulateMapPreviewSignatureCells(ActorReference reference, ActorInfo info, Map map, CellLayer<Color> colorOverlayBuffer)
		{
			var tileSet = map.Rules.TileSet;

			Color color;
			if (!string.IsNullOrEmpty(Terrain))
				color = tileSet[tileSet.GetTerrainIndex(Terrain)].Color;
			else if (Color != default(HSLColor))
				color = Color.RGB;
			else
			{
				var mapPlayers = new MapPlayers(map.PlayerDefinitions).Players;
				var ownerName = reference.InitDict.Get<OwnerInit>().PlayerName;

				// Ignore the actor if an invalid owner is referenced
				PlayerReference ownerReference;
				if (!mapPlayers.TryGetValue(ownerName, out ownerReference))
					return;

				color = ownerReference.Color.RGB;
			}

			var ios = info.TraitInfo<IOccupySpaceInfo>();
			var cells = ios.OccupiedCells(info, reference.InitDict.Get<LocationInit>().Value(null));
			foreach (var cell in cells)
				colorOverlayBuffer[cell.Key] = color;
		}
	}

	public class AppearsOnMapPreview { }
}