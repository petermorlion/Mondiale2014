﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using KotProno2.EntityFramework;
using KotProno2.Models;

namespace KotProno2.Controllers
{
    public class BettingsController : ApiController
    {
        private readonly MatchesDbContext _context;

        public BettingsController(MatchesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Authorize]
        public IList<Betting> Get()
        {
            return _context.Bettings.Where(x => x.UserName == User.Identity.Name).ToList();
        }

        [HttpPost]
        [Authorize]
        public void Post(object data)
        {
            var command = new AddBettingsCommand
            {
                DateTime = DateTime.Now,
                Name = "AddBettings",
                Data = data.ToString(),
                UserName = User.Identity.Name,
            };

            command.Execute(_context);
            _context.Commands.Add(command);
            _context.SaveChangesAsync();
        }
    }
}