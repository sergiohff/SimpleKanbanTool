﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SimpleKanbanTool.Models
{
    [Serializable]
    public class Task
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        private Status status;
        public Status Status
        {
            get { return status; }
            set { status = value; }
        }

        private int topOffset;
        public int TopOffset
        {
            get { return topOffset; }
            set { topOffset = value; }
        }

        private int leftOffset;
        public int LeftOffset
        {
            get { return leftOffset; }
            set { leftOffset = value; }
        }

    }
}