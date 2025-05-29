# SafeZone.API

API desenvolvida para auxiliar na gestão de zonas de risco, moradores, alertas e kits de emergência em regiões afetadas por desastres naturais.

---

## Visão Geral

A SafeZone é uma aplicação desenvolvida em .NET com foco na proteção civil e resposta emergencial. O sistema permite:

* Cadastro e monitoramento de zonas de risco
* Emissão de alertas críticos
* Gerenciamento de moradores residentes nas zonas
* Controle de estoque de kits de emergência
* Interface visual com Razor Pages e navegação por TagHelpers

---

## Tecnologias Utilizadas

* ASP.NET Core 8
* Entity Framework Core (SQLite)
* Swagger / OpenAPI
* Razor Pages com TagHelpers
* REST Services (GET e POST)
* C# com uso de DTOs
* IDE: JetBrains Rider

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

1. Clone o repositório:

```bash
git clone https://github.com/tcguus/SafeZone.API.git
```

2. Restaure os pacotes:

```bash
dotnet restore
```

3. (Opcional) Crie a migration inicial:

```bash
dotnet ef migrations add InitialCreate
```

4. Atualize o banco de dados:

```bash
dotnet ef database update
```

5. Execute a aplicação:

```bash
dotnet run
```

6. Acesse o Swagger:

[http://localhost:5163/swagger](http://localhost:5163/swagger)

---

## Interface Web (Razor Pages)

A aplicação possui uma interface web construída com Razor Pages, que permite:

* Visualizar listas de moradores, zonas de risco, alertas e kits
* Organização de dados em tabelas estilizadas
* Navegação dinâmica entre seções
* Integração direta com Entity Framework Core

Acesse pelo navegador:

[http://localhost:5163](http://localhost:5163)

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

## Exemplos de Testes no Swagger

### Criar Kit de Emergência

```json
{
  "tipo": "Água potável",
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

* Validações automáticas com retorno padronizado (`application/problem+json`)
* DTOs para desacoplamento e proteção da camada de domínio
* Ciclos de referência resolvidos com `ReferenceHandler.Preserve`
* Razor Pages com layout estilizado e CSS inline
* TagHelpers aplicados na navegação entre páginas
* Projeto preparado para integração futura com dispositivos IoT

---

## Integrantes

* Gustavo Camargo de Andrade — RM555562 — 2TDSPF
* Rodrigo Souza Mantovanello — RM555451 — 2TDSPF
* Leonardo Cesar Rodrigues Nascimento — RM558373 — 2TDSPF
