﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using SimpleKanbanTool.Models;
using System.Net;

namespace SimpleKanbanTool.Controllers
{
    public class TaskController : ApiController
    {
        private ITaskRepository repository;

        public TaskController(ITaskRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<Task> GetTasks()
        {
            var tasks = repository.Get().ToList<Task>();
            return tasks;
        }

        public HttpResponseMessage<Task> PostTask(Task task)
        {
            task = repository.Add(task);
            var response = new HttpResponseMessage<Task>(task, HttpStatusCode.Created);
            response.Headers.Location = new Uri(Request.RequestUri, "api/task/" + task.Id);
            return response;
        }

        public Task DeleteTask(int id)
        {
            Task task = repository.Get(id);
            if (task == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            repository.Delete(id);
            return task;
        }

        public void PutTask(int id, Task value)
        {
            Task task = repository.Get(id);
            if (task == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            task.Status = value.Status;
            task.TopOffset = value.TopOffset;
            task.LeftOffset = value.LeftOffset;
        }
    }
}
