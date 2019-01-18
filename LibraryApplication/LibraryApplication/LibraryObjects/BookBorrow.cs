﻿using System;

namespace LibraryApplication.LibraryObjects
{
    public class BookBorrow
    {
        public Book Book { get; set; }

        public DateTime BorrowedAt { get; set; }

        public DateTime BorrowedUntil { get; set; }
    }
}
