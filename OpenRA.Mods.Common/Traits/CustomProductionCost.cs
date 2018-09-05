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
	[Desc("Changes the production cost of this actor for a specific queue.")]
	public class CustomProductionCostInfo : TraitInfo<CustomProductionCost>
	{
		[FieldLoader.Require]
		[Desc("Custom production cost for the unit.")]
		public readonly int Cost = 0;

		[Desc("Only apply this cost change if owner has these prerequisites.")]
		public readonly string[] Prerequisites = { };

		[Desc("Queues that this cost will apply.")]
		public readonly HashSet<string> Queue = new HashSet<string>();
	}

	public class CustomProductionCost { }
}