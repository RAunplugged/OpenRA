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
using OpenRA.Traits;

namespace OpenRA.Mods.Common.Traits
{
	[Desc("Changes the production time of this actor for a specific queue.")]
	public class CustomProductionTimeInfo : TraitInfo<CustomProductionTime>
	{
		[FieldLoader.Require]
		[Desc("Custom production time for the unit.")]
		public readonly int BuildTime = -1;

		[Desc("Only apply this time change if owner has these prerequisites.")]
		public readonly string[] Prerequisites = { };

		[Desc("Queues that this time will apply.")]
		public readonly HashSet<string> Queue = new HashSet<string>();
	}

	public class CustomProductionTime { }
}