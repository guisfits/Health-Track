select top 1 u.Nome,
			 u.Sobrenome,
			 u.Nascimento,
			 u.Altura
from Usuarios u
where u.Id = @UserId

-- Pesos
select top 5 peso.DataHora,
			 peso.PesoValue
from Pesos peso
where peso.UsuarioId = @UserId
order by peso.DataHora desc

-- Alimentos
select top 5 alimento.DataHoram,
			 alimento.Tipo,
			 alimento.Calorias
from Alimentos alimento
where alimento.UsuarioId = @UserId
order by alimento.DataHora desc

-- Exercicios
select top 5 exercicio.DataHora,
			 exercicio.Tipo,
			 exercicio.Calorias
from ExerciciosFisicos exercicio
where exercicio.UsuarioId  = @UserId
order by exercicio.DataHora desc

-- Pressões
select top 5 pressao.DataHora,
			 pressao.[Status],
			 pressao.Sistolica,
			 pressao.Diastolica
from PressoesArteriais pressao
where pressao.UsuarioId = @UserId
order by pressao.DataHora