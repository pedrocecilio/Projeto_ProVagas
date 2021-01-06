-- DQL
-- Consultas sem INNERJOIN

USE ProVagas

GO

--TipoUsuario
SELECT IdTipoUsuario, NomeTipoUsuario as TipoUsuario FROM TipoUsuario
-- Genero
SELECT IdGenero as Genero, NomeGenero FROM Genero
-- Estado
SELECT IdEstado as Estado, NomeEstado FROM Estado
--TipoVaga
SELECT IdTipoVaga as TipoVaga, NomeTipoVaga FROM TipoVaga
--StatusInscricao
SELECT IdStatusInscricao as Status, NomeStatus FROM StatusInscricao
--Beneficio
SELECT IdBeneficio as Beneficio, NomeBeneficio FROM Beneficio
--NivelEscolaridade
SELECT IdNivelEscolaridade as NivelEscolaridade, Escolaridade FROM NivelEscolaridade
--StatusEstagio
SELECT IdStatusEstagio as StatusEstagio, NomeStatus as Status FROM StatusEstagio
--Habilidade 
SELECT IdHabilidade as Habilidade, NomeHabilidade FROM Habilidade
--Requisito
SELECT IdRequisito as Requisito, NomeRequisito FROM Requisito
--PCD
SELECT IdPCD as PCD, NomeDeficiencia FROM PCD 
--NivelIdioma 
SELECT IdNivelIdioma as NivelIdioma, NomeNivel FROM NivelIdioma
--PorteEmpresa
SELECT IdPorteEmpresa as PorteEmpresa, NomePorte FROM PorteEmpresa


-- COM INNER JOIN

-- Cidade
SELECT IdCidade as Cidade,NomeCidade, NomeEstado, Cidade.IdEstado as Estado
FROM Cidade
INNER JOIN Estado on Estado.IdEstado = Cidade.IdEstado

--Endereco

SELECT IdEndereco as Endereco, Rua, Num as Numero, Bairro, Complemento, CEP, E.IdCidade, E.IdUsuario
FROM Endereco E 
INNER JOIN Cidade C on C.IdCidade = E.IdCidade
INNER JOIN Usuario U on U.IdUsuario = E.IdUsuario

-- Usuario
SELECT U.IdUsuario as Usuario, Email, Senha, Telefone, U.IdTipoUsuario as TipoUsuario, NomeTipoUsuario
FROM Usuario U
INNER JOIN TipoUsuario TU on TU.IdTipoUsuario = U.IdTipoUsuario

-- Candidato
SELECT C.IdCandidato as Candidato, NomeCompletoCandidato, CPF, DataNascimento, Linkedin, FotoPerfil, 
E.IdEndereco as Endereco, C.IdGenero as Genero, NomeGenero, C.IdNivelEscolaridade as NivelEscolaridade, Escolaridade, U.IdUsuario as Usuario
FROM Candidato C
INNER JOIN Endereco E on E.IdEndereco = C.IdEndereco
INNER JOIN Usuario U on U.IdUsuario = E.IdUsuario
INNER JOIN Genero G on G.IdGenero = C.IdGenero
INNER JOIN NivelEscolaridade NE on NE.IdNivelEscolaridade = C.IdNivelEscolaridade


--PcdXCandidato
SELECT Pcdc.IdPcdCandidato as PcdcCandidato, PossuiDeficiencia, Pcdc.IdCandidato as Candidato, Pcdc.IdPCD as PCD
FROM PcdXCandidato Pcdc
INNER JOIN Candidato C on C.IdCandidato = Pcdc.IdCandidato
INNER JOIN PCD pcd on pcd.IdPCD = pcdc.IdPCD

--Administrador
SELECT A.IdAdministrador as Administrador, NomeCompletoAdmin, NIF, UnidadeSenai, Departamento,
U.IdUsuario as Usuario
FROM Administrador A
INNER JOIN Usuario U on U.IdUsuario = A.IdUsuario

-- Empresa
SELECT EM.IdEmpresa as Empresa, RazaoSocial, NomeFantasia, NomeParaContato, Linkedin, WebSite, CNPJ, CNAE,EM.IdEndereco as IdEndereco,
E.IdUsuario as Usuario
FROM Empresa EM
INNER JOIN Endereco E on E.IdEndereco = EM.IdEndereco
INNER JOIN Usuario U on U.IdUsuario = E.IdUsuario
I

