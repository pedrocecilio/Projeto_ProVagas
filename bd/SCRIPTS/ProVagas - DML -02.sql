-- DML

USE ProVagas

GO


INSERT INTO TipoUsuario VALUES (
	'Candidato'
), (
	'Empresa'
), (
	'Administrador'
)

GO

INSERT INTO Usuario VALUES 
('gugugacasco@gmail.com', '(11) 970707070', '123456789', 1), 
('posarle@hotmail.com', '(11) 970707070', '123456789', 3),
('brq@brq.com', '(11) 954616677', '123456789', 2)
GO

INSERT INTO Endereco VALUES
('Rua Carlos Alves',  '12', 'Vila do chaves', null, '000000010', 'São Paulo', 'São Paulo', 1),
('Alameda Barão de Limeira',  '539', 'Santa Cecilia', null, '01202-001', 'São Paulo', 'SP', 2),
('R. Boa Vista', '254', 'Centro Histórico de São Paulo', null, '01014-000', 'São Paulo', 'SP', 3 )
GO

INSERT INTO NivelEscolaridade VALUES 
('Fundamental'), ('Médio'), ('Tecnico'), ('Graduação'), ('Pós-graduação'), ('Mestrado'), ('Doutorado')
GO

INSERT INTO Candidato VALUES 
('Hebert12 Richard', '04533130080', '2000-10-20', 'linkedin/hebertrichard', null, null,'masculino', 0, null, null, null, 1,'Desenvolvimento de Sistemas', null, 1, 3)
GO


INSERT INTO ExperienciaProfissional VALUES 
('Desenvolvedor junior BACK-END', 'BRQ', 'Desenvolvedor junior', '2020-08-15', '2022-08-15', 0,'IDEJFIEIEJDEDJEDEJDIEJDEIJDEI', 1)
GO

INSERT INTO Habilidade VALUES 
('C#'), ('Angular'), ('Phyton'), ('JavaScript'), ('ReactJs'), ('MongoDB'), ('SqlServer')
GO

INSERT INTO HabilidadeXCandidato VALUES
(1, 1), (2,1)
GO

INSERT INTO Administrador VALUES 
('Roberto Possarle', '123456789', 'Unidade Santa Cecilia', 'Gestão de pessoas', 2)
GO


INSERT INTO Empresa VALUES 
('BRQ SOLUCOES EM INFORMATICA S.A', 'BRQ', 'Paixão em transformar negócios com tecnologia.'
, 'Justus', 'linkedin/BRQ', NULL, '365420250001640', '62040000', 'Grande', 3)
GO

INSERT INTO TipoVaga VALUES 
('CLT'), ('Estagio'), ('Pj')
GO

INSERT INTO NivelVaga VALUES  ('Junior'), ('Pleno'), ('Senior')
GO

INSERT INTO Vaga VALUES 
('Estagio em desenvolvimento de sistemas', ' Executar o desenvolvimento de sistemas informatizados',
'17/12/2020', '30/12/2020', 40, 'Sâo Paulo', 'R$ 1080,00', 0, 1, 2, 1)
GO


INSERT INTO Requisito VALUES 
('C#')
GO

INSERT INTO RequisitoXVaga VALUES
(1,2)
GO

INSERT INTO StatusInscricao VALUES
('Aprovado'), ( 'Cancelado'), ('Reprovado'), ('Em aguardo')
GO

INSERT INTO Inscricao VALUES 
('31/08/2020',1,4,4)
GO

SELECT * FROM Candidato

INSERT INTO Estagio VALUES 
('2020/09/04','2022/09/04','Em andamento', 1)
GO

INSERT INTO Beneficio VALUES
('Vale Refeição'), ('Vale Alimentação'), ('Vale Transporte'), ('Estacionamento no local'), ('Assistência Médica'), ('Assistência Odontológica'), ('Cesta Básica'), ('Seguro de Vida'),  ('Horário Flexível'), ('Auxílio Creche')
GO

INSERT INTO BeneficioXVaga VALUES 
(1,2)
GO

INSERT INTO Contratos VALUES
('2020/09/04','2022/09/04', 'Teste', 'Teste')
GO
SELECT * FROM Vaga

--------------INSERT DAS TABELAS ANTIGAS------------------------

/*

INSERT INTO Genero VALUES (
	'Masculino'
), (
	'Feminino'
), (
	'Outros'
), (
	'Prefiro não informar'
)

GO

INSERT INTO Estado VALUES (
		'São Paulo'
	), (
		'Santa Catarina'
	), (
		'Minas Gerais'
	), (
		'Goiás'
	),  (
		'Bahia'
	),
	 (
		'Paraná'
	),
	 (
		'Ceará'
	),
	 (
		'Rio Grande do Sul'
	),
	 (
		'Amazonas'
	),
	 (
		'Pernambuco'
	),
	 (
		'Pará'
	),
	 (
		'Mato Grosso'
	),
	 (
		'Paraíba'
	),
	 (
		'Sergipe'
	),
	 (
		'Espirito Santo'
	),
	 (
		'Piauí'
	),
	 (
		'Maranhão'
	),
	 (
		'Rio Grande do Norte'
	),
	 (
		'Rondônia'
	), (
		'Amapá'
	),  (
		'Tocantins'
	),
	 (
		'Alagoas'
	), (
		'Rio de Janeiro'
	), (
		'Mato Grosso do Sul'
	), (
		'Roraima'
	), (
		'Brasília'
	), (
		'Acre'
)

GO


INSERT INTO Cidade VALUES (
	'São Paulo',1
), (
	'Florianópolis',2
), (
	'Belo Horizonte',3
), (
	'Goiânia',4
)

GO

INSERT INTO PCD VALUES 
('Deficiência física'), ('Deficiência auditiva'), ('Deficiência visual'), ('Deficiência mental'), ('Deficiência múltipla'), ('Nenhuma')
GO

INSERT INTO PcdXCandidato VALUES 
(0, 1, 6)
GO

INSERT INTO NivelIdioma VALUES 
('Basico'), ('Tecnico'), ('Intermediario'), ('Avançado')
GO

INSERT INTO Idioma VALUES 
('Inglês', 2,1)
GO

INSERT INTO CursoSENAI VALUES 
(1, 'Tecnico em desenvolvimento de sistemas', 1)
GO

INSERT INTO CursoExtraCurricular VALUES 
('MBA - Gesâo de projeto', 'MBA', null, '2015-08-14', '2018-12-20', 1)
GO

INSERT INTO PorteEmpresa VALUES 
('Pequena'), ('Médio'), ('Grande')
GO

INSERT INTO StatusEstagio VALUES
('Evadido'), ('Em andamento'), ('Concluido')
GO


*/