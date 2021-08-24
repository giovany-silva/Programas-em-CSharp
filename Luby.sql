create table tabela_pessoa(id serial primary key,nome varchar)

create table tabela_evento(id serial primary key,evento varchar,pessoa_id int, foreign key (pessoa_id) references tabela_pessoa(id) ON DELETE CASCADE); 

insert into tabela_pessoa(nome)  values('John Doe');
insert into tabela_pessoa(nome)  values('Jane Doe');
insert into tabela_pessoa(nome)  values('Alice Jones ');
insert into tabela_pessoa(nome)  values('Bobby Louis');
insert into tabela_pessoa(nome)  values('Lisa Romero');

select * from tabela_pessoa;

insert into tabela_evento(evento,pessoa_id)  values('Evento A',2);
insert into tabela_evento(evento,pessoa_id)  values('Evento B',3);
insert into tabela_evento(evento,pessoa_id)  values('Evento C',2);
insert into tabela_evento(evento,pessoa_id)  values('Evento D',null);


select * from tabela_evento;

--2.1
select p.nome,e.evento from tabela_pessoa p join tabela_evento e on(p.id = e.pessoa_id);
--2.2 
select nome from tabela_pessoa where nome like '%Doe';
--2.3
insert into tabela_evento(evento,pessoa_id) values ('Evento E',5);
--2.4
update tabela_evento
	set pessoa_id = 1
where evento ='Evento D';
--2.5 
delete from tabela_evento where evento = 'Evento B';
--2.6
delete from tabela_pessoa p where  not EXISTS (select 1 from tabela_evento where pessoa_id = p.id);
--2.7
alter table tabela_pessoa add column idade int;
--2.8
create table tabela_telefone(id int primary key,telefone varchar(200),pessoa_id int,foreign key (pessoa_id) references tabela_pessoa(id) ON DELETE CASCADE);
--2.9
alter table tabela_telefone add constraint restricao unique(telefone);
--2.10
drop table tabela_telefone;
'''+----+--------------+
| tabela_pessoa     |
+----+--------------+
| id | nome         |
+----+--------------+
|  1 | John Doe     |
|  2 | Jane Doe     |
|  3 | Alice Jones  |
|  4 | Bobby Louis  |
|  5 | Lisa Romero  |
+----+--------------+
+----+----------------+-----------+
| tabela_evento                   |
+----+----------------+-----------+
| id | evento         | pessoa_id |
+----+----------------+-----------+
|  1 | Evento A       |  2        |
|  2 | Evento B       |  3        |
|  3 | Evento C       |  2        |
|  4 | Evento D       |  NULL     |
+----+----------------+-----------+'''
