﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Koks_PM_V3.Domain.Models
{
    public class Note : IRecord
    {
        public Note(Guid noteID, string noteName, 
            string noteLogin, string notePassword, 
            string noteUrl, string noteTotp, 
            Guid categoryID, Guid userID, 
            DateTime modifyDate, DateTime createDate)
        {
            this.noteID = noteID;
            this.noteName = noteName;
            this.noteLogin = noteLogin;
            this.notePassword = notePassword;
            this.noteUrl = noteUrl;
            this.noteTotp = noteTotp;
            this.categoryID = categoryID;
            this.userID = userID;
            this.modifyDate = modifyDate;
            this.createDate = createDate;
        }

        public Guid ID => noteID;
        public Guid CategoryID => categoryID;
        public Guid UserID => userID;
        public string Title => noteName;
        public string Desctiption => noteLogin;

        public Guid noteID { get; set; }
        public string noteName { get; set; }
        public string noteLogin { get; set; }
        public string notePassword { get; set; }
        public string noteUrl { get; set; }
        public string noteTotp { get; set; }
        public Guid categoryID { get; set; }
        public Guid userID { get; set; }
        public DateTime modifyDate { get; set; }
        public DateTime createDate { get; set; }

    }
}
