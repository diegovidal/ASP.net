create database cursosql

create table teste (
	campo1 int,
    campo2 char(2),
    campo3 varchar(50)
)

alter table teste add campo4 int

alter table teste drop campo4

drop table teste

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

create table pessoas(
	codigo int not null auto_increment,
    nome varchar(35) not null,
    cpf varchar(11),
    cidade varchar(35),
    sexo char(1),
    email varchar(50),
    data_cadastro timestamp default now(),
    primary key (codigo),
    unique (cpf),
    check (sexo in ('F', 'M'))

)

insert into pessoas values ('', 'Fulano', '43243', 'Fortaleza', 'F', 'teste@teste.com', null)


UPDATE pessoas set 
email='diegovidal08@gmail.com' 
where nome= 'Diego'

delete from pessoas where codigo=4

select * from pessoas where 1=1 order by nome desc

select * from pessoas where 1=1 order by nome desc limit 2


select * from pessoas where cidade = 'Fortaleza' or cidade = 'Russas'

select * from pessoas where (cidade = 'Fortaleza' or cidade = 'Russas') and sexo = 'M'

select * from pessoas where cidade like '%F%' -- qualquer palavra com letra f (nao é case sensitive)

select distinct cidade from pessoas


--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

select nome, ano from cursos where ano between 2014 and 2016 order by ano desc, nome asc

select nome, descricao, ano from cursos where ano in ( 2014, 2016 ) order by ano

select * from cursos where nome not like '%a%'

select * from cursos where nome like 'ph%p_'

select distinct nacionalidade from gafanhotos order by nacionalidade

select count(*) from cursos 
select count(*) from cursos where carga > 40

select max(carga) from cursos
select max(totaulas) from cursos where ano = '2016'

select min(totaulas) from cursos
select min(totaulas) from cursos where ano = '2016'
select nome, min(totaulas) from cursos where ano = '2016'

select sum(totaulas) from cursos where ano = '2016'

select avg(totaulas) from cursos where ano = '2016'



select totaulas from cursos group by totaulas
select totaulas, count(*) from cursos group by totaulas
select carga, count(nome) from cursos where totaulas = 30 group by carga

select ano, count(*) from cursos group by ano order by count(*)
select ano, count(*) from cursos group by ano having count(ano) >= 5 order by count(*)

select carga, count(*) from cursos where ano > 2015 group by carga
select carga, count(*) as somador from cursos where ano > 2015 group by carga
select carga, count(*) as somador from cursos where ano > 2015 group by carga having carga > (select avg(carga) from cursos)

--xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx

select gafanhotos.nome, gafanhotos.cursopreferido, cursos.nome, cursos.ano from gafanhotos join cursos

-- Todos os casos são considerados inner join, ou seja só vai listar os campos q estão corelacionados com a chave estrangeira
select gafanhotos.nome, gafanhotos.cursopreferido, cursos.nome, cursos.ano from gafanhotos join cursos on cursos.idcurso = gafanhotos.cursopreferido
select gafanhotos.nome, gafanhotos.cursopreferido, cursos.nome, cursos.ano from gafanhotos inner join cursos on cursos.idcurso = gafanhotos.cursopreferido order by gafanhotos.nome
select g.nome, g.cursopreferido, c.nome, c.ano from gafanhotos as g inner join cursos as c on c.idcurso = g.cursopreferido order by g.nome

--Todos os casos são considerados left outer join, ou seja ele vai da preferencia a tabela da esqueda (onde está o from), aparecendo tanto os que tem 
--relacionamento com chave-estrangeira quanto os que não tem relacionamento nenhum
select g.nome, g.cursopreferido, c.nome, c.ano from gafanhotos as g left outer join cursos as c on c.idcurso = g.cursopreferido order by g.nome
select g.nome, g.cursopreferido, c.nome, c.ano from gafanhotos as g left join cursos as c on c.idcurso = g.cursopreferido order by g.nome

--Todos os casos são considerados right outer join, ou seja ele vai da preferencia a tabela da direita (onde está o join), aparecendo tanto os que tem 
--relacionamento com chave-estrangeira quanto os que não tem relacionamento nenhum
select g.nome, g.cursopreferido, c.nome, c.ano from gafanhotos as g right outer join cursos as c on c.idcurso = g.cursopreferido order by g.nome
select g.nome, g.cursopreferido, c.nome, c.ano from gafanhotos as g right join cursos as c on c.idcurso = g.cursopreferido order by g.nome

