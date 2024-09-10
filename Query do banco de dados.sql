Create database Cliente;
use Cliente;

Create table Clientes(
ID INT IDENTITY(1,1) PRIMARY KEY,
NOME VARCHAR(255) NOT NULL,
CPF INT NOT NULL,
ENDERECO VARCHAR(255) NOT NULL,
ESTADOCIVIL VARCHAR(255) NOT NULL,
GENERO VARCHAR(255) NOT NULL
);


--Nao esquecer de alterar na concte string com os seus dados de usuario Sa e password