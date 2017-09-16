SELECT DISTINCT u.Nome,
				u.Sobrenome,
				u.Nascimento,
				u.Altura,
				peso.DataHora AS Pesos_DataHora,
				peso.PesoValue as Pesos_PesoValue,
				alimento.DataHora as Alimentos_DataHora,
				alimento.Tipo as Alimentos_Tipo,
				alimento.Calorias as Alimentos_Calorias,
				exercicio.DataHora as ExerciciosFisicos_DataHora,
				exercicio.Tipo as ExerciciosFisicos_Tipo,
				exercicio.Calorias as ExerciciosFisicos_Calorias,
				pressao.DataHora as PressoesArteriais_DataHora,
				pressao.Status as PressoesArteriais_Status
FROM Usuarios u 
INNER JOIN 
(
	SELECT DISTINCT TOP 5 *
	FROM Pesos p
	ORDER BY p.DataHora DESC
) AS peso ON (peso.UsuarioId = u.Id)
INNER JOIN 
(
	SELECT DISTINCT TOP 5 *
	FROM Alimentos a
	ORDER BY a.DataHora DESC
) AS alimento ON (alimento.UsuarioId = u.Id)
INNER JOIN 
(
	SELECT DISTINCT TOP 5 *
	FROM ExerciciosFisicos e
	ORDER BY e.DataHora DESC
) AS exercicio ON (exercicio.UsuarioId = u.Id)
INNER JOIN 
(
	SELECT DISTINCT TOP 5 *
	FROM PressoesArteriais pr
	ORDER BY pr.DataHora DESC
) AS pressao ON (pressao.UsuarioId = u.Id)
WHERE u.Id = '20f5eb6e-7d69-4aaf-88f2-4268e59f8737'