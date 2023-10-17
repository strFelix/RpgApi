CREATE TABLE [dbo].[TB_DISPUTAS](
	[Id] [int] IDENTITY(1,1) NOT NULL constraint PK_Disputas primary key,
	[Dt_Disputa] [datetime2](7) NULL,
	[AtacanteId] [int] NOT NULL,
	[OponenteId] [int] NOT NULL,
	[Tx_Narracao] [nvarchar](max) NULL)

go
INSERT INTO TB_DISPUTAS VALUES 
(getdate(), 3, 6, 'Galadriel atacou Celeborn usando Machado com o dano 48.'),
(getdate(), 7, 2, 'Atacante: Radagast. Oponente: Sam.  Pontos de vida do atacante: 100.  Pontos de vida do oponente: 66.  Arma Utilizada: Cajado.  Dano: 9.'),
(getdate(), 5, 4, 'Atacante: Hobbit. Oponente: Gandalf.  Pontos de vida do atacante: 100.  Pontos de vida do oponente: 52.  Habilidade Utilizada: Adormecer.  Dano: 48.')
