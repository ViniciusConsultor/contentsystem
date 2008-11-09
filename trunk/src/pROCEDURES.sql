/****** Object:  StoredProcedure [dbo].[BUSCAR_DADOS_NOTA_FISCAL]    Script Date: 11/09/2008 17:09:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[BUSCAR_DADOS_NOTA_FISCAL]
	@ID_TRANSACAO INT

AS

UPDATE TRANSACOES SET NUMERO_NOTA_FISCAL = (SELECT ISNULL(MAX(NUMERO_NOTA_FISCAL),0)+1 FROM TRANSACOES)
WHERE ID_TRANSACAO = @ID_TRANSACAO AND NUMERO_NOTA_FISCAL IS NULL


SELECT NUMERO_NOTA_FISCAL, DATA_TRANSACAO, F.DESCRICAO FORMA_PAGAMENTO, VALOR_TOTAL
FROM TRANSACOES T
JOIN FORMA_PAGAMENTO F ON F.ID_FORMA_PAGAMENTO = T.ID_FORMA_PAGAMENTO
WHERE ID_TRANSACAO = @ID_TRANSACAO



SELECT	CASE IN_ENTRADA_SAIDA WHEN 'E' THEN 'ENTRADA' ELSE 'SAÍDA' END DIRECAO, NOME, QUANTIDADE, PRECO_UNITARIO, QUANTIDADE * PRECO_UNITARIO VALOR_TOTAL
FROM	ITENS_TRANSACOES I
JOIN	PRODUTOS P ON P.CODIGO_INTERNO = I.ID_PRODUTO
WHERE	ID_TRANSACAO = @ID_TRANSACAO




GO
/****** Object:  StoredProcedure [dbo].[RELATORIO_PRODUTOS_MAIS_VENDIDOS]    Script Date: 11/09/2008 17:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[RELATORIO_PRODUTOS_MAIS_VENDIDOS]
	@DATA_INICIAL SMALLDATETIME,
	@DATA_FINAL SMALLDATETIME

AS


SELECT	P.NOME, SUM(IT.QUANTIDADE)
FROM	PRODUTOS P
JOIN	ITENS_TRANSACOES IT ON IT.ID_PRODUTO = P.CODIGO_INTERNO
JOIN	TRANSACOES T ON T.ID_TRANSACAO = IT.ID_TRANSACAO
WHERE	T.ID_TIPO_TRANSACAO IN ( 2,3,4) AND IN_ENTRADA_SAIDA = 'S'
GROUP BY P.NOME
ORDER BY 2 DESC


GO
/****** Object:  StoredProcedure [dbo].[RELATORIO_PRODUTOS_SEM_ESTOQUE]    Script Date: 11/09/2008 17:09:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[RELATORIO_PRODUTOS_SEM_ESTOQUE]

AS

SELECT	*
FROM	ESTOQUE


GO
/****** Object:  StoredProcedure [dbo].[relatorio_volume_vendas]    Script Date: 11/09/2008 17:09:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[relatorio_volume_vendas]
	@data_inicial smalldatetime,
	@data_final smalldatetime,
	@periodo char(1)

as



SELECT	data_transacao, valor_total
into	#dados
FROM	TRANSACOES T
WHERE	ID_TIPO_TRANSACAO IN (2,3,4)
and		data_transacao between @data_inicial and @data_final


if @periodo = 'D'
	select convert(char(10), data_transacao,103) as data, sum(valor_total)
	from #dados
	group by convert(char(10), data_transacao,103)
	order by 1
else if @periodo = 'S'
	select CONVERT(CHAR(4), DATEPART(YYYY, DATA_TRANSACAO)) + '/' + CONVERT(CHAR(2), DATEPART(WW, DATA_TRANSACAO)) as data, sum(valor_total)
	from #dados
	group by CONVERT(CHAR(4), DATEPART(YYYY, DATA_TRANSACAO)) + '/' + CONVERT(CHAR(2), DATEPART(WW, DATA_TRANSACAO))
	order by 1
else if @periodo = 'M'
	select CONVERT(CHAR(4), DATEPART(YYYY, DATA_TRANSACAO)) + '/' + CONVERT(CHAR(2), DATEPART(MM, DATA_TRANSACAO)) as data, sum(valor_total)
	from #dados
	group by CONVERT(CHAR(4), DATEPART(YYYY, DATA_TRANSACAO)) + '/' + CONVERT(CHAR(2), DATEPART(MM, DATA_TRANSACAO))
	order by 1

