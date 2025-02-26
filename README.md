# PagePass
Esta API foi desenvolvida para gerenciar o empréstimo de livros em bibliotecas, permitindo um controle eficiente de usuários, livros e prazos de devolução.

---

## Funcionalidades
- Autenticação e Perfis de Acesso: Usuários podem criar contas e acessar com diferentes permissões  
- Cadastro e gerenciamento de usuários
- Cadastro e controle de livros disponíveis
- Registro de empréstimos e devoluções
- Controle de prazos e status dos empréstimos

---

## Tecnologias Utilizadas
### Backend
1. **.NET Core**: Framework principal para o backend.
2. **ASP.NET Core**: Para desenvolvimento da API RESTful.
3. **Entity Framework Core**: Para mapeamento objeto-relacional (ORM).
4. **JWT Bearer**: Para autenticação e autorização via tokens JWT.

### Ferramentas e Bibliotecas Adicionais
1. **AutoMapper**: Para mapeamento entre objetos.
2. **Swashbuckle**: Para documentação da API com Swagger.
3. **EF Tools**: Para gerenciamento de migrações de banco de dados.

### Banco de Dados
1. **SQL Server**: Banco relacional para armazenamento dos dados do sistema.

---


## Configuração do Ambiente

### Requisitos

#### SDKs e Ferramentas
1. **.NET SDK 6.0** ou superior.
2. **SQL Server**.
3. **Visual Studio** ou **Visual Studio Code** (com extensão C#).

#### Pacotes NuGet
1. `Microsoft.EntityFrameworkCore` (InMemory, SQL Server, Design).
2. `AutoMapper`.
3. `Swashbuckle.AspNetCore`.
4. `Microsoft.AspNetCore.Authentication.JwtBearer`.

---
## Estrutura do Projeto

A estrutura do projeto segue uma organização modular e de fácil manutenção:

```plaintext
PagePass/
├── src/                         # Código-fonte principal
│   ├── backend/                 # Código do backend
│   │   ├── PagePass.Presentation/    # Camada de apresentação (API)
│   │   ├── PagePass.Application/     # Regras de negócios e serviços
│   │   ├── PagePass.Domain/          # Entidades de domínio e validações
│   │   ├── PagePass.Infrastructure/  # Acesso a dados e integração com o banco de dados
│   │   ├── PagePass.IoC/             # Configuração de injeção de dependências
├── README.md                   # Documentação principal do projeto
├── PagePass.sln                  # Solução do projeto


