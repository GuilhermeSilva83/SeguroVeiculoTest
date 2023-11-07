# Seguro Veiculo
Antes de testar a aplicação, o banco de dados precisa ser configurado, existe duas maneiras de fazer isso:
1) executando o arquivo seguro_db.sql e algum banco de dados SQL Server, logo após isso alterar a string de conexão, na pasta: SeguroVeiculo.WebApi\appsettings.json
2) ou alterar primeiramente o arquivo acima citado e logo após executar o seguindo comando: 

  `dotnet ef database update` 
Feito um dos passos acima, a aplicação está pronta para teste.
Não existe o front-end, então pode utilizar o Swagger ou algum cliente http para testar a api.

<endereço>/swagger/index.html
Exemplo: https://localhost:7119/swagger/index.html