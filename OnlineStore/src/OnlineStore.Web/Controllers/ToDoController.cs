﻿using Microsoft.AspNetCore.Mvc;
using OnlineStore.Core;
using OnlineStore.Core.Entities;
using OnlineStore.SharedKernel.Interfaces;
using OnlineStore.Web.ApiModels;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Web.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IRepository _repository;

        public ToDoController(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Index()
        {
            var items = (await _repository.ListAsync<ToDoItem>())
                            .Select(ToDoItemDTO.FromToDoItem);
            return View(items);
        }

        public IActionResult Populate()
        {
            int recordsAdded = DatabasePopulator.PopulateDatabase(_repository);
            return Ok(recordsAdded);
        }
    }
}