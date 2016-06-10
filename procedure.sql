select * from Time

--==========DELETE====================

create procedure excluirTimePorId(
	@id int
)

as 

begin
	delete from Time where id=@id
end

exec excluirTimePorId @id = 2

--==========UPDATE==================

create procedure atualizarTime
(
	@id int,
	@nome varchar(100),
	@estado char(2),
	@cores nvarchar(50)
)

as

begin
	Update Time set nome = @nome,
	estado = @estado, cores = @cores where id = @id
end

exec atualizarTime @id = 1, @nome = 'a', @estado = 'JH', @cores = 'cor'

--=========INSERT================

create procedure incluirTime
(
	@nome varchar(100),
	@estado char(2),
	@cores nvarchar(50)
)

as

begin
	insert into Time values (@nome, @estado, @cores)
end

exec incluirTime @nome = 'Santos', @estado = 'SP', @cores = 'Preto e Branco'

--=========SELECT================

create procedure obterTimes

as

begin
	select * from Time
end

exec obterTimes