﻿using System.Collections.Generic;

using ACE.Database.Models.World;
using ACE.Entity.Enum.Properties;

using PhatACCacheBinParser.Enums;

namespace PhatACCacheBinParser.ACE_Helpers
{
    static class WeenieDefaultsExtensiosn
    {
        public static List<Weenie> ConvertToACE(this Seg9_WeenieDefaults.WeenieDefaults input)
        {
            var results = new List<Weenie>();

            foreach (var value in input.Weenies)
            {
                var converted = value.ConvertToACE();

                results.Add(converted);
            }

            return results;
        }

        public static Weenie ConvertToACE(this KeyValuePair<uint, Seg9_WeenieDefaults.Weenie> input)
        {
            var result = new Weenie();

            result.ClassId = input.Key;
            result.ClassName = ((WeenieClasses)input.Value.WCID).GetNameFormattedForDatabase();
            result.Type = input.Value.WeenieType;

            if (input.Value.IntValues != null)
            {
                foreach (var value in input.Value.IntValues)
                    result.WeeniePropertiesInt.Add(new WeeniePropertiesInt { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.LongValues != null)
            {
                foreach (var value in input.Value.LongValues)
                    result.WeeniePropertiesInt64.Add(new WeeniePropertiesInt64 { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.BoolValues != null)
            {
                foreach (var value in input.Value.BoolValues)
                    result.WeeniePropertiesBool.Add(new WeeniePropertiesBool { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.DoubleValues != null)
            {
                foreach (var value in input.Value.DoubleValues)
                    result.WeeniePropertiesFloat.Add(new WeeniePropertiesFloat { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.StringValues != null)
            {
                foreach (var value in input.Value.StringValues)
                    result.WeeniePropertiesString.Add(new WeeniePropertiesString { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.DIDValues != null)
            {
                foreach (var value in input.Value.DIDValues)
                    result.WeeniePropertiesDID.Add(new WeeniePropertiesDID { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.PositionValues != null)
            {
                foreach (var value in input.Value.PositionValues)
                {
                    result.WeeniePropertiesPosition.Add(new WeeniePropertiesPosition()
                    {
                        ObjCellId = value.Value.ObjCellID,
                        OriginX = value.Value.Origin.X,
                        OriginY = value.Value.Origin.Y,
                        OriginZ = value.Value.Origin.Z,
                        AnglesX = value.Value.Angles.X,
                        AnglesY = value.Value.Angles.Y,
                        AnglesZ = value.Value.Angles.Z,
                        AnglesW = value.Value.Angles.W,
                    });
                }
            }

            if (input.Value.IIDValues != null)
            {
                foreach (var value in input.Value.IIDValues)
                    result.WeeniePropertiesIID.Add(new WeeniePropertiesIID { Type = (ushort)value.Key, Value = value.Value });
            }

            if (input.Value.Attributes != null)
            {
                result.WeeniePropertiesAttribute.Add(new WeeniePropertiesAttribute { Type = (ushort)PropertyAttribute.Strength, InitLevel = (uint)input.Value.Attributes.Strength.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Strength.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Strength.CPSpent });
                result.WeeniePropertiesAttribute.Add(new WeeniePropertiesAttribute { Type = (ushort)PropertyAttribute.Endurance, InitLevel = (uint)input.Value.Attributes.Endurance.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Endurance.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Endurance.CPSpent });
                result.WeeniePropertiesAttribute.Add(new WeeniePropertiesAttribute { Type = (ushort)PropertyAttribute.Quickness, InitLevel = (uint)input.Value.Attributes.Quickness.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Quickness.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Quickness.CPSpent });
                result.WeeniePropertiesAttribute.Add(new WeeniePropertiesAttribute { Type = (ushort)PropertyAttribute.Coordination, InitLevel = (uint)input.Value.Attributes.Coordination.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Coordination.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Coordination.CPSpent });
                result.WeeniePropertiesAttribute.Add(new WeeniePropertiesAttribute { Type = (ushort)PropertyAttribute.Focus, InitLevel = (uint)input.Value.Attributes.Focus.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Focus.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Focus.CPSpent });
                result.WeeniePropertiesAttribute.Add(new WeeniePropertiesAttribute { Type = (ushort)PropertyAttribute.Self, InitLevel = (uint)input.Value.Attributes.Self.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Self.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Self.CPSpent });

                result.WeeniePropertiesAttribute2nd.Add(new WeeniePropertiesAttribute2nd { Type = (ushort)PropertyAttribute2nd.MaxHealth, InitLevel = (uint)input.Value.Attributes.Health.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Health.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Health.CPSpent });
                result.WeeniePropertiesAttribute2nd.Add(new WeeniePropertiesAttribute2nd { Type = (ushort)PropertyAttribute2nd.MaxStamina, InitLevel = (uint)input.Value.Attributes.Stamina.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Stamina.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Stamina.CPSpent });
                result.WeeniePropertiesAttribute2nd.Add(new WeeniePropertiesAttribute2nd { Type = (ushort)PropertyAttribute2nd.MaxMana, InitLevel = (uint)input.Value.Attributes.Mana.InitLevel, LevelFromCP = (uint)input.Value.Attributes.Mana.LevelFromCP, CPSpent = (uint)input.Value.Attributes.Mana.CPSpent });
            }

            if (input.Value.Skills != null)
            {
                foreach (var value in input.Value.Skills)
                    result.WeeniePropertiesSkill.Add(new WeeniePropertiesSkill { Type = (ushort)value.Key, LevelFromPP = value.Value.LevelFromPP, SAC = (uint)value.Value.Sac, PP = (uint)value.Value.PP, InitLevel = (uint)value.Value.InitLevel, ResistanceAtLastCheck = (uint)value.Value.ResistanceAtLastCheck, LastUsedTime = value.Value.LastUsedTime });
            }

            if (input.Value.BodyParts != null)
            {
                foreach (var value in input.Value.BodyParts)
                {
                    result.WeeniePropertiesBodyPart.Add(new WeeniePropertiesBodyPart
                    {
                        Key = (ushort)value.Key,

                        DType = value.Value.DType,
                        DVal = value.Value.DVal,
                        DVar = value.Value.DVar,

                        BaseArmor = value.Value.ArmorValues.BaseArmor,
                        ArmorVsSlash = value.Value.ArmorValues.ArmorVsSlash,
                        ArmorVsPierce = value.Value.ArmorValues.ArmorVsPierce,
                        ArmorVsBludgeon = value.Value.ArmorValues.ArmorVsBludgeon,
                        ArmorVsCold = value.Value.ArmorValues.ArmorVsCold,
                        ArmorVsFire = value.Value.ArmorValues.ArmorVsFire,
                        ArmorVsAcid = value.Value.ArmorValues.ArmorVsAcid,
                        ArmorVsElectric = value.Value.ArmorValues.ArmorVsElectric,
                        ArmorVsNether = value.Value.ArmorValues.ArmorVsNether,

                        BH = value.Value.BH,

                        HLF = value.Value.SD.HLF,
                        MLF = value.Value.SD.MLF,
                        LLF = value.Value.SD.LLF,

                        HRF = value.Value.SD.HRF,
                        MRF = value.Value.SD.MRF,
                        LRF = value.Value.SD.LRF,

                        HLB = value.Value.SD.HLB,
                        MLB = value.Value.SD.MLB,
                        LLB = value.Value.SD.LLB,

                        HRB = value.Value.SD.HRB,
                        MRB = value.Value.SD.MRB,
                        LRB = value.Value.SD.LRB,
                    });
                }
            }

            if (input.Value.SpellCastingProbability != null)
            {
                foreach (var value in input.Value.SpellCastingProbability)
                    result.WeeniePropertiesSpellBook.Add(new WeeniePropertiesSpellBook { Spell = value.Key, Probability = value.Value });
            }

            if (input.Value.EventFilters != null)
            {
                foreach (var value in input.Value.EventFilters)
                    result.WeeniePropertiesEventFilter.Add(new WeeniePropertiesEventFilter { Event = value });
            }

            if (input.Value.Emotes != null)
            {
                foreach (var kvp in input.Value.Emotes)
                {
                    // kvp.key not used

                    foreach (var value in kvp.Value)
                    {
                        var efEmote = new WeeniePropertiesEmote
                        {
                            Category = (uint)value.Category,
                            Probability = value.Probability,

                            WeenieClassId = value.ClassID,

                            Style = value.Style,
                            Substyle = value.Substyle,

                            Quest = value.Quest,

                            VendorType = value.VendorType,

                            MinHealth = value.MinHealth,
                            MaxHealth = value.MaxHealth
                        };

                        foreach (var action in value.EmoteActions)
                        {
                            var efAction = new WeeniePropertiesEmoteAction
                            {
                                Type = (uint)action.Type,
                                Delay = action.Delay,
                                Extent = action.Extent,

                                Motion = action.Motion,

                                Message = action.Message,
                                TestString = action.TestString,
                                Min = action.Min,
                                Max = action.Max,
                                Min64 = action.Min64,
                                Max64 = action.Max64,
                                MinDbl = action.MinDbl,
                                MaxDbl = action.MaxDbl,
                                Stat = action.Stat,
                                Display = action.Display,

                                Amount = action.Amount,
                                Amount64 = action.Amount64,
                                HeroXP64 = action.HeroXP64,

                                Percent = action.Percent,

                                SpellId = action.SpellID,

                                WealthRating = action.WealthRating,
                                TreasureClass = action.TreasureClass,
                                TreasureType = action.TreasureType,

                                PScript = action.PScript,

                                Sound = action.Sound
                            };

                            if (action.Item != null)
                            {
                                efAction.WeenieClassId = action.Item.WCID;
                                efAction.Palette = action.Item.Palette;
                                efAction.Shade = action.Item.Shade;
                                efAction.DestinationType = (sbyte)action.Item.Destination;
                                efAction.StackSize = action.Item.StackSize;
                                efAction.TryToBond = action.Item.TryToBond;
                            }

                            if (action.Frame != null)
                            {
                                efAction.OriginX = action.Frame.Origin.X;
                                efAction.OriginY = action.Frame.Origin.Y;
                                efAction.OriginZ = action.Frame.Origin.Z;

                                efAction.AnglesX = action.Frame.Angles.X;
                                efAction.AnglesY = action.Frame.Angles.Y;
                                efAction.AnglesZ = action.Frame.Angles.Z;
                                efAction.AnglesW = action.Frame.Angles.W;
                            }

                            if (action.Position != null)
                            {
                                efAction.ObjCellId = action.Position.ObjCellID;

                                efAction.OriginX = action.Position.Origin.X;
                                efAction.OriginY = action.Position.Origin.Y;
                                efAction.OriginZ = action.Position.Origin.Z;

                                efAction.AnglesX = action.Position.Angles.X;
                                efAction.AnglesY = action.Position.Angles.Y;
                                efAction.AnglesZ = action.Position.Angles.Z;
                                efAction.AnglesW = action.Position.Angles.W;
                            }

                            efEmote.WeeniePropertiesEmoteAction.Add(efAction);
                        }

                        result.WeeniePropertiesEmote.Add(efEmote);
                    }
                }
            }

            if (input.Value.CreateList != null)
            {
                foreach (var value in input.Value.CreateList)
                    result.WeeniePropertiesCreateList.Add(new WeeniePropertiesCreateList { WeenieClassId = (uint)value.WCID, Palette = (sbyte)value.Palette, Shade = value.Shade, DestinationType = (sbyte)value.Destination, StackSize = value.StackSize, TryToBond = value.TryToBond });
            }

            if (input.Value.PagesData != null)
            {
                result.WeeniePropertiesBook = new WeeniePropertiesBook { MaxNumPages = input.Value.PagesData.MaxNumPages, MaxNumCharsPerPage = input.Value.PagesData.MaxNumCharsPerPage };

                if (input.Value.PagesData.Pages != null)
                {
                    foreach (var value in input.Value.PagesData.Pages)
                        result.WeeniePropertiesBookPageData.Add(new WeeniePropertiesBookPageData { AuthorId = value.AuthorID, AuthorName = value.AuthorName, AuthorAccount = value.AuthorAccount, IgnoreAuthor = value.IgnoreAuthor, PageText = value.Text });
                }
            }

            if (input.Value.Generators != null)
            {
                foreach (var value in input.Value.Generators)
                {
                    result.WeeniePropertiesGenerator.Add(new WeeniePropertiesGenerator
                    {
                        Probability = value.Probability,
                        WeenieClassId = (uint)value.Type,
                        Delay = (uint)value.Delay, // Can be null. Is there a default null value in the cache.bin?

                        InitCreate = (uint)value.InitCreate,
                        MaxCreate = (uint)value.MaxNum,

                        WhenCreate = (uint)value.WhenCreate,
                        WhereCreate = (uint)value.WhereCreate,

                        StackSize = value.StackSize, // Can be null. Is there a default null value in the cache.bin?

                        PaletteId = (uint)value.PalleteTypeID, // Can be null. Is there a default null value in the cache.bin?
                        Shade = value.Shade, // Can be null. Is there a default null value in the cache.bin?

                        // Can be null. Is there a default null value in the cache.bin?
                        ObjCellId = value.Position.ObjCellID,
                        OriginX = value.Position.Origin.X,
                        OriginY = value.Position.Origin.Y,
                        OriginZ = value.Position.Origin.Z,
                        AnglesX = value.Position.Angles.X,
                        AnglesY = value.Position.Angles.Y,
                        AnglesZ = value.Position.Angles.Z,
                        AnglesW = value.Position.Angles.W

                        // Slot
                    });
                }
            }


            if (input.Value.Palette != null)
            {
                foreach (var value in input.Value.Palette.SubPalettes)
                    result.WeeniePropertiesPalette.Add(new WeeniePropertiesPalette { SubPaletteId = (uint)value.ID, Offset = value.Offset, Length = value.NumberOfColors });
            }

            if (input.Value.TextureMaps != null)
            {
                foreach (var value in input.Value.TextureMaps)
                    result.WeeniePropertiesTextureMap.Add(new WeeniePropertiesTextureMap { Index = value.Index, OldId = (uint)value.OldTextureID, NewId = (uint)value.NewTextureID });
            }

            if (input.Value.AnimParts != null)
            {
                foreach (var value in input.Value.AnimParts)
                    result.WeeniePropertiesAnimPart.Add(new WeeniePropertiesAnimPart { Index = value.Index, Id = (uint)value.ID });
            }

            return result;
        }
    }
}