# SafeZone.API

API desenvolvida para auxiliar na gestão de zonas de risco, moradores, alertas e kits de emergência em regiões afetadas por desastres naturais.

---

## Visão Geral

A **SafeZone** é uma plataforma que conecta sensores ambientais, aplicativos móveis, interface web em Razor Pages e um backend robusto em .NET para oferecer:

* Cadastro de zonas de risco e monitoramento
* Emissão de alertas emergenciais
* Controle de moradores em áreas afetadas
* Estoque de kits de emergência
* Interface web amigável via Razor Pages

---

## Tecnologias Utilizadas

* ASP.NET Core 8
* Entity Framework Core + SQLite
* Swagger / OpenAPI
* Razor Pages + TagHelpers
* REST Services
* C# + DTO Pattern
* JetBrains Rider

---

## Diagrama de Entidades

```
ZonaDeRisco
  ├─ id
  ├─ nome
  ├─ tipoEvento
  ├─ status
  ├─ coordenadas
  ├─ Alertas[]
  └─ Moradores[]

Alerta
  ├─ id
  ├─ titulo
  ├─ descricao
  ├─ nivelGravidade
  ├─ dataHora
  └─ zonaDeRiscoId (FK)

Morador
  ├─ id
  ├─ nome
  ├─ cpf
  ├─ prioridade
  └─ zonaDeRiscoId (FK)

KitEmergencia
  ├─ id
  ├─ tipo
  ├─ quantidade
  └─ localEstoque
```

---

## Como Executar o Projeto

1. **Clone o repositório:**

```bash
git clone https://github.com/tcguus/SafeZone.API.git
```

2. **Instale as dependências (caso necessário):**

```bash
dotnet restore
```

3. **(Opcional) Gere a migration inicial, se ainda não existir:**

```bash
dotnet ef migrations add InitialCreate
```

4. **Atualize o banco de dados:**

```bash
dotnet ef database update
```

5. **Execute o projeto:**

```bash
dotnet run
```

6. **Acesse a interface Swagger:**

[http://localhost:5163/swagger](http://localhost:5163/swagger)

> Recomendado: rodar com o perfil `Development` e usar SQLite configurado em `appsettings.json`.

---

## Documentação da Interface Web (Razor Pages)

A aplicação conta com páginas Razor que permitem a interação visual com os dados de forma intuitiva.

### Funcionalidades disponíveis via Razor:

* Listagem de moradores e zonas de risco
* Cadastro de novas zonas e moradores
* Atualização de dados existentes
* Navegação com TagHelpers integrados

### Acesso

Após rodar o projeto, acesse:

[http://localhost:5163](http://localhost:5163)

> A navegação é simples e o layout foi projetado com foco em clareza e acessibilidade.

---

## Endpoints Disponíveis

### Kits de Emergência

* `GET /api/KitEmergencia`
* `POST /api/KitEmergencia`

### Zonas de Risco

* `GET /api/ZonaDeRisco`
* `POST /api/ZonaDeRisco`

### Moradores

* `GET /api/Morador`
* `POST /api/Morador`

### Alertas

* `GET /api/Alerta`
* `POST /api/Alerta`

---

## Exemplos de Testes via Swagger

### Criar Kit de Emergência

```json
{
  "tipo": "Agua potável",
  "quantidade": 10,
  "localEstoque": "Posto de saúde local"
}
```

### Criar Zona de Risco

```json
{
  "nome": "Zona Norte",
  "tipoEvento": "Deslizamento",
  "status": "Ativo",
  "coordenadas": "-23.55,-46.63"
}
```

### Cadastrar Morador

```json
{
  "nome": "Maria Oliveira",
  "cpf": "12345678901",
  "prioridade": "Alta",
  "zonaDeRiscoId": 1
}
```

### Emitir Alerta

```json
{
  "titulo": "Calor extremo",
  "descricao": "Temperatura acima de 40ºC",
  "nivelGravidade": "Crítico",
  "dataHora": "2025-05-29T16:30:00",
  "zonaDeRiscoId": 1
}
```

---

## Detalhes Técnicos

* Ciclos de referência resolvidos com `ReferenceHandler.Preserve`
* Uso de DTOs para proteção e desacoplamento da camada de domínio
* Validações automáticas com retorno padronizado (`application/problem+json`)
* Interface Razor integrada com Entity Framework Core
* Pronto para integração com aplicações externas e dispositivos IoT

---

## Nossos integrantes

* Gustavo Camargo de Andrade — RM555562 — 2TDSPF
* Rodrigo Souza Mantovanello — RM555451 — 2TDSPF
* Leonardo Cesar Rodrigues Nascimento — RM558373 — 2TDSPF
