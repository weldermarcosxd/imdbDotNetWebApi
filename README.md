# Desafio Pessoa Desenvolvedora .NET

## 🏗 O que fazer?

- Você deve realizar um *fork* deste repositório e, ao finalizar, enviar o link do seu repositório para a nossa equipe. Lembre-se, **NÃO** é necessário criar um *Pull Request* para isso, nós iremos avaliar e retornar por e-mail o resultado do teste.

# 🚨 Requisitos

- A API deve ser construída em .NET Core (prioritariamente) ou .NET Framework ✓
- Implementar autenticação e deverá seguir o padrão ***JWT***, lembrando que o token a ser recebido deverá ser no formato ***Bearer*** ✓
- Implementar operações no banco de dados utilizando um ***ORM*** ou ***Micro ORM*** ✓
- **ORM's/Micro ORM's permitidos:**
    - *Entity Framework Core* ✓
    - *Dapper*
- **Bancos relacionais permitidos**
    - *SQL Server* (prioritariamente)
    - *MySQL*
    - *PostgreSQL* ✓
- As entidades da sua API deverão ser criadas utilizando ***Code First***. Portanto, as ***Migrations*** para geração das tabelas também deverá ser enviada no teste. ✓
- Sua API deverá seguir os padrões REST na construção das rotas e retornos ✓
- Sua API deverá conter documentação viva utilizando ***Swagger*** ✓
- Caso haja alguma particularidade de implementação, instruções para execução do projeto deverão ser enviadas ✓

# 🎁 Extra

Estes itens não são obrigatórios, porém desejados.

- Testes unitários
- Teste de integração da API em linguagem de sua preferência (damos importância para pirâmide de testes)
- Cobertura de testes utilizando Sonarqube
- Utilização de *Docker* (enviar todos os arquivos e instruções necessárias para execução do projeto)

# 🕵🏻‍♂️ Itens a serem avaliados

- Estrutura do projeto
- Utilização de código limpo e princípios **SOLID**
- Segurança da API, como autenticação, senhas salvas no banco, *SQL Injection* e outros.
- Boas práticas da Linguagem/Framework
- Seu projeto deverá seguir tudo o que foi exigido na seção  [O que desenvolver?](##--o-que-desenvolver)

# 🖥 O que desenvolver?

Você deverá criar uma API que o site [IMDb](https://www.imdb.com/) irá consultar para exibir seu conteúdo, sua API deverá conter as seguintes funcionalidades:

- Administrador ✓
    - Cadastro ✓
    - Edição ✓
    - Exclusão lógica (desativação) ✓
    - Listagem de usuários não administradores ativos ✓
        - Opção de trazer registros paginados ✓
        - Retornar usuários por ordem alfabética ✓
- Usuário ✓
    - Cadastro ✓
    - Edição ✓
    - Exclusão lógica (desativação) ✓
- Filmes
    - Cadastro (somente um usuário administrador poderá realizar esse cadastro) ✓
    - Voto (a contagem de votos será feita por usuário de 0-4 que indica quanto o usuário gostou do filme) ✓
    - Listagem ✓
        - Opção de filtros por diretor, nome, gênero e/ou atores ✓
        - Opção de trazer registros paginados ✓
        - Retornar a lista ordenada por filmes mais votados e por ordem alfabética ✓
    - Detalhes do filme trazendo todas as informações sobre o filme, inclusive a média dos votos ✓

**Obs.:** 

**Apenas os usuários poderão votar nos filmes e a API deverá validar quem é o usuário que está acessando, ou seja, se é um usuário administrador ou não.**

**Caso não consiga concluir todos os itens propostos, é importante que nos envie a implementação até onde foi possível para que possamos avaliar**