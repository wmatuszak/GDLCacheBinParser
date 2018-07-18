﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhatACCacheBinParser.Enums
{
    public enum SKILL_ADVANCEMENT_CLASS
    {
        UNDEF_SKILL_ADVANCEMENT_CLASS,
        UNTRAINED_SKILL_ADVANCEMENT_CLASS,
        TRAINED_SKILL_ADVANCEMENT_CLASS,
        SPECIALIZED_SKILL_ADVANCEMENT_CLASS,
        NUM_SKILL_ADVANCEMENT_CLASSES
    }

    public enum SKILL_CATEGORY
    {
        UNDEF_SKILL_CATEGORY,
        WEAPON_SKILL_CATEGORY,
        NONWEAPON_SKILL_CATEGORY,
        MAGIC_SKILL_CATEGORY,
        NUM_SKILL_CATEGORIES
    }
}