-- Vaga
SELECT V.IdVaga as Vaga, NomeVaga, DescricaoAtividade, DataInicio, DataFinal, V.IdEmpresa as Empresa, V.IdTipoVaga as TipoVaga, NomeTipoVaga
FROM Vaga V
INNER JOIN Empresa E on E.IdEmpresa = V.IdEmpresa
INNER JOIN TipoVaga TV on TV.IdTipoVaga = V.IdTipoVaga 

-- Inscricao,
SELECT I.IdInscricao as Inscricao, NomeVaga, DataInscricao, DescricaoAtividade, DataFinal, I.IdStatusInscricao as Status, NomeStatus, I.IdVaga as Vaga, V.IdTipoVaga,
V.IdEmpresa as Empresa, I.IdCandidato as Candidato
FROM Inscricao I
INNER JOIN Vaga V on V.IdVaga = I.IdVAga
INNER JOIN StatusInscricao SI on SI.IdStatusInscricao = I.IdStatusInscricao
INNER JOIN Candidato C on C.IdCandidato = I.IdCandidato
INNER JOIN Empresa E on E.IdEmpresa = V.IdEmpresa

-- Estagio
SELECT E.IdEstagio as Estagio, E.DataInicio, E.DataFinal, E.IdStatusEstagio as StatusEstagio, NomeStatus as Status, E.IdInscricao as Inscricao,
DataInscricao, I.IdStatusInscricao as StatusInscricao, NomeStatus as Status
FROM Estagio E
INNER JOIN StatusEstagio SE on SE.IdStatusEstagio = E.IdStatusEstagio
INNER JOIN Inscricao I on I.IdInscricao = E.IdInscricao

-- BenefecioXVaga
SELECT BV.IdBeneficioVaga as BenefecioXVaga, BV.IdBeneficio as Beneficio, NomeBeneficio, BV.IdVaga as Vaga, NomeVaga, DescricaoAtividade, DataInicio, DataFinal
FROM BeneficioxVaga BV
INNER JOIN Beneficio B on B.IdBeneficio = BV.IdBeneficio
INNER JOIN Vaga V on V.IdVaga = BV.IdVaga

--RequisitoXVaga
SELECT RV.IdRequisitoVaga as RequisitoXVaga, RV.IdRequisito as Requisito, NomeRequisito, RV.IdVaga as Vaga, DescricaoAtividade, DataInicio, DataFinal
FROM RequisitoXVaga RV
INNER JOIN Requisito R on R.IdRequisito = RV.IdRequisito
INNER JOIN Vaga V on V.IdVaga = RV.IdVaga

--HabilidadeXCandidato
SELECT HC.IdHabilidadeCandidato as HabilidadeXCandidato, HC.IdHabilidade as Habilidade, NomeHabilidade, HC.IdCandidato as Candidato, NomeCompletoCandidato
FROM HabilidadeXCandidato HC
INNER JOIN Habilidade H on H.IdHabilidade = HC.IdHabilidade
INNER JOIN Candidato C on C.IdCandidato = HC.IdCandidato

--Idioma
SELECT I.IdIdioma as Idioma, NomeIdioma, I.IdNivelIdioma, NomeNivel, I.IdCandidato, NomeCompletoCandidato
FROM Idioma I
INNER JOIN NivelIdioma NI on NI.IdNivelIdioma = I.IdNivelIdioma
INNER JOIN Candidato C on C.IdCandidato = I.IdCandidato

--ExperienciaProfissional
SELECT IdExperienciaProfissional as ExperienciaProfissional, NomeExperiencia, NomeEmpresa, Cargo, DataInicio, DataFim, EmpregoAtual, DescriçãoAtividade,
EX.IdCandidato as Candidato, NomeCompletoCandidato
FROM ExperienciaProfissional EX
INNER JOIN Candidato C on C.IdCandidato = EX.IdCandidato

--CursoSENAI
SELECT IdCursoSENAI as CursoSENAI, CursandoSENAI, Curso, CS.IdCandidato as Candidato, NomeCompletoCandidato
FROM CursoSENAI CS 
INNER JOIN Candidato C on C.IdCandidato = CS.IdCandidato

--CursoExtraCurricular
SELECT IdCursoExtraCurricular as CursoExtraCurricular, NomeCurso, Instituicao, Nivel, DataInicio, DataFim, Cec.IdCandidato as Candidato, NomeCompletoCandidato
FROM CursoExtraCurricular Cec
INNER JOIN Candidato C on C.IdCandidato = Cec.IdCandidato

Select * from Empresa

select * from Usuario