-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-12-07 22:41:51.898

-- tables
-- Table: Author
CREATE TABLE Author (
    ID int  NOT NULL IDENTITY,
    FirstName varchar(50)  NOT NULL,
    LastName varchar(50)  NOT NULL,
    CONSTRAINT Author_pk PRIMARY KEY  (ID)
);

-- Table: Book
CREATE TABLE Book (
    ID int  NOT NULL IDENTITY,
    Title varchar(50)  NOT NULL IDENTITY,
    Year int  NULL,
    CONSTRAINT Book_pk PRIMARY KEY  (ID)
);

-- Table: BookAuthor
CREATE TABLE BookAuthor (
    Author_ID int  NOT NULL,
    Book_ID int  NOT NULL,
    CONSTRAINT BookAuthor_pk PRIMARY KEY  (Author_ID,Book_ID)
);

-- Table: BookCategory
CREATE TABLE BookCategory (
    Book_ID int  NOT NULL,
    Category_ID int  NOT NULL,
    WhenAdded datetime  NOT NULL,
    IsRead bit  NOT NULL,
    Position int  NOT NULL,
    CONSTRAINT BookCategory_pk PRIMARY KEY  (Book_ID)
);

-- Table: Category
CREATE TABLE Category (
    ID int  NOT NULL IDENTITY,
    CategoryText varchar(50)  NOT NULL,
    CategoryValue int  NOT NULL,
    CONSTRAINT Category_pk PRIMARY KEY  (ID)
);

-- foreign keys
-- Reference: Table_6_Author (table: BookAuthor)
ALTER TABLE BookAuthor ADD CONSTRAINT Table_6_Author
    FOREIGN KEY (Author_ID)
    REFERENCES Author (ID);

-- Reference: Table_6_Book (table: BookAuthor)
ALTER TABLE BookAuthor ADD CONSTRAINT Table_6_Book
    FOREIGN KEY (Book_ID)
    REFERENCES Book (ID);

-- Reference: ToRead_Book (table: BookCategory)
ALTER TABLE BookCategory ADD CONSTRAINT ToRead_Book
    FOREIGN KEY (Book_ID)
    REFERENCES Book (ID);

-- Reference: ToRead_Category (table: BookCategory)
ALTER TABLE BookCategory ADD CONSTRAINT ToRead_Category
    FOREIGN KEY (Category_ID)
    REFERENCES Category (ID);

-- End of file.

