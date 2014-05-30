﻿using Breeze.ContextProvider.EF6;
using KotProno2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KotProno2.EntityFramework
{
    public class MatchesContext : EFContextProvider<MatchesDbContext>
    {
        protected override bool BeforeSaveEntity(Breeze.ContextProvider.EntityInfo entityInfo)
        {
            if (entityInfo.Entity.GetType() == typeof(Match))
                return false;

            if (entityInfo.Entity.GetType() == typeof(Team))
                return false;

            return base.BeforeSaveEntity(entityInfo);
        }
    }
}