insert into Book
values('The Iliad', null)

insert into Book
values('Mackbeth', 1623)

insert into Book
values('Pan Tadeusz', 1834)

insert into Book
values('Dziady', 1822)

insert into Book
values('The Old Man and the Sea', 1952)

insert into Book
values('Emma', null)

insert into Author
values('Homer', null)

insert into Author
values('William', 'Shakespeare')

insert into Author
values('Adam', 'Mickiewicz')

insert into Author
values('Ernest', 'Hemingway')

insert into Author
values('Jane', 'Austen')

insert into BookAuthor
values(1,1)

insert into BookAuthor
values(2,2)

insert into BookAuthor
values(3,3)

insert into BookAuthor
values(3,4)

insert into BookAuthor
values(4,5)

insert into BookAuthor
values(5,6)

insert into Category
values('Must',1)

insert into Category
values('Maybe',2)

insert into Category
values('Probably never',3)

insert into BookCategory
values(1,3,GETDATE(),1,1)

insert into BookCategory
values(2,2,GETDATE(),0,2)