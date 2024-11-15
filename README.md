# Desafio Full Stack - Grupo +A Educação

## Sobre o Projeto

Esta aplicação foi desenvolvida como parte de um desafio técnico, com o objetivo de registrar e gerenciar matrículas de alunos em uma plataforma educacional. O sistema permite que os usuários se cadastrem, visualizem e editem informações sobre os alunos matriculados em turmas de programação web.

A arquitetura adotada segue os princípios do **Domain-Driven Design (DDD)**, que visa uma estruturação clara e eficaz do código, facilitando a manutenção e a escalabilidade do sistema.

## Tecnologias Utilizadas

- **Backend**: 
  - **.NET 8** - Framework utilizado para desenvolver a API.
  - **Entity Framework** - ORM utilizado para interação com o banco de dados.
  - **Swagger** - Para documentação da API e testes interativos.
  - **JWT (Json Web Token)** - Utilizado para autenticação e autorização na API.
  - **FluentValidation** - Para validação de entradas na API.
  - **FluentAssertions** - Biblioteca para melhorar os testes de unidade.
  
- **Frontend**:
  - **Vue.js** - Framework JavaScript para desenvolvimento da aplicação frontend.
  - **Vuetify** - Biblioteca de componentes baseada no Vue.js para a construção da UI.
  - **Axios** - Utilizado para comunicação com a API backend.
  - **Vue Router** - Gerenciamento de rotas da aplicação.
  - **Vite** - Ferramenta de build rápida e eficiente.

## Arquitetura Utilizada

A aplicação segue o padrão de **Domain-Driven Design (DDD)**, que organiza o código em torno de um modelo de domínio central, garantindo que as regras de negócio sejam bem definidas e de fácil manutenção. A arquitetura é composta pelas seguintes camadas:

1. **Camada de Apresentação (UI)**: Responsável pela interação com o usuário. Foi construída utilizando o framework **Vue.js** e os componentes do **Vuetify**, com foco em uma interface limpa e funcional.
2. **Camada de Aplicação**: Contém a lógica de aplicação e serviços que interagem diretamente com as camadas de domínio e de infraestrutura.
3. **Camada de Domínio**: A camada central que contém as entidades do sistema, ou seja, as classes que representam as principais regras de negócio, como a entidade `Aluno`.
4. **Camada de Infraestrutura**: Responsável pela persistência de dados e interação com bancos de dados. Utiliza **Entity Framework** como ORM e realiza a comunicação com um banco de dados **MySQL**.

Imagem da arquitetura

## Bibliotecas de Terceiros Utilizadas

### Backend

- **AutoMapper**: Utilizado para mapear objetos de domínio para objetos de requisição e resposta, evitando código repetitivo.
- **FluentValidation**: Implementação de validações para dados de entrada de forma simples e legível.
- **FluentAssertions**: Biblioteca utilizada para tornar as asserções nos testes mais expressivas e legíveis.
- **JWT (Json Web Token)**: Utilizado para gerenciar a autenticação e segurança da API.
- **Swagger**: Utilizado para gerar a documentação interativa da API, facilitando o teste de endpoints.

### Frontend

- **Vue.js**: Framework JavaScript para criação de aplicações de página única (SPA).
- **Vuetify**: Biblioteca de componentes baseada no Vue.js, que facilita a construção de interfaces ricas e responsivas.
- **Axios**: Biblioteca para realizar chamadas HTTP para a API e gerenciar dados entre o frontend e o backend.
- **Vue Router**: Gerenciador de rotas utilizado para criar a navegação entre diferentes páginas da aplicação.
- **Vuex**: Gerenciador de estado global que facilita o compartilhamento de dados entre componentes.
- **Vite**: Ferramenta de build que acelera o processo de desenvolvimento e garante alta performance.

## Melhorias que Fariam Parte do Próximo Sprint

### Backend

- **Aprimoramento da segurança**: Melhorar a segurança do JWT com regras mais rigorosas de autenticação, incluindo a criptografia das senhas.
- **Adicionar testes de integração**: Implementar testes que validem a integração entre os diferentes componentes da aplicação, como o banco de dados, a API e o frontend.
- **Refatoração da camada de domínio**: Criar entidades mais refinadas e específicas para o domínio de matrículas e alunos.
- **Monitoramento e logging**: Implementar soluções de logging e monitoramento, como o uso de **Serilog** para rastrear erros e otimizar o desempenho.

### Frontend

- **Melhorar a performance**: Otimizar a aplicação, especialmente para dispositivos móveis, para garantir uma experiência mais fluida e rápida.
- **Adicionar uma página de histórico de matrículas**: Criar uma página onde os usuários possam visualizar todas as matrículas realizadas.
- **Implementar tema dark/light**: Adicionar suporte a temas dinâmicos para melhorar a experiência visual do usuário.
- **Adicionar mais componentes reutilizáveis**: Refatorar o código para criar mais componentes modulares e reutilizáveis, reduzindo a duplicação de código.

## Requisitos Obrigatórios Não Entregues

Durante o desenvolvimento, a maioria dos requisitos foi atendida, mas algumas melhorias e funcionalidades adicionais planejadas não foram entregues devido a limitações de tempo:

- **Testes automatizados**: Não foi possível cobrir todos os testes unitários e de integração devido a restrições de tempo.
- **Interface Responsiva Completa**: A interface foi parcialmente responsiva, mas algumas partes ainda podem ser aprimoradas para dispositivos móveis.
- **Pagina de Histórico de Matrículas**: Não foi implementada uma página para visualizar o histórico completo de matrículas dos alunos.

## Conclusão

Este projeto foi uma excelente oportunidade para aplicar conhecimentos em **Domain-Driven Design (DDD)** e desenvolver uma aplicação Full Stack que combina **Vue.js** no frontend e **.NET 8** no backend. A experiência foi desafiadora, mas ao mesmo tempo, valiosa, pois permitiu o aprendizado de boas práticas de desenvolvimento e arquitetura de software.

Se tivesse mais tempo, as prioridades seriam implementar mais testes, melhorar a interface com o usuário e refinar a lógica de autenticação da API, além de adicionar mais funcionalidades, como a página de histórico de matrículas.

