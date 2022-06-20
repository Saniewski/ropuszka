
create schema if not exists core;

create table core.Person (
	IdPerson serial primary key,
	FirstName text not null,
	LastName text not null
);

insert into core.Person
(FirstName, LastName) values
('George', 'Washington'),
('Abraham', 'Lincoln');
