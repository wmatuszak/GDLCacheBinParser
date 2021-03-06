﻿using System.Collections.Generic;
using System.IO;

namespace PhatACCacheBinParser.Seg9_WeenieDefaults
{
	class Emote
	{
		public uint Category;

		public float Probability;

		public uint? ClassID;

		public uint? Style;
		public uint? Substyle;

		public string Quest;

		public int? VendorType;

		public float? MinHealth;
		public float? MaxHealth;

		public readonly List<EmoteAction> EmoteActions = new List<EmoteAction>();

		public bool Unpack(BinaryReader binaryReader)
		{
			Category = binaryReader.ReadUInt32();

			Probability = binaryReader.ReadSingle();

			if (Category == 1 || Category == 6)
				ClassID = binaryReader.ReadUInt32();

			if (Category == 5)
			{
				Style = binaryReader.ReadUInt32();
				Substyle = binaryReader.ReadUInt32();
			}

			if (Category == 12 || Category == 13 || Category == 22 || Category == 23 || (Category >= 27 && Category <= 38))
				Quest = Util.ReadString(binaryReader, true);

			if (Category == 2)
				VendorType = binaryReader.ReadInt32();

			if (Category == 15)
			{
				MinHealth = binaryReader.ReadSingle();
				MaxHealth = binaryReader.ReadSingle();
			}

			var count = binaryReader.ReadUInt16();
			binaryReader.ReadUInt16(); // discard

			for (int i = 0; i < count; i++)
			{
				var action = new EmoteAction();

				action.Unpack(binaryReader);

				EmoteActions.Add(action);
			}

			return true;
		}
	}
}
