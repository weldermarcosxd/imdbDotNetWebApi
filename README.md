# README #

Estes documento README tem como objetivo fornecer as informações necessárias para realização do projeto Empresas.

### Objetivo ###
* Criação de uma API em .NET que atendam aos requisitos do escopo do projeto, listado abaixo.
* Você deve realizar um fork deste repositório e, ao finalizar, enviar o link do seu repositório para a nossa equipe. Lembre-se, **NÃO** é necessário criar um Pull Request para isso.
* Nós iremos realizar a avaliação e te retornar um email com o resultado.

### O que será avaliado?
* A ideia com este teste é ter um melhor entendimento das suas habilidades com a tecnoligia .Net, assim como seus frameworks. Mas de qualquer forma, uma boa padronização e organização, são **MUITO** bem vindas.
- A qualidade e desempenho do seu código
- Sua capacidade de organizar o código
- Capacidade de tomar decisões

### ESCOPO DO PROJETO ###
* Deve ser criada uma API em .NET, ou .NET Core.
* A API deve fazer o seguinte:
* Login e verificação de acesso de usuários registrados
	* Para o login usamos padrões OAuth 2.0.
* Listagem de Empresas
* Detalhamento de Empresas
* Filtro de Empresas por nome e tipo


### Informações Importantes ###

* Modelo de Integração disponível a partir de uma collection para Postman (https://www.getpostman.com/apps) disponível neste repositório.

* A API deve funcionar exatamente da mesma forma que a disponibilizada na collection do postman, mais abaixo os acessos a API estarão disponíveis em nosso servidor.

* Mantenha a mesma estrutura do postman em sua API, ou seja, ela deve ter os mesmo atributos, respostas, rotas e tratamentos, funcionando igual ao nosso exemplo.

* Quando seu código for finalizado e disponibilizado para validarmos, vamos subir em nosso servidor e realizar a integração com o app. 

* Independente de onde conseguiu chegar no teste é importante disponibilizar seu fonte para analisarmos.

* É obrigatório utilização de Banco de Dados Sql Server.

* Nâo esqueça de nos enviar um dump/script, dos dados utilizados.


### Dados para Teste ###

* Servidor: http://empresas.ioasys.com.br
* Versão da API: v1
* Usuário de Teste: testeapple@ioasys.com.br
* Senha de Teste : 12341234

### Dicas ###

* Guideline rails http://guides.rubyonrails.org/index.html
* Componente de autenticação https://github.com/rizel10/simple_token_auth
* Componente de autenticação https://github.com/lynndylanhurley/devise_token_auth
