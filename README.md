# Medicar
#Configuração de ambiente
- Para salvar as entidades no banco é necessário ter o SQL management studio (https://learn.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver16)
- No Sql management studio é necessário criar um database denominado MedicarDb (Assim como está presente no appsettings) ![image](https://github.com/Yurikamagoe/Medicar/assets/31245434/ceaa747a-64c1-4254-8758-144be59000b6)
- Não esquecer de alterar o appsettings para o servidor que você está utilizando
- ![image](https://github.com/Yurikamagoe/Medicar/assets/31245434/e5f8e1e7-00d8-458a-9a9b-f8d3ba3ce92d) 
- Para rodar as migrations do projeto é necessário entrar na pasta da API (Medicar) e digitar no terminal o comando **dotnet ef migrations update**
- Após rodar as migrations execute a solução da API em .Net utilizando o comando **dotnet watch run**
# Abaixo estarão listados os endpoints da aplicação e as respostas esperadas. Um arquivo com a collection estará disponível na pasta do repositório
- Criar usuário para autorização
![Create User](https://github.com/Yurikamagoe/Medicar/assets/31245434/8b875fe8-7103-46ae-8f82-79b225ce37ce)
- criação de token para autenticação
![Create Token](https://github.com/Yurikamagoe/Medicar/assets/31245434/694f019d-a4a2-4be3-8db4-cc4732909e39)
- Como utilizar o token via postman
![Bearer Token](https://github.com/Yurikamagoe/Medicar/assets/31245434/4c9e6e15-9515-4bd6-bc22-ce30ba452104)
- Registrar médico
![Create Doctor](https://github.com/Yurikamagoe/Medicar/assets/31245434/a671e6f1-4ce2-4390-822d-77fda0a3d04e)
- Criar agenda
![Create Schedule](https://github.com/Yurikamagoe/Medicar/assets/31245434/9e6c4fec-aedc-416e-898a-34457ec843b8)
- Marcar consulta
![Create DoctorAppointment](https://github.com/Yurikamagoe/Medicar/assets/31245434/abae12b8-271a-4289-87f7-4b7aff5572d2)
- Listar consultas
![GetAllDoctorAppointment](https://github.com/Yurikamagoe/Medicar/assets/31245434/e5858023-982a-43d4-8b19-013df5c3e6c3)
- Desmarcar consulta pelo id
![Remove DoctorAppointment](https://github.com/Yurikamagoe/Medicar/assets/31245434/d3726561-2cb9-4722-ada8-7af1cd868347)
