using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TodoList.Data;
using TodoList.Core;

namespace TodoList.Web.Pages.Tasks
{
    public class ListModel : PageModel
    {
        private readonly ITaskData taskData;
        public IEnumerable<Task> Tasks { get; set; }

        [TempData]
        public string MessageOK { get; set; }

        [TempData]
        public string MessageError { get; set; }

        [BindProperty]
        public Task Task { get; set; }

        public ListModel(ITaskData taskData)
        {
            this.taskData = taskData;
        }

        public void OnGet(int taskId)
        {
            Tasks = taskData.GetAll();
            Task = new Task();
        }

        public void OnPost(int taskId)
        {

        }

        public IActionResult OnPostCreate()
        {
            Task task;

            if (ModelState.IsValid && (task = taskData.Add(Task)) != null)
            {
                TempData["MessageOK"] = $"New task added to list";
            }
            else
            {
                TempData["MessageError"] = "Task add failed. Description Can not be empty";
            }

            return RedirectToPage("./List");
        }

        public IActionResult OnPostDelete(int taskId)
        {
            Task task = taskData.Remove(taskId);

            if (task == null)
            {
                TempData["MessageError"] = "Task delete failed";
            }
            TempData["MessageOK"] = $"{task.Description} deleted";
            return RedirectToPage("./List");
        }

        public IActionResult OnPostCheckBox(int taskId,string status)
        {
            Task task = taskData.UpdateStatus(taskId);

            if (task == null)
            {
                TempData["MessageError"] = "Task update failed";
            }
            TempData["MessageOK"] = $"{task.Description} status updated";

            return RedirectToPage("./List");
        }

    }
}